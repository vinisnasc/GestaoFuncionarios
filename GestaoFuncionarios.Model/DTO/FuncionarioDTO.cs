using GestaoFuncionarios.Model.Enums;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestaoFuncionarios.Model.DTO
{
    public class FuncionarioDTO
    {
        public string Nome { get; set; }
        public string Funcao { get; set; }
        public Sexo sexo { get; set; }
        public double Salario { get; private set; }
        public string Departamento { get; set; }
        public string SubDepartamento { get; set; }
        public DateTime DataAdmissao { get; set; }
    }
}
