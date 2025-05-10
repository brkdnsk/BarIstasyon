using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Commands.BaseCommands
{
    public class RemoveCoffeeFeatureCommand
    {
        public ObjectId id { get; set; }

        public RemoveCoffeeFeatureCommand(ObjectId id)
        {
            this.id = id;
        }

        // Parametresiz constructor da ekleyin, model binding için gerekli olabilir
        public RemoveCoffeeFeatureCommand() { }
    }
}


