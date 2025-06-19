using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pam.Models;
using Pam.Data;

namespace pam.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RequisicaoController : ControllerBase
    {
        private readonly DataContext _context;

        public RequisicaoController(DataContext context)
        {
            _context = context;
        }

        #region create
        /*
        POST http://localhost:5152/Requisicao

        {
        "prompt": "Abrir o WhatsApp",
        "usuarioId": 1
        }*/

        [HttpPost]
        public async Task<ActionResult<Requisicao>> Create(Requisicao requisicao)
        {
            // Verifica se o usuário existe
            var usuario = await _context.TB_USUARIO.FindAsync(requisicao.UsuarioId);
            if (usuario == null)
                return BadRequest("Usuário não encontrado.");

            requisicao.CriadoEm = DateTime.Now;

            _context.TB_REQUISICAO.Add(requisicao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = requisicao.Id }, requisicao);
        }
        #endregion

        #region get all
        //GET http://localhost:5152/Requisicao

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Requisicao>>> GetAll()
        {
            return await _context.TB_REQUISICAO.ToListAsync();
        }
        #endregion

        #region get by id
        ////GET http://localhost:5152/Requisicao/1

        [HttpGet("{id}")]
        public async Task<ActionResult<Requisicao>> GetById(int id)
        {
            var requisicao = await _context.TB_REQUISICAO.FindAsync(id);

            if (requisicao == null)
                return NotFound();

            return requisicao;
        }
        #endregion

        #region update
        /*
        PUT http://localhost:[porta]/Requisicao/1
        {
        "id": 1,
        "prompt": "Fazer login no Gmail",
        "usuarioId": 2
        }

        */
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Requisicao requisicao)
        {
            if (id != requisicao.Id)
                return BadRequest("ID da URL não corresponde ao ID da requisição.");

            var requisicaoExistente = await _context.TB_REQUISICAO.FindAsync(id);
            if (requisicaoExistente == null)
                return NotFound();

            requisicaoExistente.Prompt = requisicao.Prompt;
            requisicaoExistente.UsuarioId = requisicao.UsuarioId;

            _context.Entry(requisicaoExistente).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region delete
        //DELETE http://localhost:[porta]/Requisicao/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var requisicao = await _context.TB_REQUISICAO.FindAsync(id);
            if (requisicao == null)
                return NotFound();

            _context.TB_REQUISICAO.Remove(requisicao);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion
    }
}
