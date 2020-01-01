using System.Collections.Generic;
using IdentityServer4.Models;

namespace ishost
{
    public class Config
    {
         public static IEnumerable<IdentityResource> GetIdentityResources()
        {
             return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource{
                    Name = "office", 
                    UserClaims = { "office_number" }
                }
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>();
        }


        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                
                new Client{
                    ClientId="mvc", 
                    ClientName = "MVC Demo", 
                    AllowedGrantTypes = GrantTypes.Implicit, 
                    RedirectUris = { "http://localhost:3000/signin-oidc"}, 
                    AllowedScopes = { "openid", "email", "office"}
                }
            };
        }

    }
}