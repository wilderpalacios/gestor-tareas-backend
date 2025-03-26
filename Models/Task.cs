using System.ComponentModel.DataAnnotations;

namespace APIGestorTareas.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string? Description { get; set; }
        [Required]
        public string Status { get; set; } = "pendiente";

    }
}
