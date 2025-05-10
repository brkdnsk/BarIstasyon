using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Commands.LocationCommands
{
    public class RemoveLocationCommand
    {
        public ObjectId id { get; set; }

        public RemoveLocationCommand(ObjectId id)
        {
            this.id = id;
        }

        // Parametresiz constructor da ekleyin, model binding için gerekli olabilir
        public RemoveLocationCommand() { }
    }
}

