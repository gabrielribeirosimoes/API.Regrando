using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using regrando.API.Data;
using regrando.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace regrando.API.Controllers
{
    [Route("api/Receita")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private readonly DataContext _context;

        public ReceitaController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Receita
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receita>>> GetReceitas()
        {
            try
            {
                return await _context.TB_RECEITA.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        // GET: api/Receita/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Receita>> GetReceita(int id)
        {
            try
            {
                var receita = await _context.TB_RECEITA.FindAsync(id);

                if (receita == null)
                {
                    return NotFound();
                }

                return receita;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        // POST: api/Receita
        [HttpPost]
        public async Task<ActionResult<Receita>> PostReceita(Receita receita)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.TB_RECEITA.Add(receita);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetReceita", new { id = receita.IdReceita }, receita);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        // PUT: api/Receita/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceita(int id, Receita receita)
        {
            try
            {
                if (id != receita.IdReceita)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Entry(receita).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        // DELETE: api/Receita/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceita(int id)
        {
            try
            {
                var receita = await _context.TB_RECEITA.FindAsync(id);
                if (receita == null)
                {
                    return NotFound();
                }

                _context.TB_RECEITA.Remove(receita);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        private bool ReceitaExists(int id)
        {
            return _context.TB_RECEITA.Any(e => e.IdReceita == id);
        }
    }
}
