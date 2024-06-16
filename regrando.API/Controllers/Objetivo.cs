using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using regrando.API.Data;
using regrando.API.Models;
using System.Threading.Tasks;

namespace regrando.API.Controllers
{
    [ApiController]
    [Route("api/Objetivo")]
    public class ObjetivoController : ControllerBase
    {
        private readonly DataContext _context;

        public ObjetivoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/objetivo/{idUsuario}
        [HttpGet("{idUsuario}")]
        public async Task<ActionResult<Objetivo>> GetObjetivoInicial(int idUsuario)
        {
            var objetivo = await _context.TB_OBJETIVO.FirstOrDefaultAsync(o => o.IdUsuario == idUsuario);

            if (objetivo == null)
            {
                return NotFound();
            }

            return objetivo;
        }
    }
}
