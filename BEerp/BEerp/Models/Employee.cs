using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BEerp.Models
{
    public class Employee
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string surname { get; set; }
        [Required]
        public int salary { get; set; }
        [Required]
        public string user { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public bool isAdmin { get; set; }
        [Required]
        public ICollection<Order> Orders { get; set; }
    }
}
