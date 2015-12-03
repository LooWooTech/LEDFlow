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
            var index = list.FindIndex(delegate(LEDScreen e) { return e.ID == model.ID; });
            if(index>-1)
            {
                list[index] = model;
            }
            else
            {
                list.Add(model);
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
