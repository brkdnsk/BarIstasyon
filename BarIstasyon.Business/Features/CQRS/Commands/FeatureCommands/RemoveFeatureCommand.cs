using System;
namespace BarIstasyon.Business.Features.CQRS.Commands.FeatureCommands
{
	public class RemoveFeatureCommand
	{
        public object FeatureId { get; set; }
        public RemoveFeatureCommand(int id)
        {
            FeatureId = id;
        }
    }
}

