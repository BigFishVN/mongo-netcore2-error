namespace Helper
{
    using System;
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authentication;

    public class OAuthBearerUtils
    {
        private static OAuthBearerUtils instance;

        private readonly TicketDataFormat format;

        public OAuthBearerUtils()
        {
            format = new TicketDataFormat(new HelperDataProtector());
        }

        public static OAuthBearerUtils Instance => instance ?? (instance = new OAuthBearerUtils());

        public AuthenticationTicket DecodeToken(string token)
        {
            try
            {
                var value = token?.Replace(HelperConstants.BearerAuthenName, string.Empty);
                return format.Unprotect(value?.Trim());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GenerateToken(string code, string company, string permission, int timeout)
        {
            var identity = new ClaimsIdentity(HelperConstants.BearerAuthenName);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, code));

            var current = DateTime.UtcNow;
            var props = new AuthenticationProperties
            {
                IssuedUtc = current,
                ExpiresUtc = current.Add(TimeSpan.FromDays(timeout))
            };

            var principal = new ClaimsPrincipal();
            principal.AddIdentity(identity);

            return format.Protect(new AuthenticationTicket(principal, props, HelperConstants.BearerAuthenName));
        }
    }
}