using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Models
{
    public class Commitment
    {
        [Key]

        public int Id { get; set; }
        [Required]
        public string? AssetClass { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string? Currency { get; set; }

        public int InvestorId { get; set; }
    }
}
