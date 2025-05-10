using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Queries;
using BarIstasyon.Business.Features.CQRS.Queries.FooterAddressQueries;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;


namespace BarIstasyon.Business.Features.CQRS.Handlers.FooterAddressHandlers
{
    public class GetAllFooterAddressQueryHandler
    {
        private readonly IMongoCollection<FooterAddress> _footerAddressCollection;

        public GetAllFooterAddressQueryHandler(IMongoDatabase database)
        {
            _footerAddressCollection = database.GetCollection<FooterAddress>("Footer Addresses");
        }

        public async Task<List<FooterAddress>> Handle(GetAllFooterAddressQuery query)
        {
            var footerAddresstList = await _footerAddressCollection.Find(_ => true).ToListAsync();
            return footerAddresstList;
        }
    }
}
