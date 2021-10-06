using Microsoft.AspNetCore.Mvc;
using PhinanceManager_REST.Entities;
using PhinanceManager_REST.FinanceManagerContext;
using PhinanceManager_REST.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhinanceManager_REST.Controllers
{
    [ApiController]
    [Route("api/incomes")]
    public class IncomeController : ControllerBase
    {
        private readonly FinanceManagerDbContext _context;
        public IncomeController(FinanceManagerDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Income> AddIncome([FromBody] AddIncomeRequest request)
        {
            var newIncome = new Income();
            newIncome.AddNewIncome(request.IncomeAmount, request.IncomeDate, request.PeopleId, request.SenderId, request.IncomeCategoryId);

            _context.Add(newIncome);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("date")]
        public ActionResult<List<Income>> GetIncomesByDate([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            var incomesByDate = _context.Income.Where(i => i.IncomeDate >= from
                && i.IncomeDate <= to).ToList();
            return Ok(incomesByDate);
        }
    }
}
