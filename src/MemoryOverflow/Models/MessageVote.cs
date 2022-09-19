using System.ComponentModel.DataAnnotations;

namespace MemoryOverflow.Models
{
    public class MessageVote
    {
        [Required]
        public int Vote { get; set; }
    }
}
