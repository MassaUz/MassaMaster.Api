using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.DeliveryCases.Commands;
using MassaMaster.Domain.Entities.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MassaMaster.Application.UseCases.DeliveryCases.Handlers.CommandHandlers
{
    public class UpdateDeliveryCommandHandler : IRequestHandler<UpdateDeliveryCommand, ResponseModel>
    {
        private readonly IMassaMasterDbContext _context;

        public UpdateDeliveryCommandHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateDeliveryCommand request, CancellationToken cancellationToken)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (delivery != null)
            {
                delivery.FullName = request.FullName;
                delivery.Email = request.Email;
                delivery.Country = request.Country;
                delivery.Region = request.Region;
                delivery.City = request.City;
                delivery.Index = request.Index;
                delivery.StreetHouse = request.StreetHouse;
                delivery.Details = request.Details;

                _context.Deliveries.Update(delivery);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Delivery Updated",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Delivery is not found",
                StatusCode = 400
            };
        }
    }
}
