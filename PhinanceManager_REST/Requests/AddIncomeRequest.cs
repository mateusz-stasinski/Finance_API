using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhinanceManager_REST.Requests
{
    public class AddIncomeRequest
    {
        public double IncomeAmount { get; set; }
        public DateTime IncomeDate { get; set; }
        public int PeopleId { get; set; }
        public int SenderId { get; set; }
        public int IncomeCategoryId { get; set; }
    }
}
