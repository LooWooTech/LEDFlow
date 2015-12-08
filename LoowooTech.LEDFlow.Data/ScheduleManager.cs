﻿using LoowooTech.LEDFlow.Common;
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
LedIds = @LedIds,
PlayMode = @PlayMode,
BeginTime = @BeginTime,
EndTime = @EndTime,
PlayTimes = @PlayTimes
where ID = @ID
",
                    new SQLiteParameter("@ID", model.ID),
                    new SQLiteParameter("@LedIds", "," + string.Join(",", model.LedIds) + ","),
                    new SQLiteParameter("@PlayMode", (int)model.PlayMode),
                    new SQLiteParameter("@BeginTime", model.BeginTime),
                    new SQLiteParameter("@EndTime", model.EndTime),
                    new SQLiteParameter("@PlayTimes", model.PlayTimes));
            }
            else
            {
                DbHelper.ExecuteSql(@"
insert into Schedule 
(LedIds,ProgramID,CreateTime,PlayMode,BeginTime,EndTime,PlayTimes) values
(@LedIds,@ProgramID,@CreateTime,@PlayMode,@BeginTime,@EndTime,@PlayTimes)",
                    new SQLiteParameter("@LedIds", "," + string.Join(",", model.LedIds) + ","),
                    new SQLiteParameter("@ProgramID", model.ProgramID),
                    new SQLiteParameter("@CreateTime", model.CreateTime),
                    new SQLiteParameter("@PlayMode", (int)model.PlayMode),
                    new SQLiteParameter("@BeginTime", model.BeginTime),
                    new SQLiteParameter("@EndTime", model.EndTime),
                    new SQLiteParameter("@PlayTimes", model.PlayTimes)
                 );
            }
        }

        public static List<Schedule> GetList(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = int.Parse(DbHelper.ExecuteScalar("select count(1) from Schedule").ToString());
            var dt = DbHelper.GetDataTable(string.Format("select * from Schedule  order by id desc limit {0},{1}", pageIndex - 1, pageSize));
            var list = new List<Schedule>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(ConvertToModel(row));
            }
            return list;
        }

        /// <summary>
        /// 获取该LED屏今天需要播的数据
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
            return list;
        }



        private static Schedule ConvertToModel(DataRow row)
        {
            return new Schedule
            {
                ID = int.Parse(row["ID"].ToString()),
                LedIds = row["LedIds"].ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries),
                CreateTime = DateTime.Parse(row["CreateTime"].ToString()),
                PlayMode = StringHelper.ToEnum<PlayMode>(row["PlayMode"].ToString()),
                PlayTimes = int.Parse(row["PlayTimes"].ToString()),
                BeginTime = DateTime.Parse(row["BeginTime"].ToString()),
                EndTime = DateTime.Parse(row["EndTime"].ToString()),
                ProgramID = int.Parse(row["ProgramID"].ToString())
            };
        }

        public static Program GetCurrentProgram(int ledId)
        {
            var list = GetLedList(ledId);

            for (var i = list.Count - 1; i >= 0; i--)
            {
                var model = list[i];

                //还没到时间或当前时间大于播放结束时间。
                if (DateTime.Now < model.BeginTime || DateTime.Now > model.EndTime)
                {
                    continue;
                }
                else
                {
                    return ProgramManager.GetModel(model.ProgramID);
                }
            }

            return null;
        }

        public static Schedule GetModel(int id)
        {
            var dt = DbHelper.GetDataTable("select * from Schedule where ID=@ID",
                new SQLiteParameter("@ID", id)
                );
            if (dt.Rows.Count == 0) return null;
            return ConvertToModel(dt.Rows[0]);
        }

        public static void Delete(int id)
        {
            DbHelper.ExecuteSql("delete from Schedule where ID=@ID", new SQLiteParameter("@ID", id));
        }
    }
}
