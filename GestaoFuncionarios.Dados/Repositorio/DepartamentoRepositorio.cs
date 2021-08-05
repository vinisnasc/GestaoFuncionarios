using GestaoFuncionarios.Model;
using GestaoFuncionarios.Model.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFuncionarios.Dados.Repositorio
{
    public class DepartamentoRepositorio : BaseRepositorio<Departamento>, IDepartamentoRepositorio
    {
        private readonly Contexto _contexto;
        public DepartamentoRepositorio(Contexto contexto) : base(contexto)
        { }

        public override bool Incluir(Departamento departamento)
        {
            return base.Incluir(departamento);
        }
    }
}
