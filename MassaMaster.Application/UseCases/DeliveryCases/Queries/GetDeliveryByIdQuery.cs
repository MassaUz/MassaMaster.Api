using MassaMaster.Domain.Entities.Models;
using MediatR;


namespace MassaMaster.Application.UseCases.DeliveryCases.Queries
{
    public class GetDeliveryByIdQuery : IRequest<Delivery>
    {
        public Guid Id { get; set; }

    }
}
