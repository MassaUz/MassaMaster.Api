using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.OrderCases.Commands;
using MassaMaster.Domain.Entities.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace MassaMaster.Application.UseCases.OrderCases.Handlers.CommandHandlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, ResponseModel>
    {
        private readonly IMassaMasterDbContext _context;

        public UpdateOrderCommandHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (order != null)
            {
                order.Date = request.Date;
                order.OrderPrice = request.OrderPrice;
                order.DeliveryPrice = request.DeliveryPrice;
                order.TotalPrice = request.TotalPrice;
                order.PaymentMethod = request.PaymentMethod;
                order.TotalAmount = request.TotalAmount;
                order.UserId = request.UserId;

                _context.Orders.Update(order);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Order Updated",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Order is not found",
                StatusCode = 400
            };
        }
    }
}
