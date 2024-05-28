using System.ComponentModel;

namespace Foodway.Shared.Enums;

public enum PaymentStatus
{
    [Description("Aguardando Provedor")] WaitingProvider,
    [Description("Approvado")] Approved,
    [Description("Rejeitado")] Rejected
}