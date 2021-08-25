using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceBadges
{
    public class BadgeRepository
    {
        private readonly Dictionary<int, List<string>> _badgeRepo = new Dictionary<int, List<string>>();
        //Create
        public void AddBadge(Badge badge)
        {
            if (badge != null)
            {
                _badgeRepo.Add(badge.BadgeID, badge.AccessibleDoors);
            }
        }
        //Read
        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _badgeRepo;
        }
        
        //Update
        public void UpdateBadge(int badgeID, string newDoor)
        {
            if (_badgeRepo.ContainsKey(badgeID))
            {
                _badgeRepo[badgeID].Add(newDoor);
            }
        }
        //Delete
        public void DeleteBadge(int badgeID, string doorName)
        {
            if (_badgeRepo.ContainsKey(badgeID))
            {
                _badgeRepo[badgeID].Remove(doorName);
            }
        }
    }
}
