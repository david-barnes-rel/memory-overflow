using MemoryOverflow.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ICollection<Answer> Answers { get; set; }
    }
}
