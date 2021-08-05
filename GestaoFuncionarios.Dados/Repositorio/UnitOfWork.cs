using GestaoFuncionarios.Model.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFuncionarios.Dados.Repositorio
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Contexto _contexto;
        public IFuncionarioRepositorio FuncionarioRepositorio { get; }
        public IFuncaoRepositorio FuncaoRepositorio { get; }
        public IDepartamentoRepositorio DepartamentoRepositorio { get; }

        public UnitOfWork(Contexto contexto)
        {
            _contexto = contexto;
            FuncionarioRepositorio = new FuncionarioRepositorio(contexto);
            DepartamentoRepositorio = new DepartamentoRepositorio(contexto);
            FuncaoRepositorio = new FuncaoRepositorio(contexto);
        }
    }
}
