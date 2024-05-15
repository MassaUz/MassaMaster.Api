using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.DeliveryCases.Queries;
using MassaMaster.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace MassaMaster.Application.UseCases.DeliveryCases.Handlers.QueryHandlers
{
    public class GetDeliveryByIdQueryHandler : IRequestHandler<GetDeliveryByIdQuery, Delivery>
    {
        private readonly IMassaMasterDbContext _context;

        public GetDeliveryByIdQueryHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<Delivery> Handle(GetDeliveryByIdQuery request, CancellationToken cancellationToken)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (delivery != null)
            {
                return delivery;
            }

            throw new Exception("Delivery Not Found!");
        }
    }
}
