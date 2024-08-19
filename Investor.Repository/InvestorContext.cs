using Investor.Models;
using Microsoft.EntityFrameworkCore;


namespace Investor.Repository
{
    public class InvestorContext : DbContext
    {
        public InvestorContext(DbContextOptions<InvestorContext> options) : base(options) { }

        public DbSet<InvestorData> Investor {get; set; }

        public DbSet<Commitment> Commitment {get; set; }
    }
}

