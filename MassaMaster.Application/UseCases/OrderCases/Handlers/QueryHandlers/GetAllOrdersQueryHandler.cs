using MediatR;
using Microsoft.EntityFrameworkCore;
using MassaMaster.Application.Abstractions;
using MassaMaster.Domain.Entities.Models;
using MassaMaster.Application.UseCases.OrderCases.Queries;

namespace MassaMaster.Application.UseCases.OrderCases.Handlers.QueryHandlers
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
    {
        private readonly IMassaMasterDbContext _context;

        public GetAllOrdersQueryHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Orders.ToListAsync(cancellationToken);
        }
    }
}
