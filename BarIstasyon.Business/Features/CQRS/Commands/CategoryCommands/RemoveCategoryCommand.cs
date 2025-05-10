using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Commands.CategoryCommands
{
    public class RemoveCategoryCommand
    {
        public ObjectId id { get; set; }

        public RemoveCategoryCommand(ObjectId id)
        {
            this.id = id;
        }

        // Parametresiz constructor da ekleyin, model binding için gerekli olabilir
        public RemoveCategoryCommand() { }

    }
}
