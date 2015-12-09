using LoowooTech.LEDFlow.Common;
using LoowooTech.LEDFlow.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace LoowooTech.LEDFlow.Data
{
    public class ScheduleManager
    {
        public static void Save(Schedule model)
        {
            if (model.ID > 0)
            {
                DbHelper.ExecuteSql(@"
update Schedule set
PlayMode = @PlayMode,
BeginTime = @BeginTime,
EndTime = @EndTime,
PlayTimes = @PlayTimes
where ID = @ID
",
                    new SQLiteParameter("@ID", model.ID),
                    new SQLiteParameter("@PlayMode", (int)model.PlayMode),
                    new SQLiteParameter("@BeginTime", model.BeginTime),
                    new SQLiteParameter("@EndTime", model.EndTime),
                    new SQLiteParameter("@PlayTimes", model.PlayTimes));
            }
            else
            {
                var newId = DbHelper.ExecuteScalar(@"
insert into Schedule 
(ProgramID,CreateTime,PlayMode,BeginTime,EndTime,PlayTimes) values
(@ProgramID,@CreateTime,@PlayMode,@BeginTime,@EndTime,@PlayTimes);
select last_insert_rowid();",
                    new SQLiteParameter("@ProgramID", model.ProgramID),
                    new SQLiteParameter("@CreateTime", model.CreateTime),
                    new SQLiteParameter("@PlayMode", (int)model.PlayMode),
                    new SQLiteParameter("@BeginTime", model.BeginTime),
                    new SQLiteParameter("@EndTime", model.EndTime),
                    new SQLiteParameter("@PlayTimes", model.PlayTimes)
                 );
                model.ID = int.Parse(newId.ToString());
            }
            DbHelper.ExecuteSql("delete from ScheduleLED where ScheduleID = " + model.ID);
            foreach (var ledId in model.LEDIDs)
            {
                DbHelper.ExecuteSql("insert into ScheduleLED(ScheduleID,LEDID)values(@Schedule,@LEDID)",
                    new SQLiteParameter("@ScheduleID", model.ID),
                    new SQLiteParameter("@LEDID", ledId));
            }
        }

        public static List<Schedule> GetList(PageParameter page)
        {
            page.RecordCount = int.Parse(DbHelper.ExecuteScalar("select count(1) from Schedule").ToString());
            var dt = DbHelper.GetDataTable(string.Format("select * from Schedule  order by id desc limit {0},{1}", page.CurrentPage - 1, page.PageSize));
            var list = new List<Schedule>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(ConvertToModel(row));
            }
            return list;
        }

        /// <summary>
        /// 获取该LED屏今天需要播的数据，该列表不包含LEDIDs字段
        /// </summary>
        private static List<Schedule> GetLedList(int ledId)
        {

            var maxObj = DbHelper.ExecuteScalar("select max(id) from Schedule where LedIds like '%," + ledId + ",%' and PlayMode =0 and EndTime < @EndTime", new SQLiteParameter("@EndTime", DateTime.Now.AddHours(-4)));
            var maxId = StringHelper.ToInt(maxObj.ToString());

            var dt = DbHelper.GetDataTable("select * from Schedule where ((PlayMode == 0 and id>" + maxId + ") or (PlayMode <> 0)) and LedIds like '%," + ledId + ",%' order by id desc");

            var list = new List<Schedule>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(ConvertToModel(row));
            }
            //GetLEDIDs(list);
            return list;
        }

        public static int[] GetLEDIDs(int scheduleId)
        {
            var list = new List<int>();
            var dt = DbHelper.GetDataTable("select LEDID from ScheduleLED where ScheduleID=" + scheduleId);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(int.Parse(dr["LEDID"].ToString()));
            }
            return list.ToArray();
        }

        private static void GetLEDIDs(List<Schedule> list)
        {
            var sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.Append(item.ID);
                sb.Append(',');
            }
            var dt = DbHelper.GetDataTable("select LEDID from ScheduleLED where ScheduleID in (" + sb.ToString().TrimEnd(',') + ")");
            foreach (var item in list)
            {
                var ledids = new List<int>();
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["ScheduleID"].ToString() == item.ID.ToString())
                    {
                        ledids.Add(int.Parse(dr["LEDID"].ToString()));
                    }
                }
                item.LEDIDs = ledids.ToArray();
            }
        }

        private static Schedule ConvertToModel(DataRow row)
        {
            return new Schedule
            {
                ID = int.Parse(row["ID"].ToString()),
                CreateTime = DateTime.Parse(row["CreateTime"].ToString()),
                PlayMode = StringHelper.ToEnum<PlayMode>(row["PlayMode"].ToString()),
                PlayTimes = int.Parse(row["PlayTimes"].ToString()),
                BeginTime = DateTime.Parse(row["BeginTime"].ToString()),
                EndTime = (row["EndTime"] == null || row["EndTime"].ToString().Length == 0) ? default(DateTime?) : DateTime.Parse(row["EndTime"].ToString()),
                ProgramID = int.Parse(row["ProgramID"].ToString())
            };
        }

        public static Program GetCurrentProgram(LEDScreen led)
        {
            var dt = DbHelper.GetDataTable("select ScheduleID from ScheduleLED where LEDID=" + led.ID + " order by ID desc");
            var ids = new List<int>();
            foreach (DataRow dr in dt.Rows)
            {
                ids.Add(int.Parse(dr["ScheduleID"].ToString()));
            }

            foreach (var scheduleId in ids)
            {
                var model = GetModel(scheduleId);
                if (model == null)
                {
                    continue;
                }
                if (
                    (DateTime.Now < model.BeginTime)
                    || (model.EndTime.HasValue && DateTime.Now > model.EndTime.Value)
                    )
                {
                    continue;
                }
                var program = ProgramManager.GetModel(model.ProgramID);
                //如果屏幕当前有播放节目，并且和本次获取的节目相同，则判断该节目是否播放完一次，如果播放完成则返回program，如果没有，则返回null
                if (led.CurrentProgram != null && led.CurrentProgram.ID == program.ID)
                {
                    if (((DateTime.Now - model.BeginTime).TotalSeconds / led.CurrentProgram.GetPlayDuration(1)) > 1)
                    {
                        return program;
                    }
                    return null;
                }
                else
                {
                    led.CurrentProgram = program;
                    return program;
                }
            }
            return null;
        }

        public static Schedule GetModel(int id)
        {
            var dt = DbHelper.GetDataTable("select * from Schedule where ID=" + id);
            if (dt.Rows.Count == 0) return null;
            return ConvertToModel(dt.Rows[0]);
        }

        public static void Delete(int id)
        {
            DbHelper.ExecuteSql("delete from Schedule where ID=@ID", new SQLiteParameter("@ID", id));
        }
    }
}
