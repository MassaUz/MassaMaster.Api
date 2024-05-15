using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.DeliveryCases.Queries;
using MassaMaster.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace MassaMaster.Application.UseCases.DeliveryCases.Handlers.QueryHandlers
{
    public class GetAllDeliveriesQueryHandler : IRequestHandler<GetAllDeliveriesQuery, IEnumerable<Delivery>>
    {
        private readonly IMassaMasterDbContext _context;

        public GetAllDeliveriesQueryHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Delivery>> Handle(GetAllDeliveriesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Deliveries.ToListAsync(cancellationToken);
        }
    }
}
