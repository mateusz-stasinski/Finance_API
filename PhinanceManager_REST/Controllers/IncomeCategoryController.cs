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
    [Route("phinancemanager/incomecategory")]
    public class IncomeCategoryController : ControllerBase
    {
        private readonly PhinanceManagerDbContext _context;

        public IncomeCategoryController(PhinanceManagerDbContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public ActionResult<IncomeCategory> AddIncomeCategory([FromBody] AddIncomeCategoryRequest request)
        {
            var newIncomeCategory = new IncomeCategory();

            newIncomeCategory.NewIncomeCategory(request);

            _context.Add(newIncomeCategory);
            _context.SaveChanges();
            return Ok();
        }
    }
}
