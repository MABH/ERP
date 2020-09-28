using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BEerp.Models
{
    public enum Status
    {
        Pending, Processing, Distribution, Complet, Canceled
    }

    public class Order
    {
        public int id { get; set; }
        [Required]
        public Status status { get; set; }
        [Required]
        public string priority { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime creationDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime endDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime deliveryDate { get; set; }
        [Required]
        public string deliveryAddress { get; set; }
        [Required]
        public ICollection<Product> Products { get; set; }
        [Required]
        public Employee employee { get; set; }
        [Required]
        public Customer customer { get; set; }
        [Required]
        public int employeeId { get; set; }
        [Required]
        public int customerId { get; set; }
    }
}
