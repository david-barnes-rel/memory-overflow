using System.ComponentModel.DataAnnotations;

namespace MemoryOverflow.Models
{
    public class SlimPost
    {
        public Guid? Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
