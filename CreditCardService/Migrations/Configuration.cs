namespace CreditCardService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CreditCardService.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CreditCardService.Models.CreditCardServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CreditCardService.Models.CreditCardServiceContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.CreditCards.AddOrUpdate(x => x.Id,
                new CreditCard() { Id = 1, CreditCardNumber = "7674738297620987", CreditCardPin = "123"},
                new CreditCard() { Id = 2, CreditCardNumber = "1234567890123456", CreditCardPin = "456" },
                new CreditCard() { Id = 3, CreditCardNumber = "6543210987654321", CreditCardPin = "789" }
            );
        }
    }
}
