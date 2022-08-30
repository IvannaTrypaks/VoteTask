using ServiceStack.DataAnnotations;

namespace VoteTask.Models
{
    public class Voter
    {
        public int Id { get; set; }
        [Unique]
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
