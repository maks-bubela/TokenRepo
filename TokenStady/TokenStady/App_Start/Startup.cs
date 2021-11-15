using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(TokenStady.App_Start.Startup))]
namespace TokenStady.App_Start
{
    public class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthServerOptions { get; private set; }
        public void Configuration(IAppBuilder app)
        {
            //DIConfig.Configure();
            OwinConfig.Configuration(app);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //AzureStorageQueueConfig.Configure();
            //FilterConfig.RegisterGlobalFilters();
            OAuthConfigure(app);
        }

        public void OAuthConfigure(IAppBuilder app)
        {
            OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1)
            };
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            app.UseOAuthBearerTokens(OAuthServerOptions);
        }

    }
}