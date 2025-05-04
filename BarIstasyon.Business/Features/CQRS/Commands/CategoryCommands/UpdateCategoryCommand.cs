using System;
namespace BarIstasyon.Business.Features.CQRS.Commands.CategoryCommands
{
	public class UpdateCategoryCommand
	{
        public string CategoryID { get; set; }

        public string Name { get; set; }
    }
}

