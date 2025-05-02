using System;
namespace BarIstasyon.Business.Features.CQRS.Results.BannerResults
{
	public class GetBannerQueryResults
	{

        public string BannerID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string VideoDescription { get; set; }

        public string VideoUrl { get; set; }
    }
}

