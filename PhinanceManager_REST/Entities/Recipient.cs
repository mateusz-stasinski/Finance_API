using PhinanceManager_REST.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhinanceManager_REST.Entities
{
    public class Recipient
    {
        [Key]
        public int RecipientId { get; set; }
        public string RecipientName { get; set; }

        [InverseProperty("Recipient")]
        public virtual ICollection<Payment> Payment { get; set; }

        public void AddNewRecipient(string recipientName)
        {
            RecipientName = recipientName;
        }
    }
}
