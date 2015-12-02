using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace LoowooTech.LEDFlow.Data
{
    public class MessageManager
    {
        public static List<Client.Message> GetList()
        {
            var sql = "select * from Message where deleted=0 ";
            var dt = DbHelper.GetDataTable(sql);
            var list = new List<Client.Message>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Client.Message
                {
                    Content = row["Content"].ToString(),
                    CreateTime = DateTime.Parse(row["CreateTime"].ToString()),
                    Duration = int.Parse(row["Duration"].ToString()),
                    ID = int.Parse(row["ID"].ToString()),
                    Deleted = false
                });
            }
            return list;
        }

        public static void Save(Client.Message model)
        {
            if (model.ID > 0)
            {
                var sql = @"update Message set Content = @Content,Duration=@Duration where ID = @ID";
                DbHelper.ExecuteSql(sql, 
                    new SQLiteParameter("@Content", model.Content),
                    new SQLiteParameter("@Duration", model.Duration),
                    new SQLiteParameter("@ID", model.ID)
                );
            }
            else
            {
                var sql = @"insert into Message(Content,Duration,CreateTime,Deleted) values(@Content,@Duration,@CreateTime,@Deleted);
select last_insert_rowid();";
                var newId = DbHelper.ExecuteScalar(sql,
                    new SQLiteParameter("@Content", model.Content),
                    new SQLiteParameter("@Duration", model.Duration),
                    new SQLiteParameter("@CreateTime", model.CreateTime),
                    new SQLiteParameter("@Deleted", false)
                    );
                model.ID = int.Parse(newId.ToString());
            }
        }

        public static void Delete(int id)
        {
            var sql = @"update Message set Deleted=1 where ID = "+id;
            DbHelper.ExecuteSql(sql);
        }
    }
}
