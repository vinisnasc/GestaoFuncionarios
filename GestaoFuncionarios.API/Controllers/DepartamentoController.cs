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
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoService;

        public DepartamentoController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        [HttpGet]
        public IEnumerable<Departamento> Get()
        {
            return _departamentoService.SelecionarTudo();
        }

        [HttpPut("{id}")]
        public IActionResult PutAlterarDepartamento(int id, DepartamentoDTO dto)
        {
            _departamentoService.AlterarNomeDepartamento(id, dto);
            return Ok("Nome do departamento alterado!");
        }

        [HttpPost]
        public IActionResult Post([FromBody]DepartamentoDTO dto)
        {
            _departamentoService.CadastrarDepartamento(dto);

            return Ok("Departamento criado!");
        }
    }
}
