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
    //Refactor this same as PaymentController
    [Route("api/recipients")]
    public class RecipientController : ControllerBase
    {
        private readonly FinanceManagerDbContext _context; 
        public RecipientController (FinanceManagerDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Reciepent> AddReciepent([FromBody] AddReciepentRequest request)
        {
            Reciepent newReciepent = new Reciepent();

            //Refactor this same as PaymentController
            newReciepent.AddNewReciepent(request);
            _context.Add(newReciepent);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult GetReciepentById([FromQuery] int id)
        {
            var reciepent = _context.Reciepent.Where(r => r.ReciepentId == id);
            return Ok(reciepent);
        }
    }
}
