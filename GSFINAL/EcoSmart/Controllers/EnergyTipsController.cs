using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoSmart.Data;
using EcoSmart.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoSmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergyTipsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EnergyTipsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EnergyTips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnergyTip>>> GetEnergyTips()
        {
            return await _context.EnergyTips.ToListAsync();
        }

        // GET: api/EnergyTips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnergyTip>> GetEnergyTip(int id)
        {
            var energyTip = await _context.EnergyTips.FindAsync(id);

            if (energyTip == null)
            {
                return NotFound();
            }

            return energyTip;
        }

        // PUT: api/EnergyTips/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnergyTip(int id, EnergyTip energyTip)
        {
            if (id != energyTip.Id)
            {
                return BadRequest();
            }

            _context.Entry(energyTip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnergyTipExists(id))
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

        // POST: api/EnergyTips
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnergyTip>> PostEnergyTip(EnergyTip energyTip)
        {
            _context.EnergyTips.Add(energyTip);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnergyTip", new { id = energyTip.Id }, energyTip);
        }

        // DELETE: api/EnergyTips/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnergyTip(int id)
        {
            var energyTip = await _context.EnergyTips.FindAsync(id);
            if (energyTip == null)
            {
                return NotFound();
            }

            _context.EnergyTips.Remove(energyTip);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnergyTipExists(int id)
        {
            return _context.EnergyTips.Any(e => e.Id == id);
        }
    }
}
