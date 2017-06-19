﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameday
{
    class NamedayModel
    {
        public int Month { get; set; }
        public int Day { get; set; }
        public IEnumerable<string> Names { get; set; }

        public NamedayModel(int month, int day, IEnumerable<string> names)
        {
            Month = month;
            Day = day;
            Names = names; 
        }

        public string NamesAsString
        {
            get { return string.Join(", ", Names); }
        }

        // Now with C# 6 I could do this ->  public string NamesAsString => string.Join(", ", Names); 
    }
}
