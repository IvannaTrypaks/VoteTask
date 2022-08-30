using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VoteTask.Models;
using System.Linq;

namespace VoteTask.Pages
{
    public class MyItemsModel : PageModel
    {
        private readonly VoteContext _db;

        public IEnumerable<Item> Items { get; set; }
        public MyItemsModel(VoteContext db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }

        public void OnGet()
        {
            Items = _db.Items.Where(v => v.VoterId == 1);
           
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var item = await _db.Items.FindAsync(id);

            if (item != null)
            {
                _db.Items.Remove(item);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostApproveAsync(int id)
        {
            var item = await _db.Items.FindAsync(id);
            
            if (item != null)
            {
                item.VoteState = "Approved";
                await _db.SaveChangesAsync();
            }

            return RedirectToPage();

        }

        public async Task<IActionResult> OnPostRejectAsync(int id)
        {
            var item = await _db.Items.FindAsync(id);

            if (item != null)
            {
                item.VoteState = "Rejected";
                await _db.SaveChangesAsync();
            }

            return RedirectToPage();

        }
    }
}
