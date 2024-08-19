using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Investor.Models;
using System.Globalization;

namespace Investor.Repository
{
    public static class DbInitializer
    {
        public static void Initialize(InvestorContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            if (context.Investor.Any())
            {
                return;
            }
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null
            };

            using var reader = new StreamReader("data.csv");
            using var csv = new CsvReader(reader, csvConfig);
            var records = csv.GetRecords<InvestorRecord>().ToList();
            var investors = new Dictionary<string, InvestorData>();
            foreach (var record in records)
            {
                if (!investors.ContainsKey(record.InvestorName))
                {
                    investors[record.InvestorName] = new InvestorData
                    {
                        Name = record.InvestorName,
                        InvestorType = record.InvestorType,
                        Country = record.InvestorCountry,
                        DateAdded = record.InvestorDateAdded,
                        LastModifiedDate = record.InvestorLastupdated
                    };
                }
                investors[record.InvestorName].Commitments.Add(new Commitment
                {
                    InvestorId = investors[record.InvestorName].Id,
                    AssetClass = record.CommitmentAssetClass,
                    Amount = record.CommitmentAmount,
                    Currency = record.CommitmentCurrency
                });

            }

            context.Investor.AddRange(investors.Values);
            context.SaveChanges();

        }
    }
    public class InvestorRecord
    {
        public string InvestorName { get; set; }
        public string InvestorType { get; set; }
        public string InvestorCountry { get; set; }

        [Format("dd-MM-yyyy")]
        public DateTime InvestorDateAdded { get; set; }

        [Format("dd-MM-yyyy")]
        public DateTime InvestorLastupdated { get; set; }
        public string CommitmentAssetClass { get; set; }
        public decimal CommitmentAmount { get; set; }
        public string CommitmentCurrency { get; set; }
    }

    
}
