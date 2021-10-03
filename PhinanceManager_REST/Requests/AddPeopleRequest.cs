using PhinanceManager_REST.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhinanceManager_REST.Requests
{
    public class AddPeopleRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
