using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Test;

namespace ishost
{
    public class TestUsers
    {
        public static List<TestUser> Users = new List<TestUser>()
        {  
            new TestUser { SubjectId = "1", Username = "alice", Password = "alice", 
                Claims = 
                {
                    new Claim("office_number", "25"),
                    new Claim(JwtClaimTypes.Name, "Alice Smith"),
                    new Claim(JwtClaimTypes.GivenName, "Alice"),
                    new Claim(JwtClaimTypes.FamilyName, "Smith"),
                    new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                    new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json)
                }
            },
            new TestUser { SubjectId = "11", Username = "bob", Password = "bob", 
                Claims = 
                {
                    new Claim(JwtClaimTypes.Name, "Bob Smith"),
                    new Claim(JwtClaimTypes.GivenName, "Bob"),
                    new Claim(JwtClaimTypes.FamilyName, "Smith"),
                    new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                    new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                    new Claim("office_number", "30")
                }
            }

        };
    }

    //  public class TestUser
    // {
      
    //     //
    //     // Summary:
    //     //     Gets or sets the subject identifier.
    //     public string SubjectId { get; set; }
    //     //
    //     // Summary:
    //     //     Gets or sets the username.
    //     public string Username { get; set; }
    //     //
    //     // Summary:
    //     //     Gets or sets the password.
    //     public string Password { get; set; }
    //     //
    //     // Summary:
    //     //     Gets or sets the provider name.
    //     public string ProviderName { get; set; }
    //     //
    //     // Summary:
    //     //     Gets or sets the provider subject identifier.
    //     public string ProviderSubjectId { get; set; }
    //     //
    //     // Summary:
    //     //     Gets or sets if the user is active.
    //     public bool IsActive { get; set; }
    //     //
    //     // Summary:
    //     //     Gets or sets the claims.
    //     public ICollection<Claim> Claims { get; set; }
    // }
}