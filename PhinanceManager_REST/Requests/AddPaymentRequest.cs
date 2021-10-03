using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhinanceManager_REST.Requests
{
    public class AddPaymentRequest
    {
        public double PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PeopleId { get; set; }
        public int PaymentCategoryId { get; set; }
        public int ReciepentId { get; set; }
    }
}
