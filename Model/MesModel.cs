using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace meu_primiro_projeto_ef.Model
{
    [Table("Mes")]
    public class MesModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }
        public int Ano { get; set; }
    }
}