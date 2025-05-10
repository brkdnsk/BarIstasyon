using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Commands.SocialMediaCommands
{
    public class RemoveSocialMediaCommand
    {
        public ObjectId id { get; set; }

        public RemoveSocialMediaCommand(ObjectId id)
        {
            this.id = id;
        }

        // Parametresiz constructor da ekleyin, model binding için gerekli olabilir
        public RemoveSocialMediaCommand() { }
    }
}

