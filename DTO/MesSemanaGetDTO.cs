namespace meu_primiro_projeto_ef.DTO
{
    public class MesSemanaGetDTO
    {
        public int IdMes { get; set; }
        public string Mes { get; set; }

        public List<SemanaGetDTO> SemanaGetDTOs { get; set; }
        public SemanaGetDTO SemanaGetDto { get; set; }
    }

    public class SemanaGetDTO
    {
        public int IdSemana { get; set; }
        public int Dia { get; set; }
        public string Observacao { get; set; }
    }
}
