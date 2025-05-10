using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Commands.FeatureCommands
{
    public class RemoveFeatureCommand
    {
        public ObjectId id { get; set; }

        public RemoveFeatureCommand(ObjectId id)
        {
            this.id = id;
        }

        // Parametresiz constructor da ekleyin, model binding için gerekli olabilir
        public RemoveFeatureCommand() { }
    }
}


