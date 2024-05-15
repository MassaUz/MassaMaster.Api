using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.CategoryCases.Commands;
using MassaMaster.Domain.Entities.DTOs;
using MassaMaster.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassaMaster.Application.UseCases.CategoryCases.Handlers.CommandHandlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ResponseModel>
    {
        private readonly IMassaMasterDbContext _context;

        public CreateCategoryCommandHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var category = new Category()
                {
                    Name = request.Name
                };

                await _context.Categories.AddAsync(category, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Category Created",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Category is might be null",
                StatusCode = 400
            };
        }
    }
}
