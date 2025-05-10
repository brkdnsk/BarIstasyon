using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Commands.ServiceCommands
{
    public class RemoveServiceCommand
    {
        public ObjectId id { get; set; }

        public RemoveServiceCommand(ObjectId id)
        {
            this.id = id;
        }

        // Parametresiz constructor da ekleyin, model binding için gerekli olabilir
        public RemoveServiceCommand() { }
    }
}

