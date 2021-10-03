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
    [Route("phinancemanager/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly PhinanceManagerDbContext _context;
        public PaymentController (PhinanceManagerDbContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public ActionResult<Payment> AddPayment([FromBody] AddPaymentRequest request)
        {
            Payment newPaymant = new Payment();
            newPaymant.NewPayment(request);

            _context.Add(newPaymant);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("getbydate")]
        public ActionResult<List<Payment>> GetPaymentsByDate([FromBody] GetPaymentsByDateRequest request)
        {
            List<Payment> PaymentsByDate = _context.Payment.Where(p => p.PaymentDate >= request.FromDate
                && p.PaymentDate <= request.ToDate).ToList();

            return Ok(PaymentsByDate);
        }
    }
}
