using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using ProjAndreVeiculosSummary.BankAPI.Services;

namespace ProjAndreVeiculosSummary.BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly BankService bankService;

        public BankController(BankService bankService)
        {
            this.bankService = bankService;
        }

        [HttpGet]
        public ActionResult<List<Bank>> Get()
        {
            return bankService.GetBanks();
        }

        [HttpPost]
        public ActionResult<Bank> PostBanks(Bank bank)
        {
            bankService.Create(bank);

            return Ok(bank);
        }
    }
}
