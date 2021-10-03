using PhinanceManager_REST.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhinanceManager_REST.Entities
{
    public class People
    {
        [Key]
        public int PeopleId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [InverseProperty("People")]
        public virtual ICollection<Income> Income { get; set; }

        [InverseProperty("People")]
        public virtual ICollection<Payment> Payment { get; set; }

        public void AddNewPeople(AddPeopleRequest request)
        {
            //People newPeople = new People();
            Name = request.Name;
            Surname = request.Surname;
            //return newPeople;
        }
    }
}
