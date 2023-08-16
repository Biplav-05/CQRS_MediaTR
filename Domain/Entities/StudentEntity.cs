using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class StudentEntity
    {
        [Key]
        public Guid id { get; set; } 
        public string? name { get; set; }
        public string? email { get; set; }
        public string? address { get; set; }
    }
}
