using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teambuilderv2
{
    class Rank
    {
        public int lp;
        public string rank;
        public string tier;

        public Rank(int lp, string rank, string tier)
        {
            this.lp = lp;
            this.rank = rank;
            this.tier = tier;
        }
    }
}
