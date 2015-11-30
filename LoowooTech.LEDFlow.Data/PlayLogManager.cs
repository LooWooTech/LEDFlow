using LoowooTech.LEDFlow.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace LoowooTech.LEDFlow.Data
{
    public class PlayLogManager
    {
        public void Add(PlayLog model)
        {
            DbHelper.ExecuteSql(@"insert into PlayLog (LEDID,ProgramID,CreateTime,ClientID) values(@LEDID,@ProgramID,@CreateTime,@ClientID)",
                new SQLiteParameter("@LEDID", model.LEDID),
                new SQLiteParameter("@ProgramID", model.ProgramID),
                new SQLiteParameter("@CreateTime", model.CreateTime),
                new SQLiteParameter("@ClientID", model.ClientID)
                );
        }

        /// <summary>
        /// 获取该LED屏今天需要播的数据
        /// </summary>
        private static List<PlayLog> GetList(int ledId)
        {
            var dt = DbHelper.GetDataTable("select * from PlayLog where LEDID=@LEDID and CreateTime > @CreateTime",
                new SQLiteParameter("@LEDID", ledId),
                new SQLiteParameter("@CreateTime", DateTime.Today)
                );

            var list = new List<PlayLog>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new PlayLog
                {
                    ID = (int)row["ID"],
                    LEDID = (int)row["LEDID"],
                    CreateTime = (DateTime)row["CreateTime"],
                    ClientID = row["ClientID"] == null ? null : row["ClientID"].ToString(),
                    ProgramID = (int)row["ProgramID"]
                });
            }

            var programs = ProgramManager.GetList();
            //TODO 把定点和定时的节目插入到结果中？但是节目没有指定LED，怎么分配？

            return list;
        }

        public static Program GetCurrentProgram(int ledId)
        {
            var list = GetList(ledId);

            for (var i = list.Count - 1; i >= 0; i--)
            {
                var log = list[i];
                var program = ProgramManager.GetModel(log.ProgramID);
                if(program == null)
                {
                    continue;
                }
                var playTime = log.CreateTime;
                switch (program.PlayMode)
                { 
                    case PlayMode.定点开始:
                        playTime = program.PlayTime.Value;
                        break;
                    case PlayMode.定点轮播:
                        playTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, program.PlayTime.Value.Hour, program.PlayTime.Value.Minute, 0);
                        break;
                    case PlayMode.立即开始:
                        playTime = log.CreateTime;
                        break;
                }
                //还没到时间
                if (DateTime.Now < playTime)
                {
                    continue;
                }
                else
                {
                    //如果设置了播放次数(未设置则是无限循环播放，不限次数)
                    if (program.PlayTimes != 0)
                    {
                        if ((DateTime.Now - playTime).TotalSeconds > program.Duration)
                        {
                            continue;
                        }
                    }
                    return program;
                }
            }

            return null;
        }
    }
}
