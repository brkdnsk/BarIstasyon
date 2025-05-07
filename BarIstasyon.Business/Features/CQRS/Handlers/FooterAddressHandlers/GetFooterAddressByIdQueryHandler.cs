using BarIstasyon.Entity.Entities;
using MongoDB.Driver;

using BarIstasyon.Business.Features.CQRS.Queries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.FooterAddressHandlers
{
    public class GetcFooterAddressByIdQueryHandler
    {
        private readonly IMongoCollection<FooterAddress> _footerAddressCollection;

        public GetcFooterAddressByIdQueryHandler(IMongoDatabase database)
        {
            _footerAddressCollection = database.GetCollection<FooterAddress>("Footer Addresses");
        }

        public async Task<FooterAddress> Handle(GetContactByIdQuery query)
        {
            // Burada query.Id artık ObjectId türünde
            var filter = Builders<FooterAddress>.Filter.Eq(a => a.FooterAddressId, query.Id);  // ObjectId ile filtreleme

            var contact = await _footerAddressCollection.Find(filter).FirstOrDefaultAsync();

            if (contact == null)
            {
                throw new Exception("Alt bilgi kaydı bulunamadı.");
            }

            return contact;
        }

    }
}