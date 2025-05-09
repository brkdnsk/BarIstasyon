using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Commands.BannerCommands
{
    public class RemoveBannerCommands
    {
        public ObjectId id { get; set; }

        public RemoveBannerCommands(ObjectId id)
        {
            this.id = id;
        }

        // Parametresiz constructor da ekleyin, model binding için gerekli olabilir
        public RemoveBannerCommands() { }
    }
}

