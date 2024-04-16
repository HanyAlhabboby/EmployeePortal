using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EmployeePortal.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }


        public virtual ICollection<TimeOffWork>? TimeOffWorks { get; set; }


    }
}
