using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public class ClaimRepo 
    {
        public Queue<ClaimClass> _queueOfClaims = new Queue<ClaimClass>();


        //Create
        public bool CreateNewClaim(ClaimClass claims)
        {
            int startingCount = _queueOfClaims.Count;
            _queueOfClaims.Enqueue(claims);

            bool wasAdded = (_queueOfClaims.Count > startingCount) ? true : false;
            return wasAdded;

        }

        //Read
        public Queue<ClaimClass> SeeAllClaims()
        {
            return _queueOfClaims;
        }

        //Read next claim without deleting.
        public ClaimClass PeekClaim()
        {
            if (_queueOfClaims.Peek() != null)
            {
                return _queueOfClaims.Peek();
            }
            return null;
        }

        //Update: Take Care of Next Claim

        public ClaimClass SettleNextClaim()
        {
            ClaimClass claim = _queueOfClaims.Peek();
            return claim;
        }
        public bool DequeueClaim()
        {
            int startingCount = _queueOfClaims.Count;
            _queueOfClaims.Dequeue();

            bool wasDequeued = (_queueOfClaims.Count < startingCount) ? true : false;
            return wasDequeued;
        }
    }
}
