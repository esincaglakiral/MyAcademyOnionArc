using Product.Application.Features.CQRS.Commands.CategoryCommands;
using Product.Application.Interfaces;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandle
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandle(IRepository<Category> repository)
        {
            _repository = repository;
        }


        public async Task Handle(UpdateCategoryCommand command)
        {
            var category = new Category
            {
                CategoryId = command.CategoryId,
                CategoryName = command.CategoryName
            };

            await _repository.UpdateAsync(category);
        }
    }
}
