using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;


namespace EcommerceShop.BackEnd.IdentityServer
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
             new ApiScope[]
             {
                  new ApiScope("ecommerceshop.api", "Ecommerce Shop API")
             };

        public static IEnumerable<Client> Clients(Dictionary<string, string> clientUrls) =>
            new List<Client>
            {
                // machine to machine client
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // scopes that client has access to
                    AllowedScopes = { "ecommerceshop.api" }
                },

                // interactive ASP.NET Core MVC client
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { $"{clientUrls["Mvc"]}/signin-oidc" },

                    PostLogoutRedirectUris = { $"{clientUrls["Mvc"]}/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "ecommerceshop.api"
                    }
                },

                new Client
                {
                    ClientId = "swagger",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,

                    RequireConsent = false,
                    RequirePkce = true,

                    RedirectUris =           { $"{clientUrls["Swagger"]}/swagger/oauth2-redirect.html" },
                    PostLogoutRedirectUris = { $"{clientUrls["Swagger"]}/swagger/oauth2-redirect.html" },
                    AllowedCorsOrigins =     { $"{clientUrls["Swagger"]}"},

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "ecommerceshop.api"
                    }
                },

               new Client {
                    ClientName = "admin",
                    ClientId = "admin",

                    AccessTokenType = AccessTokenType.Reference,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireClientSecret = false,
                    RequireConsent = false,
                    RequirePkce = true,
                    AlwaysSendClientClaims = true,
                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = true,

                    RedirectUris = new List<string>
                    {
                        $"{clientUrls["React"]}/authentication/logout-callback",
                        $"{clientUrls["React"]}/signin-callback",
                        $"{clientUrls["React"]}/silent-renew.html",
                        $"{clientUrls["React"]}"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        $"{clientUrls["React"]}/authentication/login-callback",
                        $"{clientUrls["React"]}/unauthorized",
                        $"{clientUrls["React"]}/signout-callback",
                        $"{clientUrls["React"]}"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                         $"{clientUrls["React"]}"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "ecommerceshop.api",
                    }
                }
            };
    }
}