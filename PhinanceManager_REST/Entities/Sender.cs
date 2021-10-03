using PhinanceManager_REST.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhinanceManager_REST.Entities
{
    public class Sender
    {
        [Key]
        public int SenderId { get; set; }
        public string SenderName { get; set; }

        [InverseProperty("Sender")]
        public virtual ICollection<Income> Income { get; set; }

        public void NewSender(AddSenderRequest request)
        {
            SenderName = request.SenderName;
        }
    }
}
