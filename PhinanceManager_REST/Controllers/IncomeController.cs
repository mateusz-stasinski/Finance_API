using Microsoft.AspNetCore.Mvc;
using PhinanceManager_REST.Entities;
using PhinanceManager_REST.PhinanceManagerContext;
using PhinanceManager_REST.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhinanceManager_REST.Controllers
{
    [ApiController]
    [Route("phinancemanager/income")]
    public class IncomeController : ControllerBase
    {
        private readonly PhinanceManagerDbContext _context;
        public IncomeController (PhinanceManagerDbContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public ActionResult<Income> AddIncome([FromBody] AddIncomeRequest request)
        {
            Income newIncome = new Income();
            newIncome.NewIncome(request);

            _context.Add(newIncome);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("getbydate")]
        public ActionResult<List<Income>> GetIncomesByDate([FromBody] GetIncomesByDateRequest request)
        {
            List<Income> incomesByDate = _context.Income.Where(i => i.IncomeDate >= request.FromDate
                && i.IncomeDate <= request.ToDate).ToList();
            return Ok(incomesByDate);
        }
    }
}
