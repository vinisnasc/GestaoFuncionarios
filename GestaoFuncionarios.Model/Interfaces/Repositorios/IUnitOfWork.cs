using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFuncionarios.Model.Interfaces.Repositorios
{
    public interface IUnitOfWork
    {
        public IFuncionarioRepositorio FuncionarioRepositorio { get; }
        public IFuncaoRepositorio FuncaoRepositorio { get; }
        public IDepartamentoRepositorio DepartamentoRepositorio { get; }
    }
}
