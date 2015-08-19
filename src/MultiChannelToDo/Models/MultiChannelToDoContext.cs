using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MultiChannelToDo.Migrations;
using Microsoft.Azure.KeyVault;
using System.Web.Configuration;

namespace MultiChannelToDo.Models
{
    public class MultiChannelToDoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MultiChannelToDoContext() : base("name=MultiChannelToDoContext")
        {
            //  // I put my GetToken method in a Utils class. Change for wherever you placed your method. 
            //  var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(Util.GetToken));

            //  var sec = kv.GetSecretAsync(WebConfigurationManager.AppSettings["SecretUri"]).Result.Value;

            //  //I put a variable in a Utils class to hold the secret for general  application use. 
            //  Util.EncryptSecret = sec;
        }

        public System.Data.Entity.DbSet<MultiChannelToDo.Models.TodoItem> ToDoItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("mobile_service_name"); // change schema to the name of your mobile service,
                                                                  // replacing dashes with underscore
                                                                  // mobile-service-name ==> mobile_service_name

            Database.SetInitializer<MultiChannelToDoContext>(
                new MigrateDatabaseToLatestVersion<MultiChannelToDoContext, Configuration>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
