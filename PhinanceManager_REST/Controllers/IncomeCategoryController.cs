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
    [Route("api/incomecategories")]
    public class IncomeCategoryController : ControllerBase
    {
        private readonly FinanceManagerDbContext _context;

        public IncomeCategoryController(FinanceManagerDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<IncomeCategory> AddIncomeCategory([FromBody] AddIncomeCategoryRequest request)
        {
            var newIncomeCategory = new IncomeCategory();

            newIncomeCategory.AddNewIncomeCategory(request);

            _context.Add(newIncomeCategory);
            _context.SaveChanges();
            return Ok();
        }
    }
}
