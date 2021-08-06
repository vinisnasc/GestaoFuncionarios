using GestaoFuncionarios.Model;
using GestaoFuncionarios.Model.DTO;
using GestaoFuncionarios.Model.Interfaces.Repositorios;
using GestaoFuncionarios.Model.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFuncionarios.Service
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartamentoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CadastrarDepartamento(DepartamentoDTO dto)
        {
            bool validarDto = string.IsNullOrEmpty(dto.NomeDepartamento.Trim()) ? false : true;

            if (_unitOfWork.DepartamentoRepositorio.Existe(dto.NomeDepartamento, dto.NomeSubDepartamento) == true)
            {
                return false;
            }
            else if (validarDto == false)
            {
                return false;
            }
            else
            {
                Departamento departamento = new();
                departamento.NomeDepartamento = dto.NomeDepartamento.Trim().ToLower();
                departamento.NomeSubDepartamento = dto.NomeSubDepartamento.Trim().ToLower();
                _unitOfWork.DepartamentoRepositorio.Incluir(departamento);
                return true;
            }
        }

        public bool AlterarNomeDepartamento(int id, DepartamentoDTO dto)
        {
            Departamento departamentoAlterar = _unitOfWork.DepartamentoRepositorio.SelecionarPorId(id);
            bool validarDto = string.IsNullOrEmpty(dto.NomeDepartamento.Trim()) ? false : true;

            if (_unitOfWork.DepartamentoRepositorio.Existe(dto.NomeDepartamento, dto.NomeSubDepartamento) == true)
            {
                return false;
            }
            else if (validarDto == false)
            {
                return false;
            }
            else
            {
                departamentoAlterar.NomeDepartamento = dto.NomeDepartamento.Trim().ToLower();
                departamentoAlterar.NomeSubDepartamento = dto.NomeSubDepartamento.Trim().ToLower();
                _unitOfWork.DepartamentoRepositorio.Alterar(departamentoAlterar);
                return true;
            }
        }

        public List<Departamento> SelecionarTudo()
        {
            return _unitOfWork.DepartamentoRepositorio.SelecionarTudo();
        }

    }
}
