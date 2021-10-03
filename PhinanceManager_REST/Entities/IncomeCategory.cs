using PhinanceManager_REST.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhinanceManager_REST.Entities
{
    public class IncomeCategory
    {
        [Key]
        public int IncomeCategoryId { get; set; }
        public string IncomeCategoryName { get; set; }

        [InverseProperty("IncomeCategory")]
        public virtual ICollection<Income> Income { get; set; }

        public void NewIncomeCategory(AddIncomeCategoryRequest request)
        {
            IncomeCategoryName = request.IncomeCategoryName;
        }
    }
}
