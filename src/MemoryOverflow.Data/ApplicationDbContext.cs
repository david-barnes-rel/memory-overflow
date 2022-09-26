using MemoryOverflow.Data.Models;
using MemoryOverflow.Data.Models.Telemetry;
using Microsoft.EntityFrameworkCore;

namespace MemoryOverflow.Data
{

    public class ApplicationDbContext : DbContext
    {
        //Constructor with DbContextOptions and the context class itself
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        //Create the DataSet for the Employee         
        public DbSet<Post> Posts{ get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<AnswerComment> AnswerComments { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<PostTelemetry> PostTelemetry { get; set; }
        public DbSet<AnswerTelemetry> AnswerTelemetry { get; set; }
        public DbSet<CommentTelemetry> CommentTelemetry { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // I'm being extrodinarily lazy please never do something like this in production
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
        }
    }
    
}
