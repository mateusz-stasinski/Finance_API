using PhinanceManager_REST.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhinanceManager_REST.Entities
{
    public class Payment
    {
        [Key]
        public Guid PaymentId { get; set; }
        public double PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PeopleId { get; set; }
        public int PaymentCategoryId { get; set; }
        public int ReciepentId { get; set; }

        [ForeignKey(nameof(PeopleId))]
        [InverseProperty("Payment")]
        public virtual People People { get; set; }

        [ForeignKey(nameof(PaymentCategoryId))]
        [InverseProperty("Payment")]
        public virtual PaymentCategory PaymentCategory { get; set; }

        [ForeignKey(nameof(ReciepentId))]
        [InverseProperty("Payment")]
        public virtual Reciepent Reciepent { get; set; }

        public void NewPayment(AddPaymentRequest request)
        {
            PaymentId = new Guid();
            PaymentAmount = request.PaymentAmount;
            PaymentDate = request.PaymentDate;
            PeopleId = request.PeopleId;
            PaymentCategoryId = request.PaymentCategoryId;
            ReciepentId = request.ReciepentId;
        }
    }
}
