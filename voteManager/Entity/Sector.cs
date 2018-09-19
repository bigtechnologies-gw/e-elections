using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteManager.Entity
{
    class Sector
    {

        // TODO: This is added to avoid using futil* classes. May be changed anytime to a container class.
        public int CE { get; set; }

        public string Name { get; set; }

        public decimal Vote { get; set; }

        public Sector(int ce, string name)
        {
            Name = name;
            CE = ce;
        }
    }
}
