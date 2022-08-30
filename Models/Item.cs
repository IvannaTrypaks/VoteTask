using System.Text.Json.Serialization;

namespace VoteTask.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Volume { get; set; }
        public DateTime Date { get; set; }
        [JsonIgnore]
        public virtual Voter? Voter { get; set; }
        public string? VoteState { get; set; }
        public int VoterId { get; set; }
    }
}
