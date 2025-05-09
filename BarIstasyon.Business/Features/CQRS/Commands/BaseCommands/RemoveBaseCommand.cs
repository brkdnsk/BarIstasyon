using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Commands.AboutCommands
{
    public class RemoveBaseCommand
    {
        public ObjectId id { get; set; }

        public RemoveBaseCommand(ObjectId id)
        {
            this.id = id;
        }

        // Parametresiz constructor da ekleyin, model binding için gerekli olabilir
        public RemoveBaseCommand() { }
    }
}

