using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Commands.BaseCommands
{
    public class RemoveFooterAddressCommand
    {
        public ObjectId id { get; set; }

        public RemoveFooterAddressCommand(ObjectId id)
        {
            this.id = id;
        }

        // Parametresiz constructor da ekleyin, model binding için gerekli olabilir
        public RemoveFooterAddressCommand() { }
    }
}

