using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.OrderCases.Queries;
using MassaMaster.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MassaMaster.Application.UseCases.OrderCases.Handlers.QueryHandlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IMassaMasterDbContext _context;

        public GetOrderByIdQueryHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (order != null)
            {
                return order;
            }

            throw new Exception("Order Not Found!");
        }
    }
}
