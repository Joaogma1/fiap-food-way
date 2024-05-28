using System.ComponentModel;

namespace Foodway.Shared.Enums;

public enum OrderStatus
{
    [Description("Aguardando aprovação")] WaitingApproval,
    [Description("Em Preparo")] Preparing,
    [Description("Pronto para Retirada")] ReadyForPickUp,
    [Description("Finalizado")] Done,
    [Description("Cancelado")] Cancelled
}