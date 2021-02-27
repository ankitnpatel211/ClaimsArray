using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ClaimsArray.Mappers;
using CsvHelper.Configuration;

namespace ClaimsArray.Services
{
    public class MemberClaimService<T, U> where T : class 
        where U : ClassMap
    {
        public List<T> ReadCSVFile(string location)
        {
            try
            {
                using var reader = new StreamReader(location, Encoding.Default);
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.RegisterClassMap<U>();
                    var claimRecords = csv.GetRecords<T>().ToList();
                    return claimRecords;
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}


