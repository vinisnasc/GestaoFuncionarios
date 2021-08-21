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
    public class FuncaoController : ControllerBase
    {
        private readonly IFuncaoService _funcaoService;

        public FuncaoController(IFuncaoService funcaoService)
        {
            _funcaoService = funcaoService;
        }

        [HttpGet]
        public IEnumerable<Funcao> GetFuncao()
        {
            return _funcaoService.SelecionarTudo();
        }

        [HttpPost]
        public ActionResult Post(FuncaoDTO dto)
        {
            _funcaoService.CadastrarFuncao(dto);

            return Ok("Função cadastrada com sucesso!");
        }

        [HttpPut("{idAlterarSalario}")]
        public IActionResult AlterarSalarioPorValor(int id, double valor)
        {
            _funcaoService.AumentarSalarioFuncaoValor(id, valor);

            return Ok("Valor de salário da função alterado com sucesso!");
        }

        [HttpPut("{id}")]
        public IActionResult AlterarSalarioPorPorcentagem(int id, double valor)
        {
            _funcaoService.AumentarSalarioFuncaoPorcentualmente(id, valor);

            return Ok("Valor de salário da função alterado com sucesso!");
        }

        [HttpPut("{idDissidio}")]
        public IActionResult Dissidio(double valor)
        {
            _funcaoService.AumentarSalarioDissidio(valor);

            return Ok("Valor de salário da função alterado com sucesso!");
        }
    }
}
