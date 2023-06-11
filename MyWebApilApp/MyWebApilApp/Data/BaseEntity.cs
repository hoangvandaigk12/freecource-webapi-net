using System.ComponentModel.DataAnnotations;

namespace MyWebApilApp.Data
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string? Status { get; set; }
    }
}
