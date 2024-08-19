using Investor.Models;
using Investor.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Repository
{
    public class InvestorRepository : IInvestorRepository
    {
        private readonly InvestorContext _context;

        public InvestorRepository(InvestorContext context)
        {
            _context = context;
        }

        public List<InvestorData> GetAllInvestors()
        {
            return _context.Investor.Include(x => x.Commitments).ToList();
        }
        public InvestorData GetInvestorById(int id)
        {
            return _context.Investor.Include(i => i.Commitments).FirstOrDefault(x => x.Id == id);
        }
    }
}
