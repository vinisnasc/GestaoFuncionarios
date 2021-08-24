using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFuncionarios.Model.Enums
{
    [Flags]
    public enum Sexo
    {
        Masculino = 1,
        Feminino = 2
    }
}
