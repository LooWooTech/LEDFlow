using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDFlow.Model
{
    public class LEDScreen
    {
        public int ID { get; set; }

        public string Name { get; set;}

        public int Width { get; set; }

        public int Height { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        public TextStyle DefaultStyle { get; set; }
    }
}
