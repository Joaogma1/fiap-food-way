using System.ComponentModel;

namespace Foodway.Shared.Enums;

public enum AuthPolicy
{
    [Description("Admin")]
    AdminAccess = 0,
    [Description("Backoffice")]
    BackOfficeAccess,
    [Description("default")]
    DefaultAccess
}