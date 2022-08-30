using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VoteTask.Models;

namespace VoteTask.Pages
{
    public class VoteModel : PageModel
    {
        private readonly VoteContext _db;
        [BindProperty]
        public IEnumerable<Item> Items { get; set; }
        [BindProperty]
        public List<int> ItemsIds { get; set; }
        public VoteModel(VoteContext db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }
        public void OnGet()
        {
            Items = _db.Items.Where(v => v.VoterId != 1).Where(s => s.VoteState == "Approved");
        }

        public async Task<IActionResult> OnVotePost()
        {
            foreach (var ids in ItemsIds)
            {
                var items = await _db.Items.FindAsync(ItemsIds);
                items.Volume += 1;
                await _db.SaveChangesAsync();
            }
            return Page();
        }
    }
}
