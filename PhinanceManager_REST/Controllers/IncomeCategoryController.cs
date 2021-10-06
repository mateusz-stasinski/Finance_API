using Microsoft.AspNetCore.Mvc;
using PhinanceManager_REST.Entities;
using PhinanceManager_REST.FinanceManagerContext;
using PhinanceManager_REST.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager_REST.Controllers
{
    [ApiController]
    [Route("api/incomes/categories")]
    public class IncomeCategoryController : ControllerBase
    {
        private readonly FinanceManagerDbContext _context;

        public IncomeCategoryController(FinanceManagerDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<IncomeCategory>> AddIncomeCategory([FromBody] AddIncomeCategoryRequest request)
        {
            var newIncomeCategory = new IncomeCategory();

            newIncomeCategory.AddNewIncomeCategory(request.IncomeCategoryName);

            _context.Add(newIncomeCategory);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
