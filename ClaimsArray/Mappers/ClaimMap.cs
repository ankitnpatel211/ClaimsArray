using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsArray.Mappers
{
    public class ClaimMap : ClassMap<Claim>
    {
        public ClaimMap()
        {
            Map(x => x.MemberID).Name("MemberID");
            Map(x => x.ClaimAmount).Name("ClaimAmount");
            Map(x => x.ClaimDate).Name("ClaimDate");
        }
    }
}
