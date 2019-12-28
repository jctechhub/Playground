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
                // new Client
                // {
                //     ClientId = "m2m",
                //     ClientName = "Machine to machine (client credentials)",
                //     ClientSecrets = { new Secret("secret".Sha256()) },

                //     AllowedGrantTypes = GrantTypes.ClientCredentials,
                //     AllowedScopes = { "api", "policyserver.runtime", "policyserver.management" },
                // }
            };
        }

    }
}