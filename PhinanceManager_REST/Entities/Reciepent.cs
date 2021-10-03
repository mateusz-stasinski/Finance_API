using PhinanceManager_REST.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhinanceManager_REST.Entities
{
    public class Reciepent
    {
        [Key]
        public int ReciepentId { get; set; }
        public string ReciepentName { get; set; }

        [InverseProperty("Reciepent")]
        public virtual ICollection<Payment> Payment { get; set; }

        public void AddNewReciepent(AddReciepentRequest request)
        {
            ReciepentName = request.ReciepentName;
        }
    }
}
