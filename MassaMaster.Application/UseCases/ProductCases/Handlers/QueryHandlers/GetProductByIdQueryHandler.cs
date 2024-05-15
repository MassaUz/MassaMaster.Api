using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.ProductCases.Queries;
using MassaMaster.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace MassaMaster.Application.UseCases.ProductCases.Handlers.QueryHandlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IMassaMasterDbContext _context;

        public GetProductByIdQueryHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (product != null)
            {
                return product;
            }

            throw new Exception("Product Not Found!");
        }
    }
}
