using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoFuncionarios.Dados;
using GestaoFuncionarios.Model;
using GestaoFuncionarios.Model.Interfaces.Services;
using GestaoFuncionarios.Model.DTO;

namespace GestaoFuncionarios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        public IEnumerable<Funcionario> GetFuncionario()
        {
            return _funcionarioService.SelecionarTudo();
        }

        [HttpPost]
        public ActionResult PostFuncionario([FromBody] FuncionarioDTO dto)
        {
            bool result = _funcionarioService.CadastrarFuncionario(dto);

            if (result)
                return Ok("Funcionario cadastrado!");

            else
                return BadRequest("Erro ao cadastrar o funcionario!");
        }

        [HttpPost("ImportarDados")]
        public ActionResult ImportarDados([FromQuery] string endereco)
        {
            _funcionarioService.ImportarCadastro(endereco);

            return Ok("Funcionario cadastrado!");
        }
    }
}
