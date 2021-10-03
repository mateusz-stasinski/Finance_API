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
    [Route("phinancemanager/reciepent")]
    public class ReciepentController : ControllerBase
    {
        private readonly PhinanceManagerDbContext _context; 
        public ReciepentController (PhinanceManagerDbContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public ActionResult<Reciepent> AddReciepent([FromBody] AddReciepentRequest request)
        {
            Reciepent newReciepent = new Reciepent();
            newReciepent.NewReciepent(request);
            _context.Add(newReciepent);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("getbyid")]
        public ActionResult GetReciepentById([FromQuery] int id)
        {
            var reciepent = _context.Reciepent.Where(r => r.ReciepentId == id);
            return Ok(reciepent);
        }
    }
}
