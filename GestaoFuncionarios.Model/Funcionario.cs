using GestaoFuncionarios.Model.Enums;
using GestaoFuncionarios.Model.Interfaces;
using System;

namespace GestaoFuncionarios.Model
{
    public class Funcionario : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Funcao Funcao { get; set; }
        public Sexo sexo { get; set; }
        public int IdFuncao { get; set; }
        public double Salario { get; private set; }
        public Departamento Departamento { get; set; }
        public int IdDepartamento { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataDemissao { get; set; }
    }
}
