using Microsoft.EntityFrameworkCore;

namespace MyQuestAPI.Models
{
    public class MyQuestContext : DbContext
    {
        public MyQuestContext(DbContextOptions<MyQuestContext> options) : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasMany(q => q.Options)
                .WithOne()
                .HasForeignKey(a => a.QuestionId);   
        }
    }
}
