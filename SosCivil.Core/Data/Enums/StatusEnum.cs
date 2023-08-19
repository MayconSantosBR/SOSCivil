using System.ComponentModel;

namespace SosCivil.Api.Data.Enums
{
    public enum StatusEnum
    {
        [Description("Criado")]
        Created = 0,

        [Description("Arquivado")]
        Backlog = 1,

        [Description("Em análise")]
        Analysis = 2,

        [Description("Aguardando aprovação")]
        WaitingApproval = 3,

        [Description("Aprovado")]
        Approved = 4,

        [Description("Em transporte")]
        Shipping = 5,

        [Description("Entregue")]
        Delivered = 6,

        [Description("Cancelado")]
        Canceled = 7,

        [Description("Rejeitado")]
        Rejected = 8,
    }
}
