using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.Azure.KeyVault;
using System.Web.Configuration;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace ContosoUniversity
{
    public static class KeyVaultUtil
    {

        //this is an optional property to hold the secret after it is retrieved
        public static string EncryptSecret { get; set; }

        //the method that will be provided to the KeyVaultClient
        public async static Task<string> GetToken(string authority, string resource, string scope)
        {
            var authContext = new AuthenticationContext(authority);
            ClientCredential clientCred = new ClientCredential(WebConfigurationManager.AppSettings["clientId"],
                        WebConfigurationManager.AppSettings["clientSecret"]);
            AuthenticationResult result = await authContext.AcquireTokenAsync(resource, clientCred);

            if (result == null)
                throw new InvalidOperationException("Failed to obtain the JWT token");

            return result.AccessToken;
        }

        public static string GetConnString()
        {
            var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(KeyVaultUtil.GetToken));
            string conn = kv.GetSecretAsync(WebConfigurationManager.AppSettings["secretUri"]).Result.Value;
            return conn;
        }
    }
}
