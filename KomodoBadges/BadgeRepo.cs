using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges
{
    public class BadgeRepo
    {
        private Dictionary<int, List<string>> _listOfBadges = new Dictionary<int, List<string>>();


        //Create
        public bool AddBadgeToList(BadgeListPoco badge)
        {
            int startingCount = _listOfBadges.Count;

            _listOfBadges.Add(badge.BadgeID, badge.Doors);

            bool wasAdded = (_listOfBadges.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read

        //Get All Badges
        public Dictionary<int, List<string>> ViewExistingBadges()
        {
            return _listOfBadges;
        }

        //public Dictionary<int, List<string>> dict = GetExistingBadges();

        //Get a single Badge from repo
        public BadgeListPoco GetABadgeByID(int badgeid)
        {
            if (_listOfBadges.ContainsKey(badgeid))
            {
                BadgeListPoco badge = new BadgeListPoco(badgeid);
                badge.Doors = _listOfBadges[badgeid];
                return badge;
            }
            return null;
        }
        //Update

        public bool UpdateExistingBadge(int oldBadgeID, BadgeListPoco newBadge)
        {
            BadgeListPoco oldBadge = GetABadgeByID(oldBadgeID);

            if (oldBadge != null)
            {
                oldBadge.BadgeID = newBadge.BadgeID;
                oldBadge.Doors = newBadge.Doors;
                return true;
            }
            else { return false; }
        }

        //Delete

        public bool DeleteBadge(BadgeListPoco badge)
        {
            bool deleteBadge = _listOfBadges.Remove(badge.BadgeID);
            return deleteBadge;
        }
    }
}

