using GestaoFuncionarios.Model;
using GestaoFuncionarios.Model.DTO;
using GestaoFuncionarios.Model.Interfaces.Repositorios;
using GestaoFuncionarios.Model.Interfaces.Services;
using System;

namespace GestaoFuncionarios.Service
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FuncionarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CadastrarFuncionario(FuncionarioDTO dto)
        {
            Funcionario funcionario = new();
            funcionario.Nome = dto.Nome;
            funcionario.sexo = dto.sexo;
            funcionario.Departamento = dto.Departamento;
            funcionario.DataAdmissao = dto.DataAdmissao;
            funcionario.Funcao = dto.Funcao;
            funcionario.Salario = dto.Funcao.Salario;
            funcionario.DataAdmissao = dto.DataAdmissao;
            _unitOfWork.FuncionarioRepositorio.Incluir(funcionario);
        }
    }
}
