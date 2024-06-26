using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using regrando.API.Data;
using regrando.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace regrando.API.Controllers
{
    [Route("/Refeicoes")]
    [ApiController]
    public class RefeicoesController : ControllerBase
    {
        private readonly DataContext _context;

        public RefeicoesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Refeicoes
        [HttpGet]
        public ActionResult<IEnumerable<Refeicoes>> GetRefeicoes()
        {
            return _context.TB_REFEICOES.ToList();
        }

        // GET: api/Refeicoes/5
        [HttpGet("{id}")]
        public ActionResult<Refeicoes> GetRefeicoesById(int id)
        {
            var refeicao = _context.TB_REFEICOES.Find(id);

            if (refeicao == null)
            {
                return NotFound();
            }

            return refeicao;
        }

        // POST: api/Refeicoes
        [HttpPost]
        public ActionResult<Refeicoes> PostRefeicoes(Refeicoes refeicao)
        {
            _context.TB_REFEICOES.Add(refeicao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetRefeicoesById), new { id = refeicao.IdRefeicao }, refeicao);
        }

        // PUT: api/Refeicoes/5
        [HttpPut("{id}")]
        public IActionResult PutRefeicoes(int id, Refeicoes refeicao)
        {
            if (id != refeicao.IdRefeicao)
            {
                return BadRequest();
            }

            _context.Entry(refeicao).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TB_REFEICOES.Any(e => e.IdRefeicao == id))
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

        // DELETE: api/Refeicoes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRefeicoes(int id)
        {
            var refeicao = _context.TB_REFEICOES.Find(id);
            if (refeicao == null)
            {
                return NotFound();
            }

            _context.TB_REFEICOES.Remove(refeicao);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
