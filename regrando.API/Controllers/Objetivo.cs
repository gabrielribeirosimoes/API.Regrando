using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using regrando.API.Data;
using regrando.API.Models;
using regrando.API.Models.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace regrando.API.Controllers
{
    [Route("/Objetivo")]
    [ApiController]
    public class ObjetivoController : ControllerBase
    {
        private readonly DataContext _context;

        public ObjetivoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Objetivo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Objetivo>>> Get()
        {
            return await _context.TB_OBJETIVO.ToListAsync();
        }

        // GET: api/Objetivo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Objetivo>> Get(int id)
        {
            var objetivo = await _context.TB_OBJETIVO.FindAsync(id);

            if (objetivo == null)
            {
                return NotFound();
            }

            return objetivo;
        }

        // GET: api/Objetivo/Tipos
        [HttpGet("Tipos")]
        public ActionResult<IEnumerable<string>> GetTiposObjetivo()
        {
            var tipos = Enum.GetNames(typeof(TipoObjetivo)).ToList();
            return tipos;
        }

        // POST: api/Objetivo
        [HttpPost]
        public async Task<ActionResult<Objetivo>> Post(Objetivo objetivo)
        {
            _context.TB_OBJETIVO.Add(objetivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = objetivo.IdObjetivo }, objetivo);
        }

        // PUT: api/Objetivo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Objetivo objetivo)
        {
            if (id != objetivo.IdObjetivo)
            {
                return BadRequest();
            }

            _context.Entry(objetivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjetivoExists(id))
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

        // DELETE: api/Objetivo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var objetivo = await _context.TB_OBJETIVO.FindAsync(id);
            if (objetivo == null)
            {
                return NotFound();
            }

            _context.TB_OBJETIVO.Remove(objetivo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObjetivoExists(int id)
        {
            return _context.TB_OBJETIVO.Any(e => e.IdObjetivo == id);
        }
    }
}
