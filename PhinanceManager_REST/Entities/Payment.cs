using PhinanceManager_REST.Requests;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public virtual Reciepent Recipient { get; set; }

        public void AddNewPayment(double paymentAmount, int paymentCategoryId, DateTime paymentDate, 
            int peopleId, int reciepentId)
        {
            PaymentId = new Guid();
            PaymentAmount = paymentAmount;
            PaymentDate = paymentDate;
            PeopleId = peopleId;
            PaymentCategoryId = paymentCategoryId;
            ReciepentId = reciepentId;
        }
    }
}
