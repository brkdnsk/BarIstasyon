using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.BannerCommands;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using MongoDB.Bson;
using BarIstasyon.Business.Features.CQRS.Queries.BannerQueries;

using BarIstasyon.DataAccess.Repositories2;

namespace BarIstasyon.Business.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<Banner?> Handle(GetBannerByIdQuery query)
        {
            return await _repository.GetByIdAsync(query.Id);
        }
    }
}
