using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    [Route("api/payments")]
    public class PaymentController : ControllerBase
    {
        private readonly FinanceManagerDbContext _context;
        public PaymentController (FinanceManagerDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Payment>> AddPayment([FromBody] AddPaymentRequest request)
        {
            var newPaymant = new Payment();
            newPaymant.AddNewPayment(request.PaymentAmount, request.PaymentDate, request.PaymentCategoryId, 
                request.PeopleId, request.RecipientId);

            _context.Add(newPaymant);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("date")]
        public async Task<ActionResult<List<Payment>>> GetPaymentsByDate([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            var paymentsByDate = await _context.Payment.Where(p => p.PaymentDate >= from
                && p.PaymentDate <= to).ToListAsync();

            return Ok(paymentsByDate);
        }
    }
}
