using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Models
{
    public class InvestorData
    {
        [Key]

        public int Id { get; set; }
        [Required]

        public string? Name { get; set; }
        [Required]

        public string? InvestorType { get; set; }
        [Required]

        public string? Country { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public ICollection<Commitment> Commitments { get; set; } = new List<Commitment>();
    }
}
