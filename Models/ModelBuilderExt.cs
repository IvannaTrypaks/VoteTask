using Microsoft.EntityFrameworkCore;

namespace VoteTask.Models
{
    public static class ModelBuilderExt
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Voter>().HasData(
                new Voter { Id = 1, Username = "IvannaTr", Name = "Ivanna" },
                new Voter { Id = 2, Username = "KattyV", Name = "Kate" },
                new Voter { Id = 3, Username = "Pigeon", Name = "Nancy" }
                );
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "Wonder Woman", Volume = 0, Date = new DateTime(2022, 07, 20), VoterId = 1, VoteState="Approved" },
                new Item { Id = 2, Name = "Iron Man", Volume = 0, Date = new DateTime(2022, 07, 20), VoterId = 1, VoteState = "Rejected" },
                new Item { Id = 3, Name = "Iron Man 2", Volume = 0, Date = new DateTime(2022, 07, 22), VoterId = 2, VoteState = "Approved" },
                new Item { Id = 4, Name = "Avengers", Volume = 0, Date = new DateTime(2022, 07, 22), VoterId = 2, VoteState = "Approved" },
                new Item { Id = 5, Name = "SpiderMan", Volume = 0, Date = new DateTime(2022, 07, 22), VoterId = 2, VoteState = "Approved" },
                new Item { Id = 6, Name = "Doctor Strange", Volume = 0, Date = new DateTime(2022, 07, 23), VoterId = 3, VoteState = "Approved" },
                new Item { Id = 7, Name = "Black Widow", Volume = 0, Date = new DateTime(2022, 07, 23), VoterId = 3, VoteState = "Rejected" });
        }
    }
}
