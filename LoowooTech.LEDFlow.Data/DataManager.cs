using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace LoowooTech.LEDFlow.Data
{
    public class DataManager
    {
        private DataManager()
        { }

        public readonly static DataManager Instance = new DataManager();

        private void SaveDataModel(Data model)
        {
            if (model.ID == 0)
            {
                DbHelper.ExecuteSql("INSERT INTO Data (Type,CreateTime,Data) VALUES (@Type,@CreateTime,@Data)",
                    new SQLiteParameter("@Type", (int)model.Type),
                    new SQLiteParameter("@CreateTime", model.CreateTime),
                    new SQLiteParameter("@Data", model.DataJson)
                    );
            }
            else
            {
                DbHelper.ExecuteSql("UPDATE Data SET Data = @Data WHERE Type=@Type",
                    new SQLiteParameter("@Type", (int)model.Type),
                    new SQLiteParameter("@Data", model.DataJson)
                );
            }

        }

        private Data GetDataModel<T>()
        {
            var type = GetType<T>();
            var dt = DbHelper.GetDataTable(string.Format("SELECT * FROM [Data] WHERE Type = {0} LIMIT 0,1", (int)type));
            if (dt.Rows.Count > 0)
            {
                var dr = dt.Rows[0];
                return new Data
                {
                    ID = int.Parse(dr["ID"].ToString()),
                    CreateTime = DateTime.Parse(dr["CreateTime"].ToString()),
                    Type = (DataType)int.Parse(dr["Type"].ToString()),
                    DataJson = dr["Data"].ToString()
                };
            }
            return null;
        }

        public List<T> GetList<T>()
        {
            var model = GetDataModel<T>();
            var result = new List<T>();
            if (model != null)
            {
                result = model.GetObject<List<T>>();
            }
            return result == null ? new List<T>() : result;
        }

        public void Save<T>(List<T> list)
        {
            var model = GetDataModel<T>() ?? new Data
            {
                Type = GetType<T>()
            };
            model.SetObject(list);
            SaveDataModel(model);
        }

        private DataType GetType<T>()
        {
            var typeName = typeof(T).Name;
            var enumType = typeof(DataType);

            foreach (var name in Enum.GetNames(enumType))
            {
                if (typeName.Contains(name))
                {
                    return (DataType)Enum.Parse(enumType, name);
                }
            }
            return 0;
        }
    }
}
