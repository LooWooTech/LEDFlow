using LoowooTech.LEDFlow.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDFlow.Data
{
    public class LEDManager
    {
        public static LEDScreen GetModel(int ledId)
        {
            var list = DataManager.Instance.GetList<LEDScreen>();
            return list.Find(delegate(LEDScreen e) { return e.ID == ledId; });
        }

        public static void Save(LEDScreen model)
        {
            var list = DataManager.Instance.GetList<LEDScreen>();
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
                var index = list.FindIndex(delegate(LEDScreen e) { return e.ID == model.ID; });
                list[index] = model;
            }
            DataManager.Instance.Save(list);
        }

        public static void Delete(int id)
        {
            var list = DataManager.Instance.GetList<LEDScreen>();
            var index = list.FindIndex(delegate(LEDScreen p) { return p.ID == id; });
            list.RemoveAt(index);
            DataManager.Instance.Save(list);
        }

        public static List<LEDScreen> GetList()
        {
            return DataManager.Instance.GetList<LEDScreen>();
        }
    }
}
