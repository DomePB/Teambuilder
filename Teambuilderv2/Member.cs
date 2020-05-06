using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teambuilderv2
{
    class Member
    {
        public bool allowedChangeActivity { get; set; }
        public bool allowedKickOthers { get; set; }
        public bool allowedStartActivity { get; set; }
        public bool ToogleInvite { get; set; }
        public bool autoFillEligible { get; set; }
        public bool autoFillProtectedForPromos { get; set; }
        public bool autoFillProtectedForSoloing { get; set; }
        public bool autoFillProtectedForStreaking { get; set; }
        public int botChampionId { get; set; }
        public string botDifficulty { get; set; }
        public string botId { get; set; }
        public string firstPositionPreference { get; set; }
        public int summonerId { get; set; }
    }
}
