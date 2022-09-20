using MemoryOverflow.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryOverflow.Core
{
    public static class Register
    {
        public static void SetupLibrary(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(config.GetConnectionString("AppDb")));
            services.AddAutoMapper(typeof(Register));
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IAnswerService, AnswerService>();
            
        }

        public static void Migrate(ServiceProvider provider)
        {
            var dbContext = provider.GetRequiredService<ApplicationDbContext>();

            dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();

            if (!dbContext.Users.Any())
            {
                dbContext.Users.Add(new MemoryOverflow.Data.Models.User
                {
                    Name = "user 1"
                });

                dbContext.Users.Add(new MemoryOverflow.Data.Models.User
                {
                    Name = "user 2"
                });

                dbContext.SaveChanges();
            }

            if (!dbContext.Posts.Any())
            {
                dbContext.Posts.Add(new Data.Models.Post
                {
                    Title = "fake post",
                    Question = "Well do I have a question for you",
                    VoteCount = 0,
                    UserId = dbContext.Users.First().Id
                });
            }

            dbContext.SaveChanges();
        }
    }
}
