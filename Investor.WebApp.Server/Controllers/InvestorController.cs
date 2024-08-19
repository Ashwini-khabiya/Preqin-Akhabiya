using Investor.Models;
using Investor.Service;
using Investor.Service.Interface;
using Microsoft.AspNetCore.Mvc;



namespace Investor.WebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestorController : Controller
    {
        private readonly IInvestorService _investorService;

        public InvestorController(IInvestorService investorService)
        {
                _investorService = investorService;
        }

        [HttpGet]

        public ActionResult GetInvestors() {
            var investor = _investorService.GetInvestors();
            return Ok(investor);
        }

        [HttpGet("{id}")]
        public  ActionResult GetInvestor(int id)
        {
            var investor = _investorService.GetInvestorById(id);

            if (investor == null)
            {
                return NotFound();
            }

            return Ok(investor);
        }

    }
}