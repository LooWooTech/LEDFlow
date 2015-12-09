using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDFlow.Model
{
    [Serializable]
    public class LEDScreen
    {
        public LEDScreen()
        {
            DefaultStyle = new TextStyle();
        }

        public int ID { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public int VirtualID { get; set; }

        public string Name { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public TextStyle DefaultStyle { get; set; }

        public string[] Clients { get; set; }
    }
}
