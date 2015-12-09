﻿using LoowooTech.LEDFlow.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace LoowooTech.LEDFlow.Data
{
    public class PlayLogManager
    {
        public static void Add(PlayLog model)
        {
            var sql = "insert into PlayLog(ClientId,Content,PlayTime,EndTime)values(@ClientId,@Content,@PlayTime,@EndTime)";
            DbHelper.ExecuteSql(sql, 
                new SQLiteParameter("@ClientId", model.ClientId),
                new SQLiteParameter("@Content", model.Content),
                new SQLiteParameter("@PlayTime", model.PlayTime),
                new SQLiteParameter("@EndTime", model.EndTime)
            );
        }

        private static PlayLog ConvertToModel(DataRow dr)
        {
            return new PlayLog
            {
                ID = int.Parse(dr["ID"].ToString()),
                ClientId = dr["ClientId"] == null ? null : dr["ClientId"].ToString(),
                Content = dr["Content"].ToString(),
                EndTime = dr["EndTime"] == null ? default(DateTime?) : DateTime.Parse(dr["EndTime"].ToString()),
                PlayTime = DateTime.Parse(dr["PlayTime"].ToString())
            };
        }

        public static List<PlayLog> GetList(PageParameter page)
        {
            var list = new List<PlayLog>();

            var sql = string.Format("select * from PlayLog limit {0},{1}", page.CurrentPage-1, page.PageSize);
            var dt = DbHelper.GetDataTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(ConvertToModel(dr));
            }
            page.RecordCount = int.Parse(DbHelper.ExecuteScalar("select count(1) from PlayLog").ToString());
            return list;
        }
    }
}
