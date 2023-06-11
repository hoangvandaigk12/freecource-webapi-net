using System.ComponentModel.DataAnnotations;

namespace MyWebApilApp.Models
{
    public class ComputerModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string? Status { get; set; }
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
