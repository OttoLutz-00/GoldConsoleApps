using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceBadges
{
    public class BadgeRepository
    {
        private readonly List<Badge> _badgeRepo = new List<Badge>();
        //Create
        public void AddBadge(Badge badge)
        {
            if (badge != null)
            {
                _badgeRepo.Add(badge);
            }
        }
        //Read

        //Update
        
        //Delete
    
    }
}
