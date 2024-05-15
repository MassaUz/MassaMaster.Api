using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.ProductCases.Queries;
using MassaMaster.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace MassaMaster.Application.UseCases.ProductCases.Handlers.QueryHandlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IMassaMasterDbContext _context;

        public GetAllProductsQueryHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products
                    .Skip(request.PageIndex - 1)
                        .Take(request.Size)
                            .ToListAsync(cancellationToken);
        }
    }
}
