using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFuncionarios.Model.Interfaces.Repositorios
{
    public interface IDepartamentoRepositorio
    {
        bool Incluir(Departamento departamento);
        bool Alterar(Departamento departamento);
        List<Departamento> SelecionarTudo();
        Departamento SelecionarPorId(int id);
        bool Existe(string depto, string subDepto);
        Departamento SelecionarPorNome(string departamento, string subDepartamento);
    }
}
