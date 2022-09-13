using MemoryOverflow.Data.Models;
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
    }
}
