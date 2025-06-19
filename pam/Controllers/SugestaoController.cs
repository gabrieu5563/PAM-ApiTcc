using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pam.Data;
using pam.Models;
using Pam.Data;

namespace pam.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SugestaoController : ControllerBase
    {
        private readonly DataContext _context;

        public SugestaoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/sugestao
        [HttpGet]
        public async Task<ActionResult<List<Sugestao>>> GetAll()
        {
            return await _context.TB_SUGESTAO
                .Include(s => s.Usuario)
                .ToListAsync();
        }

        // GET: api/sugestao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sugestao>> GetById(int id)
        {
            var sugestao = await _context.TB_SUGESTAO
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sugestao == null)
                return NotFound();

            return sugestao;
        }

        // POST: api/sugestao
        [HttpPost]
        public async Task<ActionResult<Sugestao>> Create(Sugestao sugestao)
        {
            // Verifica se o usuario existe
            var usuario = await _context.TB_USUARIO.FindAsync(sugestao.UsuarioId);
            if (usuario == null)
                return BadRequest("Usuário não encontrado.");

            _context.TB_SUGESTAO.Add(sugestao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = sugestao.Id }, sugestao);
        }

        // PUT: api/sugestao/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Sugestao sugestao)
        {
            if (id != sugestao.Id)
                return BadRequest();

            _context.Entry(sugestao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await SugestaoExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/sugestao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sugestao = await _context.TB_SUGESTAO.FindAsync(id);
            if (sugestao == null)
                return NotFound();

            _context.TB_SUGESTAO.Remove(sugestao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> SugestaoExists(int id)
        {
            return await _context.TB_SUGESTAO.AnyAsync(s => s.Id == id);
        }
    }
}
