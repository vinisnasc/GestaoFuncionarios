using GestaoFuncionarios.Model;
using GestaoFuncionarios.Model.DTO;
using GestaoFuncionarios.Model.Interfaces.Repositorios;
using GestaoFuncionarios.Model.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace GestaoFuncionarios.Service
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FuncionarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CadastrarFuncionario(FuncionarioDTO dto)
        {
            Departamento dep = _unitOfWork.DepartamentoRepositorio.SelecionarPorNome(dto.Departamento, dto.SubDepartamento);
            Funcao fun = _unitOfWork.FuncaoRepositorio.SelecionarPorNome(dto.Funcao);

            if (dep == null && fun == null)
                return false;

            else
            {
                Funcionario funcionario = new();
                funcionario.Nome = dto.Nome;
                funcionario.sexo = dto.sexo;
                funcionario.Departamento = _unitOfWork.DepartamentoRepositorio.SelecionarPorNome(dto.Departamento, dto.SubDepartamento);
                funcionario.DataAdmissao = dto.DataAdmissao;
                funcionario.Funcao = _unitOfWork.FuncaoRepositorio.SelecionarPorNome(dto.Funcao);
                funcionario.Salario = _unitOfWork.FuncaoRepositorio.SelecionarPorNome(dto.Funcao).Salario;
                _unitOfWork.FuncionarioRepositorio.Incluir(funcionario);
                return true;
            }
        }

        public List<Funcionario> SelecionarTudo()
        {
            return _unitOfWork.FuncionarioRepositorio.SelecionarTudo();
        }
    }
}
