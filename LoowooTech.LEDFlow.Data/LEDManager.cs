using LoowooTech.LEDFlow.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDFlow.Data
{
    public class LEDManager
    {
        private static List<LEDScreen> _list = null;

        public static LEDScreen GetModel(int ledId)
        {
            var list = GetList();
            return list.Find(delegate(LEDScreen e) { return e.ID == ledId; });
        }

        public static void Save(LEDScreen model)
        {
            var list = GetList();
            var index = list.FindIndex(delegate(LEDScreen e) { return e.ID == model.ID; });
            //客户端发送消息会更新CustomStyle，不能重置VirtualID，所以注释掉
            //model.VirtualID = -1;//编辑或新建LED，virtualId必须重置
            if (index > -1)
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
            var list = GetList();
            var index = list.FindIndex(delegate(LEDScreen p) { return p.ID == id; });
            list.RemoveAt(index);
            DataManager.Instance.Save(list);
        }

        public static List<LEDScreen> GetList()
        {
            if (_list == null)
            {
                _list = DataManager.Instance.GetList<LEDScreen>();
            }
            return _list;
        }
    }
}
