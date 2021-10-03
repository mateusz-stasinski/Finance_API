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
    [Route("phinancemanager/people")]
    public class PeopleController : ControllerBase
    {
        private readonly PhinanceManagerDbContext _context;

        public PeopleController(PhinanceManagerDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void PrintInConsole()
        {
            Console.WriteLine("I am listening for your requests");
        }

        [HttpPost("add")]
        public ActionResult<People> AddPeople([FromBody] AddPeopleRequest request)
        {
            var newPeople = new People();
            newPeople.NewPeople(request);
            
            _context.Add(newPeople);
            _context.SaveChanges();
            return Ok();
        }
    }
}
