using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryOverflow.Data.Models
{
    [Table(nameof(Post))]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [MaxLength(255)]
        public string Title { get; set; }
        public string Question { get; set; }
        public int VoteCount { get; set; }

        public DateTime CreatedDate { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey(nameof(Answer.PostId))]
        public virtual ICollection<Answer> Answers { get; set; }
    }

    [Table(nameof(Answer))]
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Post))]
        public Guid PostId { get; set; }
        
        public Post Post { get; set; }

        [MaxLength(255)]
        public string Title { get; set; }
        public int VoteCount { get; set; }

        public DateTime CreatedDate { get; set; }
        public Guid UserId { get; set; }
    }
}
