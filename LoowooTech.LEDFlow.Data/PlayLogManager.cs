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
        public static void Add(PlayLog model)
        {
            var sql = "insert into PlayLog(ClientId,Content,PlayTime,EndTime,LedIds)values(@ClientId,@Content,@PlayTime,@EndTime,@LedIds)";
            DbHelper.ExecuteSql(sql,
                new SQLiteParameter("@ClientId", model.ClientId),
                new SQLiteParameter("@Content", model.Content),
                new SQLiteParameter("@PlayTime", model.PlayTime),
                new SQLiteParameter("@EndTime", model.EndTime),
                new SQLiteParameter("@LedIds", string.Join(",", model.LedIds))
            );
        }

        private static PlayLog ConvertToModel(DataRow dr)
        {
            return new PlayLog
            {
                ID = int.Parse(dr["ID"].ToString()),
                ClientId = dr["ClientId"] == null ? null : dr["ClientId"].ToString(),
                Content = dr["Content"].ToString(),
                EndTime = (dr["EndTime"] == null || dr["EndTime"].ToString().Length == 0) ? default(DateTime?) : DateTime.Parse(dr["EndTime"].ToString()),
                PlayTime = DateTime.Parse(dr["PlayTime"].ToString()),
                LedIds = dr["LedIds"].ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            };
        }

        public static List<PlayLog> GetList(PageParameter page)
        {
            var list = new List<PlayLog>();

            var sql = string.Format("select * from PlayLog order by id desc limit {0},{1}", page.CurrentPage - 1, page.PageSize);
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
