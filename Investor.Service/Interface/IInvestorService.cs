using Investor.Models;

namespace Investor.Service.Interface
{
    public interface IInvestorService
    {
        public List<InvestorDto> GetInvestors();

        public InvestorDto GetInvestorById(int id);
       
    }
}
