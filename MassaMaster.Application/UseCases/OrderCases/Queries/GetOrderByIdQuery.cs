using MassaMaster.Domain.Entities.Models;
using MediatR;


namespace MassaMaster.Application.UseCases.OrderCases.Queries
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public Guid Id { get; set; }
    }
}
