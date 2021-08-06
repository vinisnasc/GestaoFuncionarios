using GestaoFuncionarios.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFuncionarios.Model.Interfaces.Services
{
    public interface IFuncaoService
    {
        bool CadastrarFuncao(FuncaoDTO dto);
        void AumentarSalarioDissidio(double valor);
        public bool AumentarSalarioFuncaoPorcentualmente(int id, double valor);
        public bool AumentarSalarioFuncaoValor(int id, double valor);
        List<Funcao> SelecionarTudo();
    }
}
