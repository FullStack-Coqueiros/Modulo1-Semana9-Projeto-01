using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace meu_primiro_projeto_ef.Model
{
   public class MesContext : DbContext
    {
        public MesContext(DbContextOptions<MesContext> options) : base(options)
        {
            //Todo: Configurar migration
            //ToDo: Executar os comandos do migratin
            //ToDo: Inserir, Atualizar, Deletar e Selecionar
        }

        public DbSet<MesModel> Mes { get; set; }
    }
}