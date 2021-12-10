using System.Collections.Generic;

namespace KomodoInsurance
{
    public interface IClaimRepo
    {
        void CreateNewClaim(ClaimClass claims);
        void DeleteClaim(ClaimClass claims);
        Queue<ClaimClass> SeeAllClaims();
        ClaimClass SettleNextClaim();
    }
}