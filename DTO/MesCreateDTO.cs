using meu_primiro_projeto_ef.Enumerator;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace meu_primiro_projeto_ef.DTO
{
    public class MesCreateDTO
    {
        public int Codigo { get; set; }
        public DateTime DataHoraEvento { get; set; }
        
        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(maximumLength: 11, 
                      MinimumLength = 11, 
                      ErrorMessage = "O campo CPF precisa conter 11 caracteres somente números.")]
        public string CPF { get; set; }

        public List<string>? Alergias { get; set; }

        public StatusAtendimentoEnum StatusAtendimento { get; set; }
    }
}
