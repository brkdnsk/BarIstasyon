using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Commands.PricingCommands
{
    public class RemovePricingCommand
    {
        public ObjectId id { get; set; }

        public RemovePricingCommand(ObjectId id)
        {
            this.id = id;
        }

        // Parametresiz constructor da ekleyin, model binding için gerekli olabilir
        public RemovePricingCommand() { }
    }
}

