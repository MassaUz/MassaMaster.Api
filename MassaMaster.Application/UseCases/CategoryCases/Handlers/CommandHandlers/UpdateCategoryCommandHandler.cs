using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.CategoryCases.Commands;
using MassaMaster.Domain.Entities.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassaMaster.Application.UseCases.CategoryCases.Handlers.CommandHandlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ResponseModel>
    {
        private readonly IMassaMasterDbContext _context;

        public UpdateCategoryCommandHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (category != null)
            {
                category.Name = request.Name;

                _context.Categories.Update(category);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Category Updated",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Category is not found",
                StatusCode = 400
            };
        }
    }
}
