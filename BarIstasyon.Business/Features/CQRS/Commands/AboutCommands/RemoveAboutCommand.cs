using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Commands.AboutCommands
{
    public class RemoveAboutCommand
    {
        public ObjectId id { get; set; }

        public RemoveAboutCommand(ObjectId id)
        {
            this.id = id;
        }

        // Parametresiz constructor da ekleyin, model binding için gerekli olabilir
        public RemoveAboutCommand() { }
    }
}

