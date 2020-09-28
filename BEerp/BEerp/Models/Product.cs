using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BEerp.Models
{
    public class Product
    {
        public int id { get; set; }
        [Required]
        public float price { get; set; }
        [Required]
        public float ivaPrice { get; set; }
        [Required]
        public string category { get; set; }
    }
}
