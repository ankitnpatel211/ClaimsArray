using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsArray.Mappers
{
    public class MemberMap : ClassMap<Member>
    {
        public MemberMap()
        {
            Map(x => x.ID).Name("MemberID");
            Map(x => x.FirstName).Name("FirstName");
            Map(x => x.LastName).Name("LastName");
            Map(x => x.EnrollmentDate).Name("EnrollmentDate");
        }
    }
}
