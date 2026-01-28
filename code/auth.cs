using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

public class AuthStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal _currentUser =
        new ClaimsPrincipal(new ClaimsIdentity());

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(new AuthenticationState(_currentUser));
    }

    public void SignIn(int userId, string username, string role)
    {
        var identity = new ClaimsIdentity(
            new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()), // <-- THIS IS THE KEY
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            },
            "serverAuth"
        );

        _currentUser = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }


    public void SignOut()
    {
        _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
