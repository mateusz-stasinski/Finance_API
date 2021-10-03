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
    [Route("phinancemanager/paymentcategory")]
    public class PaymentCategoryController : ControllerBase
    {
        private readonly PhinanceManagerDbContext _context;
        public PaymentCategoryController (PhinanceManagerDbContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public ActionResult<PaymentCategory> AddPaymentCategory([FromBody] AddPaymentCategoryRequest request)
        {
            PaymentCategory newPaymentCategory = new PaymentCategory();
            newPaymentCategory.NewPaymentCategory(request);

            _context.Add(newPaymentCategory);
            _context.SaveChanges();
            return Ok();
        }
    }
}
