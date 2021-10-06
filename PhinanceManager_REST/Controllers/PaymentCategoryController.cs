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
    [Route("api/payments/categories")]
    public class PaymentCategoryController : ControllerBase
    {
        private readonly FinanceManagerDbContext _context;
        public PaymentCategoryController (FinanceManagerDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<PaymentCategory> AddPaymentCategory([FromBody] AddPaymentCategoryRequest request)
        {
            var newPaymentCategory = new PaymentCategory();
            newPaymentCategory.AddNewPaymentCategory(request.PaymentCategoryName);

            _context.Add(newPaymentCategory);
            _context.SaveChanges();
            return Ok();
        }
    }
}
