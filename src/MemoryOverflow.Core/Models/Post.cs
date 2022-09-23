
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoryOverflow.Data.Models;

namespace MemoryOverflow.Core.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Question { get; set; }
        public int VoteCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public User User { get; set; }
        public ICollection<PostAnswer> Answers { get; set; } = new List<PostAnswer>();
        public ICollection<PostComment> Comments { get; set; } = new List<PostComment>();
    }

    public class PostComment
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;
        public User? User { get; set; }
    }

    public class AnswerComment
    {
        public Guid Id { get; set; }
        public Guid AnswerId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;
        public User? User { get; set; }
    }


    public class PostAnswer
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public int VoteCount { get; set; }
        public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;
        public User? User { get; set; }
        public ICollection<AnswerComment> Comments { get; set; } = new List<AnswerComment>();
    }

    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;
    }
}
