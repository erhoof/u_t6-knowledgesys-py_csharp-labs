using System;
using System.Collections.Generic;
using System.Text;

namespace u_t6_data_1
{
    class Fact
    {
        public Fact(string line)
        {
            Line = line;
        }

        public Fact(string line, bool value)
        {
            Line = line;
            IsTrue = value;
        }

        public bool IsTrue { get; set; }
        public string Line { get; }
    }
}
