using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BEerp.Models
{
    public class Customer
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string surname { get; set; }
        [Required]
        public string dni { get; set; }
        [Required]
        public ICollection<Order> Orders { get; set; }
    }
}
