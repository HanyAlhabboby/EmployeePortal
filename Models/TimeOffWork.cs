using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeePortal.Models
{
    public class TimeOffWork
    {
        public int TimeOffWorkId { get; set; }

        [ValidateNever]
        public string ?TimeOffWorkType { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [ForeignKey("Employee")]
        public int FkEmployeeId { get; set; }
        
        public Employee? Employee { get; set; }
    }
}
