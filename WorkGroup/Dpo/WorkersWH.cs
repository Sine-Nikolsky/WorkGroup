using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkGroup.Dpo
{
    class WorkersWH
    {
        public string Name { get; set; }
        public double WH { get; set; }
        public string Info { get
            {
                return Name + "   (" + WH +" н/ч)";
            }
        }
    }
}
