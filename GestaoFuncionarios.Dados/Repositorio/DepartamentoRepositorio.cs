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
        {
            _contexto = contexto;
        }

        public override bool Incluir(Departamento departamento)
        {
            return base.Incluir(departamento);
        }

        public override bool Alterar(Departamento departamento)
        {
            return base.Alterar(departamento);
        }

        public override Departamento SelecionarPorId(int id)
        {
            return base.SelecionarPorId(id);
        }

        public override List<Departamento> SelecionarTudo()
        {
            return base.SelecionarTudo();
        }

        public Departamento SelecionarPorNome(string departamento, string subDepartamento)
        {
            return _contexto.Departamento.FirstOrDefault(d => d.NomeDepartamento == departamento.Trim().ToLower() &&
                                                              d.NomeSubDepartamento == subDepartamento.Trim().ToLower());
        }

        public bool Existe(string depto, string subDepto)
        {
            return _contexto.Departamento.Any(d => d.NomeDepartamento == depto.Trim().ToLower()
                                                && d.NomeSubDepartamento == subDepto.Trim().ToLower());
        }
    }
}
