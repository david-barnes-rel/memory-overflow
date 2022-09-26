using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryOverflow.Data.Models.Telemetry
{
    [Table(nameof(PostTelemetry))]
    public class PostTelemetry
    {
        [Key]
        public Guid PostId { get; set; }
        [Required]
        public int TitleLength { get; set; }
        [Required]
        public int QuestionLength { get; set; }
    }

    [Table(nameof(AnswerTelemetry))]
    public class AnswerTelemetry
    {
        [Key]
        public Guid AnswerId { get; set; }
        [Required]
        public int AnswerLength { get; set; }
    }

    [Table(nameof(CommentTelemetry))]
    public class CommentTelemetry
    {
        [Key]
        public Guid CommentId { get; set; }
        [Required]
        public int CommentLength { get; set; }
    }
}
