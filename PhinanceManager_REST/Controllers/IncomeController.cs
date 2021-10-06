using Microsoft.AspNetCore.Mvc;
using PhinanceManager_REST.Entities;
using PhinanceManager_REST.FinanceManagerContext;
using PhinanceManager_REST.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<Income>> AddIncome([FromBody] AddIncomeRequest request)
        {
            var newIncome = new Income();
            newIncome.AddNewIncome(request.IncomeAmount, request.IncomeDate, request.PeopleId, request.SenderId, request.IncomeCategoryId);

            _context.Add(newIncome);

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("date")]
        public async Task<ActionResult<List<Income>>> GetIncomesByDate([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            var incomesByDate = await _context.Income.Where(i => i.IncomeDate >= from
                && i.IncomeDate <= to).ToListAsync();

            return Ok(incomesByDate);
        }
    }
}
