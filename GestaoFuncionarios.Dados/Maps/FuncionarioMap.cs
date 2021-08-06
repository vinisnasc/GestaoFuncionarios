using GestaoFuncionarios.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFuncionarios.Dados.Maps
{
    class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionario");

            builder.HasKey(x => x.Id);

            builder.HasOne<Departamento>(d => d.Departamento)
                   .WithMany(f => f.Funcionarios)
                   .HasForeignKey(k => k.IdDepartamento);

            builder.HasOne<Funcao>(f => f.Funcao)
                   .WithMany(p => p.Funcionarios)
                   .HasForeignKey(k => k.IdFuncao);
        }
    }
}
