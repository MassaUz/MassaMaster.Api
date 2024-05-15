using MassaMaster.Domain.Entities.DTOs;
using MediatR;


namespace MassaMaster.Application.UseCases.OrderCases.Commands
{
    public class DeleteOrderCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
