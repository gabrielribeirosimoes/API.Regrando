using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using regrando.API.Data;
using regrando.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace regrando.API.Controllers
{
    [Route("api/Aguas")]
    [ApiController]
    public class AguasController : ControllerBase
    {
        private readonly DataContext _context;

        public AguasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Aguas
        [HttpGet]
        public ActionResult<IEnumerable<Aguas>> GetAguas()
        {
            return _context.TB_AGUAS.ToList();
        }

        // GET: api/Aguas/5
        [HttpGet("{id}")]
        public ActionResult<Aguas> GetAguasById(int id)
        {
            var aguas = _context.TB_AGUAS.Find(id);

            if (aguas == null)
            {
                return NotFound();
            }

            return aguas;
        }

        // POST: api/Aguas
        [HttpPost]
        public ActionResult<Aguas> PostAguas(Aguas aguas)
        {
            _context.TB_AGUAS.Add(aguas);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAguasById), new { id = aguas.IdAgua }, aguas);
        }

        // PUT: api/Aguas/5
        [HttpPut("{id}")]
        public IActionResult PutAguas(int id, Aguas aguas)
        {
            if (id != aguas.IdAgua)
            {
                return BadRequest();
            }

            _context.Entry(aguas).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TB_AGUAS.Any(e => e.IdAgua == id))
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

        // DELETE: api/Aguas/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAguas(int id)
        {
            var aguas = _context.TB_AGUAS.Find(id);
            if (aguas == null)
            {
                return NotFound();
            }

            _context.TB_AGUAS.Remove(aguas);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
