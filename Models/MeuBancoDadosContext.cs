using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace meu_primiro_projeto_ef.Model
{
    public class MeuBancoDadosContext : DbContext
    {
        public MeuBancoDadosContext(DbContextOptions<MeuBancoDadosContext> options) : base(options)
        {
            //Todo: Configurar migration
            //ToDo: Executar os comandos do migratin
            //ToDo: Inserir, Atualizar, Deletar e Selecionar
        }


        //Efetuar Carregamento de Dados Iniciais
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MesModel>().HasData
            (
                new MesModel { Id = 1, Ano = 1234, Nome = "Teste Um", StatusAtendimento = 1 },
                new MesModel { Id = 2, Ano = 2023, Nome = "Teste Dois", StatusAtendimento = 3 }
            );
        }

        public DbSet<MesModel> Mes { get; set; }
        public DbSet<SemanaModel> Semana { get; set; }
    }
}