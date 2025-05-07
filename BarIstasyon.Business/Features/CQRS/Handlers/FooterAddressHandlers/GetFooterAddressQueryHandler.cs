using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Queries;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;


namespace BarIstasyon.Business.Features.CQRS.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler
    {
        private readonly IMongoCollection<FooterAddress> _footerAddressCollection;

        public GetFooterAddressQueryHandler(IMongoDatabase database)
        {
            _footerAddressCollection = database.GetCollection<FooterAddress>("Footer Addresses");
        }

        public async Task<List<FooterAddress>> Handle(GetFeatureByIdQuery query)
        {
            var contactList = await _footerAddressCollection.Find(_ => true).ToListAsync();
            return contactList;
        }
    }
}
