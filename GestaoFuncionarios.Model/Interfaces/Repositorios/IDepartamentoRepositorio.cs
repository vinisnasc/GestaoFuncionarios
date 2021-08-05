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
    }
}
