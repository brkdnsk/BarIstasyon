using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Commands.CoffeeDescriptionCommands
{
    public class RemoveCoffeeDescriptionCommand
    {
        public ObjectId id { get; set; }

        public RemoveCoffeeDescriptionCommand(ObjectId id)
        {
            this.id = id;
        }

        // Parametresiz constructor da ekleyin, model binding için gerekli olabilir
        public RemoveCoffeeDescriptionCommand() { }
    }
}

