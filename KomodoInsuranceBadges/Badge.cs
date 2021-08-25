using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceBadges
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> AccessibleDoors { get; set; }
        public Badge() { }
        public Badge(int id, List<string> list)
        {
            BadgeID = id;
            AccessibleDoors = list;
        }
    }
}
