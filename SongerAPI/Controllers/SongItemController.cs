using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SongerAPI.Models;

namespace SongerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongItemController : ControllerBase
    {
        private readonly SongItemContext _context;

        public SongItemController(SongItemContext context)
        {
            _context = context;
        }

        // GET: api/SongItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongItem>>> GetSongItems()
        {
            return await _context.SongItems.ToListAsync();
        }

        // GET: api/SongItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongItem>> GetSongItem(int id)
        {
            var songItem = await _context.SongItems.FindAsync(id);

            if (songItem == null)
            {
                return NotFound();
            }

            return songItem;
        }

        // PUT: api/SongItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongItem(int id, SongItem songItem)
        {
            if (id != songItem.SongId)
            {
                return BadRequest();
            }

            _context.Entry(songItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SongItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SongItem>> PostSongItem(SongItem songItem)
        {
            _context.SongItems.Add(songItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSongItem", new { id = songItem.SongId }, songItem);
        }

        // DELETE: api/SongItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSongItem(int id)
        {
            var songItem = await _context.SongItems.FindAsync(id);
            if (songItem == null)
            {
                return NotFound();
            }

            _context.SongItems.Remove(songItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongItemExists(int id)
        {
            return _context.SongItems.Any(e => e.SongId == id);
        }
    }
}
