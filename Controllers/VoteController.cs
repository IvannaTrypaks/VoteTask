using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VoteTask.Models;

namespace VoteTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly VoteContext _Context;

        public VoteController(VoteContext context)
        {
            _Context = context;
            _Context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult> GetItems()
        {
            return Ok(await _Context.Items.ToArrayAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetItem(int id)
        {
            var item = await _Context.Items.FindAsync(id);

            return (item == null) ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            await _Context.Items.AddAsync(item);
            await _Context.SaveChangesAsync();

            return CreatedAtAction(
                "GetItem",
                new { id = item.Id },
                item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Item>> PutItem(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _Context.Entry(item).State = EntityState.Modified;
            try
            {
                await _Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_Context.Items.Any(p => p.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                };
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> DeleteItem(int id)
        {
            var item = await _Context.Items.FindAsync(id);

            if (id != item.Id)
            {
                return BadRequest();
            }

            _Context.Items.Remove(item);
            _Context.SaveChangesAsync();

            return item;
        }



    }
}
