using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFuncionarios.Dados.ContextoDB
{
    public class ContextoFactory : IDesignTimeDbContextFactory<Contexto>
    {
        public Contexto CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../GestaoFuncionarios.API"))
                                .AddJsonFile("appsettings.Development.json")
                                .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<Contexto>();
            var connectionString = configuration.GetConnectionString("SQL");
            dbContextBuilder.UseSqlServer(connectionString);

            return new Contexto(dbContextBuilder.Options);
        }
    }
}
