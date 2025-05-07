using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Results.FooterAddressResults
{
	public class GetFooterAddressQueryResults
	{
        public ObjectId FooterAddressId { get; set; }

        public string Description { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}

