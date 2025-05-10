using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Commands.ContactCommands
{
    public class RemoveContactCommand
    {
        public ObjectId id { get; set; }

        public RemoveContactCommand(ObjectId id)
        {
            this.id = id;
        }

        // Parametresiz constructor da ekleyin, model binding için gerekli olabilir
        public RemoveContactCommand() { }
    }
}


