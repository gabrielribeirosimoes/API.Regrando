using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using regrando.API.Data;
using regrando.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace regrando.API.Controllers
{
    [Route("/Cadastro")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly DataContext _context;

        public CadastroController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Cadastro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cadastro>>> GetCadastro()
        {
            try
            {
                return await _context.TB_CADASTRO.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        // GET: api/Cadastro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cadastro>> GetCadastro(int id)
        {
            try
            {
                var cadastro = await _context.TB_CADASTRO.FindAsync(id);

                if (cadastro == null)
                {
                    return NotFound();
                }

                return cadastro;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        // POST: api/Cadastro
        [HttpPost]
        public async Task<ActionResult<Cadastro>> PostCadastro(Cadastro cadastro)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.TB_CADASTRO.Add(cadastro);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCadastro", new { id = cadastro.Id }, cadastro);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        // PUT: api/Cadastro/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCadastro(int id, Cadastro cadastro)
        {
            try
            {
                if (id != cadastro.Id)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Entry(cadastro).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        // DELETE: api/Cadastro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCadastro(int id)
        {
            try
            {
                var cadastro = await _context.TB_CADASTRO.FindAsync(id);
                if (cadastro == null)
                {
                    return NotFound();
                }

                _context.TB_CADASTRO.Remove(cadastro);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        private bool CadastroExists(int id)
        {
            return _context.TB_CADASTRO.Any(e => e.Id == id);
        }
    }
}
