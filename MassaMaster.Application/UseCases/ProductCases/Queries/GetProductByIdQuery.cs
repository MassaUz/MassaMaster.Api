using MassaMaster.Domain.Entities.Models;
using MediatR;


namespace MassaMaster.Application.UseCases.ProductCases.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public Guid Id { get; set; }
    }
}
