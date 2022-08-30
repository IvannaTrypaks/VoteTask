using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VoteTask.Models;

namespace VoteTask.Pages
{
    public class CreateItemModel : PageModel
    {
        private readonly VoteContext _db;

        [BindProperty]
        public Item Item { get; set; }
        public CreateItemModel(VoteContext db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Item.Date = DateTime.Now;
                Item.VoteState = "New";
                Item.VoterId = 1;

                _db.Items.Add(Item);

                await _db.SaveChangesAsync();
                return RedirectToPage("ItemsStats");
            }
            return Page();
        }
    }
}
