using GestaoFuncionarios.Model;
using GestaoFuncionarios.Model.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFuncionarios.Dados.Repositorio
{
    public class FuncaoRepositorio : BaseRepositorio<Funcao>, IFuncaoRepositorio
    {
        private readonly Contexto _contexto;
        public FuncaoRepositorio(Contexto contexto) : base(contexto)
        { }

        public override bool Incluir(Funcao funcao)
        {
            return base.Incluir(funcao);
        }

        public Funcao ProcurarPorFuncao(string funcao)
        {
            return _contexto.Funcao.FirstOrDefault(x => x.NomeFuncao == funcao);
        }
    }
}
