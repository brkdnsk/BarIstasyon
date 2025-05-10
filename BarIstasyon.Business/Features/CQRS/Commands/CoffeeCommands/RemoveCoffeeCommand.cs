using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Commands.CoffeeCommands
{
    public class RemoveCoffeeCommand
    {
        public ObjectId id { get; set; }

        public RemoveCoffeeCommand(ObjectId id)
        {
            this.id = id;
        }

        // Parametresiz constructor da ekleyin, model binding için gerekli olabilir
        public RemoveCoffeeCommand() { }
    }
}

