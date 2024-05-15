using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.DeliveryCases.Commands;
using MassaMaster.Domain.Entities.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace MassaMaster.Application.UseCases.DeliveryCases.Handlers.CommandHandlers
{
    public class DeleteDeliveryCommandHandler : IRequestHandler<DeleteDeliveryCommand, ResponseModel>
    {
        private readonly IMassaMasterDbContext _context;

        public DeleteDeliveryCommandHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteDeliveryCommand request, CancellationToken cancellationToken)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (delivery != null)
            {
                _context.Deliveries.Remove(delivery);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Delivery Deleted",
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
