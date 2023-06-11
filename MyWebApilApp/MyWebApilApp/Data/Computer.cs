using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApilApp.Data
{
    [Table("Computer")]
    public class Computer : BaseEntity
    {
        [MaxLength(100)]
        public string? ComputerName { get; set; }
        [MaxLength(2000)]
        public string? Description { get; set; }
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Range(0, 100)]
        public int Quantity { get; set; }
    }
}
