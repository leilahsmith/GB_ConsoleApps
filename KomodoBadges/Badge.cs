using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges
{
    // POCO
    public class BadgeListPoco
    {
        public int BadgeID { get; set; }

        public List<string> Doors { get; set; }

        public BadgeListPoco() { }
        public BadgeListPoco(int id)
        {
            BadgeID = id;
        }

        public BadgeListPoco(int id, List<string> doors)
        {
            BadgeID = id;
            Doors = doors;
        }
    }
}
