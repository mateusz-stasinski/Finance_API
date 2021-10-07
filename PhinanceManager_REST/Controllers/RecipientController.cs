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
    [Route("api/recipients")]
    public class RecipientController : ControllerBase
    {
        private readonly FinanceManagerDbContext _context; 
        public RecipientController (FinanceManagerDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Recipient> AddRecipient([FromBody] AddRecipientRequest request)
        {
            var newRecipient = new Recipient();
            newRecipient.AddNewRecipient(request.RecipientName);

            _context.Add(newRecipient);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetRecipientById([FromQuery] int id)
        {
            var recipient = await _context.Recipient.Where(r => r.RecipientId == id).ToListAsync();
            return Ok(recipient);
        }
    }
}
