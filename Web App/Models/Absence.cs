using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Absence
{
        public int id { get; set; }

        public bool justefied { get; set; }

        public bool isPunishement { get; set; }

        public DateTime date { get; set; }
}
}
