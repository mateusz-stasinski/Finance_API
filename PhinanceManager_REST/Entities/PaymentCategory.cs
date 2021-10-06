using PhinanceManager_REST.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhinanceManager_REST.Entities
{
    public class PaymentCategory
    {
        [Key]
        public int PaymentCategoryId { get; set; }
        public string PaymentCategoryName { get; set; }

        [InverseProperty("PaymentCategory")]
        public virtual ICollection<Payment> Payment { get; set; }

        public void AddNewPaymentCategory(string paymentCategoryName)
        {
            PaymentCategoryName = paymentCategoryName;
        }
    }
}
