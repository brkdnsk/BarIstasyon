namespace BarIstasyon.Business.Features.CQRS.Commands.AboutCommands
{
    public class UpdateAboutCommand
    {
        public string Id { get; set; } // MongoDB'de ObjectId temsil eden string
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
