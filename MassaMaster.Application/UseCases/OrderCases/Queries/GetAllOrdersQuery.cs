using MassaMaster.Domain.Entities.Models;
using MediatR;


namespace MassaMaster.Application.UseCases.OrderCases.Queries
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
    {
    }
}
