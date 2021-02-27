using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsArray
{
    public class ClaimArray
    {
        public ClaimArray()
        {
            this.Member = new Member();
            this.Claim = new Claim();
        }

        public Member Member { get; set; }
        public Claim Claim { get; set; }
    }
}
