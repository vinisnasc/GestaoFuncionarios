using GestaoFuncionarios.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFuncionarios.Model
{
    public class Departamento : IEntity
    {
        public int Id { get; set; }
        public string NomeDepartamento { get; set; }
        public string NomeSubDepartamento { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
    }
}
