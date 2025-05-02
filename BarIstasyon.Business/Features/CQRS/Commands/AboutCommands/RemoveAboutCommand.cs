using System;
namespace BarIstasyon.Business.Features.CQRS.Commands.AboutCommands
{
    public class RemoveAboutCommand
    {
        public object    AboutID { get; set; }
        public RemoveAboutCommand(int id)
        {
            AboutID = id;
        }
    }
}

