using MassaMaster.Domain.Entities.DTOs;
using MediatR;


namespace MassaMaster.Application.UseCases.OrderCases.Commands
{
    public class UpdateOrderCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        public double OrderPrice { get; set; }
        public double DeliveryPrice { get; set; }
        public double TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
        public int TotalAmount { get; set; }
        public Guid? UserId { get; set; }
    }
}
