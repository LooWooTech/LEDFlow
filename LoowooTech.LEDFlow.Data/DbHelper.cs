using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace LoowooTech.LEDFlow.Data
{
    public class DbHelper
    {
        private readonly static string ConnectionString = "data.db";

        private static SQLiteConnection GetConn()
        {
            return new SQLiteConnection("Data Source=" + System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConnectionString));
        }

        public static int ExecuteSql(string sql, params SQLiteParameter[] parameters)
        {
            using (var conn = GetConn())
            {
                conn.Open();
                var cmd = new SQLiteCommand(sql, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                var result = cmd.ExecuteNonQuery();
                conn.Close();
                return result;
            }
        }

        public static object ExecuteScalar(string sql, params SQLiteParameter[] parameters)
        {
            using (var conn = GetConn())
            {
                conn.Open();
                var cmd = new SQLiteCommand(sql, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                var result = cmd.ExecuteScalar();
                conn.Close();
                return result;
            }
        }

        public static DataTable GetDataTable(string sql, params SQLiteParameter[] parameters)
        {
            using (var conn = GetConn())
            {
                conn.Open();
                var cmd = new SQLiteCommand(sql, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                var da = new SQLiteDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                return ds.Tables[0];
            }
        }

    }
}
