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
    [Route("phinancemanager/sender")]
    public class SenderController : ControllerBase
    {
        private readonly FinanceManagerDbContext _context;
        public SenderController (FinanceManagerDbContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public ActionResult<Sender> AddSender([FromBody] AddSenderRequest request)
        {
            Sender newSender = new Sender();
            //Refactor this same as PaymentController
            newSender.AddNewSender(request);

            _context.Add(newSender);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("getbyid")]
        public ActionResult GetSenderById([FromQuery] int id)
        {
            var sender = _context.Sender.Single(s => s.SenderId == id);
            return Ok(sender);
        }
    }
}
