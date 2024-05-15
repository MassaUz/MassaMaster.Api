using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.CategoryCases.Queries;
using MassaMaster.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassaMaster.Application.UseCases.CategoryCases.Handlers.QueryHandlers
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>
    {
        private readonly IMassaMasterDbContext _context;

        public GetAllCategoriesQueryHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Categories.ToListAsync(cancellationToken);
        }
    }
}
