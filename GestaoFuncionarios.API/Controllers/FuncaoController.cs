using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoFuncionarios.Dados;
using GestaoFuncionarios.Model;

namespace GestaoFuncionarios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncaoController : ControllerBase
    {
        private readonly Contexto _context;

        public FuncaoController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Funcao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcao>>> GetFuncao()
        {
            return await _context.Funcao.ToListAsync();
        }

        // GET: api/Funcao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funcao>> GetFuncao(int id)
        {
            var funcao = await _context.Funcao.FindAsync(id);

            if (funcao == null)
            {
                return NotFound();
            }

            return funcao;
        }

        // PUT: api/Funcao/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncao(int id, Funcao funcao)
        {
            if (id != funcao.Id)
            {
                return BadRequest();
            }

            _context.Entry(funcao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncaoExists(id))
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

        // POST: api/Funcao
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Funcao>> PostFuncao(Funcao funcao)
        {
            _context.Funcao.Add(funcao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFuncao", new { id = funcao.Id }, funcao);
        }

        // DELETE: api/Funcao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncao(int id)
        {
            var funcao = await _context.Funcao.FindAsync(id);
            if (funcao == null)
            {
                return NotFound();
            }

            _context.Funcao.Remove(funcao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuncaoExists(int id)
        {
            return _context.Funcao.Any(e => e.Id == id);
        }
    }
}
