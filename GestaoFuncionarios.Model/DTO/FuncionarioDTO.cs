using GestaoFuncionarios.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFuncionarios.Model.DTO
{
    public class FuncionarioDTO
    {
        public string Nome { get; set; }
        public Funcao Funcao { get; set; }
        public Sexo sexo { get; set; }
        public double Salario { get; private set; }
        public Departamento Departamento { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataDemissao { get; set; }
    }
}
