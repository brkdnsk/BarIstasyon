using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.AboutCommands;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using MongoDB.Bson;
using BarIstasyon.Business.Features.CQRS.Queries.BannerQueries;
using BarIstasyon.Business.Features.CQRS.Queries.AboutQueries;
using BarIstasyon.DataAccess.Repositories2;

namespace BarIstasyon.Business.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<About?> Handle(GetAboutByIdQuery query)
        {
            return await _repository.GetByIdAsync(query.Id);
        }
    }
}
