using PhinanceManager_REST.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhinanceManager_REST.Entities
{
    public class Income
    {
        [Key]
        public Guid IncomeId { get; set; }
        public double IncomeAmount { get; set; }
        public DateTime IncomeDate { get; set; }
        public int PeopleId { get; set; }
        public int SenderId { get; set; }
        public int IncomeCategoryId { get; set; }

        [ForeignKey(nameof(PeopleId))]
        [InverseProperty("Income")]
        public virtual People People { get; set; }

        [ForeignKey(nameof(SenderId))]
        [InverseProperty("Income")]
        public virtual Sender Sender { get; set; }

        [ForeignKey(nameof(IncomeCategoryId))]
        [InverseProperty("Income")]
        public virtual IncomeCategory IncomeCategory { get; set; }

        public void AddNewIncome(double incomeAmount, DateTime incomeDate, int peopleId, int senderId, int incomeCategoryId)
        {
            IncomeId = new Guid();
            incomeAmount = IncomeAmount;
            incomeDate = IncomeDate;
            peopleId = PeopleId;
            senderId = SenderId;
            incomeCategoryId = IncomeCategoryId;
        }
    }
}
