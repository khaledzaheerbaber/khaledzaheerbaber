using DAL;
using DAL.Repositories;
using DAL.UnitOfWork;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using RestAPI.Models;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace RestAPI.Provider
{
    public class oAuthAppProvider : OAuthAuthorizationServerProvider
    {
        private IUserService _userService;
        private IUnitOfWork _unitOfWork;


        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var username = context.UserName;
                var password = context.Password;

                var myContext = new MyContext();
                _unitOfWork = new UnitOfWork(myContext);
                _userService = new UserService(_unitOfWork);

                var users = _userService.GetAll();
                var user = users.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();

                if (user != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim("UserID", user.Id.ToString())
                    };

                    var props = new AuthenticationProperties(new Dictionary<string, string>
                    {
                        {
                            "client_id", (context.ClientId == null) ? string.Empty : context.ClientId
                        },
                        {
                            "Name", user.UserName
                        }
                    });

                    ClaimsIdentity oAutIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);
                    context.Validated(new AuthenticationTicket(oAutIdentity, props));
                }
                else
                {
                    context.SetError("invalid_grant", "Error");
                }
            });
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}