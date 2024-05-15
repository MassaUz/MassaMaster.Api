using MassaMaster.Domain.Entities.Models;
using MediatR;


namespace MassaMaster.Application.UseCases.DeliveryCases.Queries
{
    public class GetAllDeliveriesQuery : IRequest<IEnumerable<Delivery>>
    {
    }
}
