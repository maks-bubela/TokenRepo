using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using MintyIssueTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using TokenStady.App_Start;

namespace TokenStady.TokenProvider
{
    public class TokenProvider
    {
        public static string GenerateToken(UserRegistrationModel userRegistrationModel)
        {
            ClaimsIdentity identity = new ClaimsIdentity(Startup.OAuthServerOptions.AuthenticationType);

            identity.AddClaim(new Claim(ClaimTypes.Name, userRegistrationModel.Username, ClaimValueTypes.String));

            Dictionary<string, string> propDictionary = new Dictionary<string, string>();
            propDictionary.Add("UserName", userRegistrationModel.Username);
            propDictionary.Add("Role", userRegistrationModel.RoleName);

            AuthenticationProperties properties = new AuthenticationProperties(propDictionary);

            AuthenticationTicket ticket = new AuthenticationTicket(identity, properties);


            DateTime currentUtc = DateTime.UtcNow;

            DateTime expireUtc = currentUtc.Add(TimeSpan.FromHours(24));

            ticket.Properties.IssuedUtc = currentUtc;
            ticket.Properties.ExpiresUtc = expireUtc;


            string token = Startup.OAuthServerOptions.AccessTokenFormat.Protect(ticket);
            return token;
            
        }
    }
}