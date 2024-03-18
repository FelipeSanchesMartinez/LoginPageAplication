using Auth.Presentation.Site.Models;
using Auth.Presentation.Site.Util;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Auth.Presentation.Site
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _storage;

        public CustomAuthenticationStateProvider(ILocalStorageService storage)
        {
            _storage = storage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userInfo = await _storage.GetItemAsync<UserInfo>(Constants.USER_INFO_KEY);

                if (userInfo == null)
                {
                    return new AuthenticationState(new ClaimsPrincipal());
                }

                var identity = new ClaimsIdentity(new[] {
            new Claim(ClaimTypes.Name, userInfo.Email),}, "App Authentication");

                var claims = userInfo.Roles == null ? null : userInfo.Roles?.Select(role => new Claim(ClaimTypes.Role, role)).ToList();

                if (claims != null && claims.Any()) identity.AddClaims(claims);

                var user = new ClaimsPrincipal(identity);

                return new AuthenticationState(user);

            }
            catch (Exception ex)
            {
                return new AuthenticationState(new ClaimsPrincipal());
            }

        }


        public async Task Logout()
        {
            await _storage.RemoveItemAsync(Constants.USER_INFO_KEY);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
        }

        public void AuthenticateUser(UserInfo userInfo)
        {
            var identity = new ClaimsIdentity(new[] {
            new Claim(ClaimTypes.Name, userInfo.Email),}, "App Authentication");

            var claims = userInfo.Roles?.Select(role => new Claim(ClaimTypes.Role, role)).ToList();

            if (claims != null && claims.Any()) identity.AddClaims(claims);

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));

        }
    }
}
