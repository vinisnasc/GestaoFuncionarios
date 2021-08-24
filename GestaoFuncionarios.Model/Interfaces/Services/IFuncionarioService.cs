using GestaoFuncionarios.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFuncionarios.Model.Interfaces.Services
{
    public interface IFuncionarioService
    {
        bool CadastrarFuncionario(FuncionarioDTO dto);
        List<Funcionario> SelecionarTudo();
    }
}
