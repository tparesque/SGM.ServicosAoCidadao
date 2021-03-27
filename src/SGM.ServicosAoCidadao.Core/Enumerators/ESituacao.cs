using System.ComponentModel;

namespace SGM.ServicosAoCidadao.Core.Enumerators
{
    public enum ESituacao
    {
        [Description("Ativo")]
        ATIVO = 1,

        [Description("Pendente")]
        PENDENTE = 2,

        [Description("Finalizado")]
        FINALIZADO = 3,

        [Description("Cancelado")]
        CANCELADO = 4,

        [Description("Inativo")]
        INATIVO = 5,

        [Description("Solicitação Efetuada")]
        SOLICITACAO_EFETUADA = 6,

        [Description("Aprovada")]
        APROVADA = 7,

        [Description("Concluida")]
        CONCLUIDA = 8,

        [Description("Em Andamento")]
        EM_ANDAMENTO = 9,

        [Description("Deferido")]
        DEFERIDO = 10,

        [Description("Indeferido")]
        INDEFERIDO = 11,
    }
}
