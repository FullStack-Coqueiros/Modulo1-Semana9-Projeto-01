using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace meu_primiro_projeto_ef.Model
{
    [Table("Semana")]
    public class SemanaModel
    {
        [Key]
        public int Id { get; set; }
        public int Dia { get; set; }

        public string? Observacao { get; set; }

        [ForeignKey("MesModel")]
        public int MesId { get; set; }

        public MesModel Mes { get; set; }
    }
}
