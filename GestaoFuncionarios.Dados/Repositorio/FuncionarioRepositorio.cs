using GestaoFuncionarios.Model;
using GestaoFuncionarios.Model.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFuncionarios.Dados.Repositorio
{
    public class FuncionarioRepositorio : BaseRepositorio<Funcionario>, IFuncionarioRepositorio
    {
        private readonly Contexto _contexto;
        public FuncionarioRepositorio(Contexto contexto) : base(contexto)
        { 
        }
    }
}
