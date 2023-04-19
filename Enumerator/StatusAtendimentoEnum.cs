using System.Text.Json.Serialization;

namespace meu_primiro_projeto_ef.Enumerator
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusAtendimentoEnum
    {
        Atendimento = 0,
        NaoAtendimento = 1,
        AguardandoAtendimento = 2
    }
}