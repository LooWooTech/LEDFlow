using LoowooTech.LEDFlow.Common;
using LoowooTech.LEDFlow.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace LoowooTech.LEDFlow.Data
{
    public class ProgramManager
    {
        private static Program ConvertToModel(DataRow row)
        {
            var model = new Program
            {
                ID = int.Parse(row["ID"].ToString()),
                Deleted = bool.Parse(row["Deleted"].ToString()),
                CreateTime = DateTime.Parse(row["CreateTime"].ToString()),
                ClientID = row["ClientID"] == null ? null : row["ClientID"].ToString(),
            };
            var msgs = row["Messages"].ToString().Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var msg in msgs)
            {
                //最后一个冒号后是持续时间，如果没有，则使用默认时间
                var index = msg.LastIndexOf(':');
                if (index > 0)
                {
                    model.Messages.Add(new Message
                    {
                        Content = msg.Substring(0, index),
                        Duration = StringHelper.ToInt(msg.Substring(index + 1))
                    });
                }
                else
                {
                    model.Messages.Add(new Message
                    {
                        Content = msg,
                        Duration = 0
                    });
                }
            }
            return model;
        }

        public static Program GetModel(int id)
        {
            var sql = "select * from Program where id = " + id + " and deleted=0 limit 0,1";
            var dt = DbHelper.GetDataTable(sql);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            return ConvertToModel(dt.Rows[0]);
        }

        public static void Save(Program model)
        {
            var messages = new StringBuilder();
            foreach (var msg in model.Messages)
            {
                messages.Append(msg.Content + ":" + msg.Duration);
                messages.Append('\n');
            }
            if (model.ID > 0)
            {
                var sql = "update Program set Messages = @Messages Where ID = @ID";
                DbHelper.ExecuteSql(sql, new SQLiteParameter("@Messages", messages), new SQLiteParameter("@ID", model.ID));
            }
            else
            {
                var sql = @"insert into Program(ClientID,CreateTime,Deleted,Messages)Values(@ClientID,@CreateTime,0,@Messages);
select last_insert_rowid();";
                var newId = DbHelper.ExecuteScalar(sql,
                    new SQLiteParameter("@ClientID", model.ClientID),
                    new SQLiteParameter("@CreateTime", model.CreateTime),
                    new SQLiteParameter("@Messages", messages)
                    );
                model.ID = int.Parse(newId.ToString());
            }
        }

        public static void Delete(int id)
        {
            //会删除相关的排期
            var sql = @"
update Program set Deleted=1 where ID =@ID;
delete from Schedule where ProgramID = @ID;
";
            DbHelper.ExecuteSql(sql, new SQLiteParameter("@ID", id));
        }

        public static List<Program> GetList(string clientId = null)
        {
            var sql = "select * from Program where deleted=0 ";
            if (!string.IsNullOrEmpty(clientId))
            {
                sql += " and clientId='" + clientId + "'";
            }
            else
            {
                sql += " and clientId is null";
            }
            var dt = DbHelper.GetDataTable(sql);
            var list = new List<Program>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(ConvertToModel(dr));
            }
            return list;
        }
    }
}
