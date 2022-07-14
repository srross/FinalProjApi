//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using FinalProjApi.Data;
//using FinalProjApi.Models;

//namespace FinalProjApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OutfitAController : ControllerBase
//    {
//        private readonly FinalProjectDBContext _context;

//        public OutfitAController(FinalProjectDBContext context)
//        {
//            _context = context;
//        }

//        // GET: api/OutfitA
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<OutfitWeather>>> GetOutfits()
//        {
//          if (_context.Outfits == null)
//          {
//              return NotFound();
//          }
//            return await _context.Outfits.ToListAsync();
//        }

//        // GET: api/OutfitA/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<OutfitWeather>> GetOutfitWeather(int id)
//        {
//          if (_context.Outfits == null)
//          {
//              return NotFound();
//          }
//            var outfitWeather = await _context.Outfits.FindAsync(id);

//            if (outfitWeather == null)
//            {
//                return NotFound();
//            }

//            return outfitWeather;
//        }

//        // PUT: api/OutfitA/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutOutfitWeather(int id, OutfitWeather outfitWeather)
//        {
//            if (id != outfitWeather.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(outfitWeather).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!OutfitWeatherExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/OutfitA
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<OutfitWeather>> PostOutfitWeather(OutfitWeather outfitWeather)
//        {
//          if (_context.Outfits == null)
//          {
//              return Problem("Entity set 'FinalProjectDBContext.Outfits'  is null.");
//          }
//            _context.Outfits.Add(outfitWeather);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetOutfitWeather", new { id = outfitWeather.Id }, outfitWeather);
//        }

//        // DELETE: api/OutfitA/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteOutfitWeather(int id)
//        {
//            if (_context.Outfits == null)
//            {
//                return NotFound();
//            }
//            var outfitWeather = await _context.Outfits.FindAsync(id);
//            if (outfitWeather == null)
//            {
//                return NotFound();
//            }

//            _context.Outfits.Remove(outfitWeather);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool OutfitWeatherExists(int id)
//        {
//            return (_context.Outfits?.Any(e => e.Id == id)).GetValueOrDefault();
//        }
//    }
//}
