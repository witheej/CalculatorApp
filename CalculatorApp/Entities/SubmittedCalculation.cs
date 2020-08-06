using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorApp.Entities
{
    public class SubmittedCalculation
    {
        [Key]
        public long SubmittedCalculationId { get; set; }
        [Required]
        [ForeignKey("IdentityUser")]
        public string UserId { get; set; }
        public string Expression { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public IdentityUser IdentityUser { get; set; }

    }
}
