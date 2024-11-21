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
    public class EnergyConsumptionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EnergyConsumptionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EnergyConsumptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnergyConsumption>>> GetEnergyConsumptions()
        {
            return await _context.EnergyConsumptions.ToListAsync();
        }

        // GET: api/EnergyConsumptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnergyConsumption>> GetEnergyConsumption(int id)
        {
            var energyConsumption = await _context.EnergyConsumptions.FindAsync(id);

            if (energyConsumption == null)
            {
                return NotFound();
            }

            return energyConsumption;
        }

        // PUT: api/EnergyConsumptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnergyConsumption(int id, EnergyConsumption energyConsumption)
        {
            if (id != energyConsumption.Id)
            {
                return BadRequest();
            }

            _context.Entry(energyConsumption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnergyConsumptionExists(id))
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

        // POST: api/EnergyConsumptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnergyConsumption>> PostEnergyConsumption(EnergyConsumption energyConsumption)
        {
            _context.EnergyConsumptions.Add(energyConsumption);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnergyConsumption", new { id = energyConsumption.Id }, energyConsumption);
        }

        // DELETE: api/EnergyConsumptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnergyConsumption(int id)
        {
            var energyConsumption = await _context.EnergyConsumptions.FindAsync(id);
            if (energyConsumption == null)
            {
                return NotFound();
            }

            _context.EnergyConsumptions.Remove(energyConsumption);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnergyConsumptionExists(int id)
        {
            return _context.EnergyConsumptions.Any(e => e.Id == id);
        }
    }
}
