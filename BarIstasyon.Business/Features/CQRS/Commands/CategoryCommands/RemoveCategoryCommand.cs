using System;
namespace BarIstasyon.Business.Features.CQRS.Commands.CategoryCommands
{
    public class RemoveCategoryCommand
    {
        public object CategoryId { get; set; }
        public RemoveCategoryCommand(int id)
        {
            CategoryId = id;
        }

    }
}
