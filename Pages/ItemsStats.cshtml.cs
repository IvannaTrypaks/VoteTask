using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VoteTask.Models;

namespace VoteTask.Pages
{
    public class ItemsStatsModel : PageModel
    {
        private readonly VoteContext _db;

        public IEnumerable<Item> Items { get; set; }
        public ItemsStatsModel(VoteContext db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }

        public void OnGet()
        {
            Items = _db.Items.OrderBy(i => i.Volume);
        }
    }
}
