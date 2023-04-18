using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Modules
{
    // Tao bang Product
    [Table("Product")]
    internal class Product
    {
        [Key] // Thiet lap ProductId la khoa chinh 
        public int ProductId { get; set; }
        [Required] // NOT NULL
        [StringLength(50)] // NVARCHAR(50)
        public string ProductName { get; set; }
        [StringLength(50)] // NVARCHAR(50)
        public string Provider { get; set; }
        public void PrintInfo() => Console.WriteLine($"{ProductId} - {ProductName} - {Provider}");
    }
}
