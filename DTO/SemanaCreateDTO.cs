using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meu_primiro_projeto_ef.DTO
{
    public class SemanaCreateDTO
    {
        public int Id { get; set; }
        public int Dia { get; set; }
        public string? Observacao { get; set; }
        public int MesId { get; set; }
    }
}