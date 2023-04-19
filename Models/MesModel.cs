using System.Diagnostics;
using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using meu_primiro_projeto_ef.Enumerator;

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

        /*
            Ano = Null,
            Ano = 123456
            Default para Int vai ser sempre 0
         */

        public int StatusAtendimento { get; set; }

        [MaxLength]
        public string? Alergias { get; set; }

        /*
         Null != "" != "Com Conteudo"
         ""
         "Com Conteudo"
         */

        public ICollection<SemanaModel> SemanaModels { get; set; }
    }
}