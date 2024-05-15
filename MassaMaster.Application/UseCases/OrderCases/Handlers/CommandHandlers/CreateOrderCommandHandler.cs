using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.OrderCases.Commands;
using MassaMaster.Domain.Entities.DTOs;
using MassaMaster.Domain.Entities.Models;
using MediatR;


namespace MassaMaster.Application.UseCases.OrderCases.Handlers.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ResponseModel>
    {
        private readonly IMassaMasterDbContext _context;

        public CreateOrderCommandHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var order = new Order()
                {
                    Date = request.Date,
                    OrderPrice = request.OrderPrice,
                    DeliveryPrice = request.DeliveryPrice,
                    TotalPrice = request.TotalPrice,
                    PaymentMethod = request.PaymentMethod,
                    TotalAmount = request.TotalAmount,
                    UserId = request.UserId
                };

                await _context.Orders.AddAsync(order, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Order Created",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Order is might be null",
                StatusCode = 400
            };
        }
    }
}
