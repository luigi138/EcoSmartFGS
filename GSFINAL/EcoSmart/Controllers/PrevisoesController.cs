using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcoSmart.Models;
using EcoSmart.Data;

namespace EcoSmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrevisoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PrevisoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Previsoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Previsao>>> GetPrevisoes()
        {
            return await _context.Previsoes
                .Include(p => p.Device)
                .Include(p => p.User)
                .ToListAsync();
        }

        // GET: api/Previsoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Previsao>> GetPrevisao(int id)
        {
            var previsao = await _context.Previsoes
                .Include(p => p.Device)
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (previsao == null)
            {
                return NotFound();
            }

            return previsao;
        }

        // GET: api/Previsoes/Device/5
        [HttpGet("Device/{deviceId}")]
        public async Task<ActionResult<IEnumerable<Previsao>>> GetPrevisoesPorDevice(int deviceId)
        {
            return await _context.Previsoes
                .Where(p => p.DeviceId == deviceId)
                .Include(p => p.Device)
                .OrderByDescending(p => p.DataPrevisao)
                .ToListAsync();
        }

        // POST: api/Previsoes
        [HttpPost]
        public async Task<ActionResult<Previsao>> PostPrevisao(Previsao previsao)
        {
            _context.Previsoes.Add(previsao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrevisao", new { id = previsao.Id }, previsao);
        }

        // PUT: api/Previsoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrevisao(int id, Previsao previsao)
        {
            if (id != previsao.Id)
            {
                return BadRequest();
            }

            _context.Entry(previsao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrevisaoExists(id))
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

        // DELETE: api/Previsoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrevisao(int id)
        {
            var previsao = await _context.Previsoes.FindAsync(id);
            if (previsao == null)
            {
                return NotFound();
            }

            _context.Previsoes.Remove(previsao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrevisaoExists(int id)
        {
            return _context.Previsoes.Any(e => e.Id == id);
        }
    }
}