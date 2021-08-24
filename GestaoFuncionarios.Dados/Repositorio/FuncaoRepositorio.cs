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
        {
            _contexto = contexto;
        }

        public override bool Incluir(Funcao funcao)
        {
            return base.Incluir(funcao);
        }

        public override bool Alterar(Funcao funcao)
        {
            return base.Alterar(funcao);
        }

        public Funcao ProcurarPorFuncao(string funcao)
        {
            return _contexto.Funcao.FirstOrDefault(x => x.NomeFuncao == funcao);
        }

        public override List<Funcao> SelecionarTudo()
        {
            return base.SelecionarTudo();
        }

        public override Funcao SelecionarPorId(int id)
        {
            return base.SelecionarPorId(id);
        }

        public Funcao SelecionarPorNome(string nome)
        {
            return _contexto.Funcao.FirstOrDefault(f => f.NomeFuncao == nome);
        }
    }
}
