using System.Text.Json.Serialization;

namespace Foodway.Domain.Requests.Auth;

public class ChangePasswordRequest
{
    [JsonIgnore] public string? UserId { get; set; }

    public string OldPassword { get; set; }

    public string NewPassword { get; set; }

    public string NewPasswordConfirmation { get; set; }
}