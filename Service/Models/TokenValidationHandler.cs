using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Service.Models
{
    internal class TokenValidationHandler : DelegatingHandler
    {
        private const string _secret = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";


        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpStatusCode statusCode;
            string token;
            //determin whether jwt exists or not
        if (!TryRetrieveToken(request, out token)) {  
            statusCode = HttpStatusCode.Unauthorized;  
            //allow requests with no token - whether a action method needs an authentication can be set with the claimsauthorization attribute  
            return base.SendAsync(request,cancellationToken);  
        } 

            try
            {
                SecurityToken securityToken;
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                TokenValidationParameters validationParameters = new TokenValidationParameters()
                {
                    //Validate JWT audience (aud) claim
                    ValidateAudience = true,
                    ValidAudience = "http://abc.com",
                    ValidateIssuer = true,
                    ValidIssuer = "http://abc.com",
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(_secret)),
                };
                //Extract and assign user of JWT
                Thread.CurrentPrincipal = handler.ValidateToken(token, validationParameters, out securityToken);
                HttpContext.Current.User = Thread.CurrentPrincipal;
                return base.SendAsync(request, cancellationToken);
            }
            catch (SecurityTokenValidationException)
            {
                statusCode = HttpStatusCode.Unauthorized;
            }
            catch (Exception)
            {
                statusCode = HttpStatusCode.InternalServerError;
            }

            return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode) { });
        }

        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            IEnumerable<string> authzheaders;
            if (!request.Headers.TryGetValues("Authorization", out authzheaders) || authzheaders.Count() > 1)
            {
                return false;
            }
            var bearerToken = authzheaders.ElementAt(0);
            token = bearerToken.StartsWith("Bearer") ? bearerToken.Substring(7) : bearerToken;
            return true;
        }

        public bool LifeTimeValidator(DateTime? notBefore,DateTime ? expires,SecurityToken securityToken)
        {
            if(expires!=null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }
    }
}