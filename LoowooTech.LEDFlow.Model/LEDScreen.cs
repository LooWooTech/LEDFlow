using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDFlow.Model
{
    public class LEDScreen
    {
        public LEDScreen()
        {
            DefaultStyle = new TextStyle();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        public TextStyle DefaultStyle { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public Program CurrentProgram { get; set; }

        public string ClientID { get; set; }
    }
}
