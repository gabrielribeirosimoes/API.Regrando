using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using regrando.API.Data;
using regrando.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace regrando.API.Controllers
{
    [Route("api/Alimento")]
    [ApiController]
    public class AlimentoController : ControllerBase
    {
        private readonly DataContext _context;

        public AlimentoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Alimento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alimento>>> Get()
        {
            return await _context.TB_ALIMENTO.ToListAsync();
        }

        // GET: api/Alimento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alimento>> Get(int id)
        {
            var alimento = await _context.TB_ALIMENTO.FindAsync(id);

            if (alimento == null)
            {
                return NotFound();
            }

            return alimento;
        }

        // POST: api/Alimento
        [HttpPost]
        public async Task<ActionResult<Alimento>> Post(Alimento alimento)
        {
            _context.TB_ALIMENTO.Add(alimento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = alimento.IdAlimento }, alimento);
        }

        // PUT: api/Alimento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Alimento alimento)
        {
            if (id != alimento.IdAlimento)
            {
                return BadRequest();
            }

            _context.Entry(alimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlimentoExists(id))
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

        // DELETE: api/Alimento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var alimento = await _context.TB_ALIMENTO.FindAsync(id);
            if (alimento == null)
            {
                return NotFound();
            }

            _context.TB_ALIMENTO.Remove(alimento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlimentoExists(int id)
        {
            return _context.TB_ALIMENTO.Any(e => e.IdAlimento == id);
        }
    }
}
