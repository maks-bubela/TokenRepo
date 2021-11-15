using Owin;
using System;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security.Cookies;

namespace TokenStady.App_Start
{
    public class OwinConfig
    {
        public static void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(options: new CookieAuthenticationOptions
            {
                AuthenticationType = nameof(TokenStady),
                AuthenticationMode = AuthenticationMode.Active,
                CookieName = nameof(TokenStady),
                CookieHttpOnly = true,
                CookiePath = "/",
                ExpireTimeSpan = TimeSpan.FromDays(7),
                CookieManager = new CookieManager(),
                LoginPath = new PathString("/Authentication/Login"),
                Provider = new CookieAuthenticationProvider()
                {
                    OnResponseSignIn = ctx =>
                    {
                        ctx.Properties.IsPersistent = true;
                    }
                }
            });
        }
    }
}