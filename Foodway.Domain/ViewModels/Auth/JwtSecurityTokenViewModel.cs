namespace Foodway.Domain.ViewModels.Auth;

public class JwtSecurityTokenViewModel
{
    public string TokenType { get; set; } = "Bearer";

    public string AccessToken { get; set; }

    public DateTime Expiration { get; set; }

    public string RefreshAccessToken { get; set; }

    public DateTime RefreshTokenExpiration { get; set; }
}