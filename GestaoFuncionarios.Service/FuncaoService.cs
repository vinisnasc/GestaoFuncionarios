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
    public class FuncaoService : IFuncaoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FuncaoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CadastrarFuncao(FuncaoDTO dto)
        {
            Funcao funcaoProcurada = _unitOfWork.FuncaoRepositorio.ProcurarPorFuncao(dto.NomeFuncao.Trim().ToLower());
            bool validador = ValidarCadastroFuncao(dto);

            if (funcaoProcurada == null && validador == true)
            {
                Funcao funcaoNova = new();
                funcaoNova.NomeFuncao = dto.NomeFuncao.Trim().ToLower();
                funcaoNova.Salario = dto.Salario;
                _unitOfWork.FuncaoRepositorio.Incluir(funcaoNova);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AumentarSalarioDissidio(double valor)
        {
            valor = (valor >= 1) ? valor / 100 : valor;

            List<Funcao> lista = _unitOfWork.FuncaoRepositorio.SelecionarTudo();

            foreach(Funcao x in lista)
            {
                x.Salario += (x.Salario * valor);
                _unitOfWork.FuncaoRepositorio.Alterar(x);
            }
        }

        public bool AumentarSalarioFuncaoPorcentualmente(int id, double valor)
        {
            valor = (valor >= 1) ? valor / 100 : valor;
            Funcao funcaoAlterar = _unitOfWork.FuncaoRepositorio.SelecionarPorId(id);

            if(funcaoAlterar == null || funcaoAlterar.Salario < valor)
            {
                return false;
            }
            else
            {
                funcaoAlterar.Salario += (valor*funcaoAlterar.Salario);
                _unitOfWork.FuncaoRepositorio.Alterar(funcaoAlterar);
                return true;
            }
        }

        public bool AumentarSalarioFuncaoValor(int id, double valor)
        {
            Funcao funcaoAlterar = _unitOfWork.FuncaoRepositorio.SelecionarPorId(id);

            if (funcaoAlterar == null || funcaoAlterar.Salario < valor)
            {
                return false;
            }
            else
            {
                funcaoAlterar.Salario = valor;
                _unitOfWork.FuncaoRepositorio.Alterar(funcaoAlterar);
                return true;
            }
        }

        public bool ValidarCadastroFuncao(FuncaoDTO dto)
        {
            bool nome = string.IsNullOrEmpty(dto.NomeFuncao.Trim()) ? false : true;
            bool valor = dto.Salario <= 0 ? false : true;

            if (nome == false || valor == false)
                return false;

            else
                return true;
        }

        public List<Funcao> SelecionarTudo()
        {
            return _unitOfWork.FuncaoRepositorio.SelecionarTudo();
        }
    }
}
