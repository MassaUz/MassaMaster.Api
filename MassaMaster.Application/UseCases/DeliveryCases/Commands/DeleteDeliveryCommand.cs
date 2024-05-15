using MassaMaster.Domain.Entities.DTOs;
using MediatR;


namespace MassaMaster.Application.UseCases.DeliveryCases.Commands
{
    public class DeleteDeliveryCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }

    }
}
