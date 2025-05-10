using BarIstasyon.Business.Features.CQRS.Commands.CategoryCommands;

using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

public class UpdateCategoryCommandHandler
{
    private readonly IRepository<Category> _categoryRepository;

    public UpdateCategoryCommandHandler(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task Handle(UpdateCategoryCommand command)
    {
        var category = await _categoryRepository.GetByIdAsync(command.CategoryID);
        if (category == null)
        {
            throw new Exception("Category entity bulunamadı.");
        }

        category.Name = command.Name;
        




        await _categoryRepository.UpdateAsync(command.CategoryID, category);  // Güncellenmiş about nesnesini repository'de güncelliyoruz
    }
}


