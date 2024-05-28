using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodway.Shared.Enums
{   
    public enum OrderStatus
    {
        [Description("Aguardando aprovação")]
        WaitingApproval,
        [Description("Em Preparo")]
        Preparing,
        [Description("Pronto para Retirada")]
        ReadyForPickUp,
        [Description("Finalizado")]
        Done,
        [Description("Cancelado")]
        Cancelled,
    }
}
