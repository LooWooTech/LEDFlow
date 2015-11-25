using LoowooTech.LEDFlow.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDFlow.Data
{
    public class ProgramManager
    {
        public static Program GetModel(int id)
        {
            if (id > 0)
            {
                var list = DataManager.Instance.GetList<Program>();
                return list.Find(delegate(Program p) { return p.ID == id; });
            }
            return null;
        }

        public static void Save(Program model)
        {
            var list = DataManager.Instance.GetList<Program>();
            if (model.ID == 0)
            {
                if (list.Count > 0)
                {
                    var last = list[list.Count - 1];
                    model.ID = last.ID + 1;
                }
                else
                {
                    model.ID = 1;
                }
                list.Add(model);
            }
            else
            {
                var index = list.FindIndex(delegate(Program p) { return p.ID == model.ID; });
                list[index] = model;
            }
            DataManager.Instance.Save(list);
        }

        public static void Delete(int id)
        {
            var list = DataManager.Instance.GetList<Program>();
            var index = list.FindIndex(delegate(Program p) { return p.ID == id; });
            list.RemoveAt(index);
            DataManager.Instance.Save(list);
        }

        public static List<Program> GetList()
        {
            return DataManager.Instance.GetList<Program>();
        }
    }
}
