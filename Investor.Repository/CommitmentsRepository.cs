using Investor.Models;
using Investor.Repository.Interface;

namespace Investor.Repository
{
    public class CommitmentsRepository : ICommitmentsRepository
    {
        private readonly InvestorContext _context;

        public CommitmentsRepository(InvestorContext context)
        {
            _context = context;
        }

        public List<Commitment> GetCommitmentsById(int id) { 
            return _context.Commitment.Where(x => x.InvestorId == id).ToList();
        }
}
}
