using Microsoft.EntityFrameworkCore;

namespace VoteTask.Models
{
    public class VoteContext : DbContext
    {
        public VoteContext(DbContextOptions<VoteContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                    .HasOne(a => a.Voter)
                    .WithMany()
                    .HasForeignKey(b => b.VoterId);

            modelBuilder.Seed();
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Voter> Voters { get; set; }
    }

    
}
