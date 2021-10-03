using Microsoft.AspNetCore.Mvc;
using PhinanceManager_REST.Entities;
using PhinanceManager_REST.PhinanceManagerContext;
using PhinanceManager_REST.Requests;

namespace PhinanceManager_REST.Controllers
{
    [ApiController]
    //Could me moved to patments controller - payment categories are bounded to payments
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
            PaymentCategory newPaymentCategory = new PaymentCategory();
            newPaymentCategory.NewPaymentCategory(request);

            _context.Add(newPaymentCategory);
            _context.SaveChanges();
            return Ok();
        }
    }
}
