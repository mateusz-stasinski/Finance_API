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
    [Route("api/senders")]
    public class SenderController : ControllerBase
    {
        private readonly FinanceManagerDbContext _context;
        public SenderController (FinanceManagerDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Sender>> AddSender([FromBody] AddSenderRequest request)
        {
            var newSender = new Sender();
            newSender.AddNewSender(request.SenderName);

            _context.Add(newSender);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetSenderById([FromQuery] int id)
        {
            var sender = await _context.Sender.SingleAsync(s => s.SenderId == id);
            return Ok(sender);
        }
    }
}
