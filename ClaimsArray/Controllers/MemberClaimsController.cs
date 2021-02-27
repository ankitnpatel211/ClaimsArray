using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClaimsArray.Services;
using ClaimsArray.Mappers;
using System.Text.Json;
using System.Text.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClaimsArray.Controllers
{
    [Produces("application/json")]
    [Route("api/MemberClaims")]
    [ApiController]
    public class MemberClaimsController : ControllerBase
    {
        private const string claimsPath = @"../ClaimsArray/CSVs/Claim.csv";
        private const string membersPath = @"../ClaimsArray/CSVs/Member.csv";

        // GET: api/<MemberClaimsController>
        [HttpGet]
        public string Get(string claimDate)
        {
            var claimRecords = new MemberClaimService<Claim, ClaimMap>();
            var memberRecords = new MemberClaimService<Member, MemberMap>();
            List<Claim> claims = claimRecords.ReadCSVFile(claimsPath);
            List<Member> members = memberRecords.ReadCSVFile(membersPath);
            var filteredClaimByClaimDate = claims.Where(x => x.ClaimDate == claimDate).ToList();
            var claimArrayList = new List<ClaimArray>();
            foreach(var filteredClaim in filteredClaimByClaimDate)
            {
                var claimArray = new ClaimArray();
                var member = members.Where(x => x.ID == filteredClaim.MemberID).SingleOrDefault();
                claimArray.Member = member;
                claimArray.Claim = filteredClaim;
                claimArrayList.Add(claimArray);
            }
            string claimsArray = JsonSerializer.Serialize(claimArrayList);
            return claimsArray;
        }

      
        // POST api/<MemberClaimsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MemberClaimsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MemberClaimsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
