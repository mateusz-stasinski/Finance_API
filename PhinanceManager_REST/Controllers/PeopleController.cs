using Microsoft.AspNetCore.Mvc;
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
    [Route("api/people")]
    public class PeopleController : ControllerBase
    {
        private readonly FinanceManagerDbContext _context;

        public PeopleController(FinanceManagerDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<People>> AddPeople([FromBody] AddPeopleRequest request)
        {
            var newPeople = new People();
            newPeople.AddNewPeople(request.Name, request.Surname);
            
            _context.Add(newPeople);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
