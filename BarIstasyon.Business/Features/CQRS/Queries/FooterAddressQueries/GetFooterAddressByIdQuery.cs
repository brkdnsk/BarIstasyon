using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Queries
{
    public class GetFooterAddressByIdQuery
    {
        public GetFooterAddressByIdQuery(ObjectId id)
        {
            Id = id;
        }

        public ObjectId Id { get; set; }
    }
}

