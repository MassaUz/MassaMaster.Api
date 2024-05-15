using MassaMaster.Domain.Entities.Models;
using MediatR;


namespace MassaMaster.Application.UseCases.ProductCases.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
        public int PageIndex { get; set; }
        public int Size { get; set; }
    }
}
