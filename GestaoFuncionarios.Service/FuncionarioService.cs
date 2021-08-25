using GestaoFuncionarios.Model;
using GestaoFuncionarios.Model.DTO;
using GestaoFuncionarios.Model.Enums;
using GestaoFuncionarios.Model.Interfaces.Repositorios;
using GestaoFuncionarios.Model.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;

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
                funcionario.Departamento = dep;
                funcionario.DataAdmissao = dto.DataAdmissao;
                funcionario.Funcao = fun;
                funcionario.Salario = fun.Salario;
                _unitOfWork.FuncionarioRepositorio.Incluir(funcionario);
                return true;
            }
        }

        public void ImportarCadastro(string endereco)
        {
            string[] lines = File.ReadAllLines(endereco);

            using (FileStream fs = new(endereco, FileMode.Open))
            {
                using (StreamReader sr = new(fs))
                {
                    foreach (string linha in lines)
                    {
                        string[] separadorLinha = linha.Split(",");
                        FuncionarioDTO dto = new();
                        dto.Nome = separadorLinha[0].Trim();
                        dto.Funcao = separadorLinha[1].Trim();
                        dto.sexo = Enum.Parse<Sexo>(separadorLinha[2].Trim());
                        dto.Departamento = separadorLinha[3].Trim();
                        dto.SubDepartamento = separadorLinha[4].Trim();
                        dto.DataAdmissao = DateTime.Parse(separadorLinha[5].Trim());
                        CadastrarFuncionario(dto);
                    }
                }
            }
        }

        public List<Funcionario> SelecionarTudo()
        {
            return _unitOfWork.FuncionarioRepositorio.SelecionarTudo();
        }

        // TODO: Tentar fazer importação de dados
    }
}
