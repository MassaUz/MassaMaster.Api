using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.OrderCases.Commands;
using MassaMaster.Domain.Entities.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace MassaMaster.Application.UseCases.OrderCases.Handlers.CommandHandlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, ResponseModel>
    {
        private readonly IMassaMasterDbContext _context;

        public DeleteOrderCommandHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Order Deleted",
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
