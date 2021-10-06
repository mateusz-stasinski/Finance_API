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
        public int RecipientId { get; set; }

        [ForeignKey(nameof(PeopleId))]
        [InverseProperty("Payment")]
        public virtual People People { get; set; }

        [ForeignKey(nameof(PaymentCategoryId))]
        [InverseProperty("Payment")]
        public virtual PaymentCategory PaymentCategory { get; set; }

        [ForeignKey(nameof(RecipientId))]
        [InverseProperty("Payment")]
        public virtual Recipient Recipient { get; set; }

        public void AddNewPayment(double paymentAmount, DateTime paymentDate, int peopleId, int paymentCategoryId, int recipientId)
        {
            PaymentId = new Guid();
            PaymentAmount = paymentAmount;
            PaymentDate = paymentDate;
            PeopleId = peopleId;
            PaymentCategoryId = paymentCategoryId;
            RecipientId = recipientId;
        }
    }
}
