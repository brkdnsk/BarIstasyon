using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Commands.CoffeePricingCommands
{
    public class RemoveCoffeePricingCommand
    {
        public ObjectId id { get; set; }

        public RemoveCoffeePricingCommand(ObjectId id)
        {
            this.id = id;
        }

        // Parametresiz constructor da ekleyin, model binding için gerekli olabilir
        public RemoveCoffeePricingCommand() { }
    }
}


