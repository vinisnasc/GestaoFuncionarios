using GestaoFuncionarios.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFuncionarios.Model
{
    public class Funcao : IEntity
    {
        public int Id { get; set; }
        public string NomeFuncao { get; set; }
        public double Salario { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
    }
}
