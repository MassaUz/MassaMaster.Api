using MassaMaster.Domain.Entities.DTOs;
using MediatR;


namespace MassaMaster.Application.UseCases.ProductCases.Commands
{
    public class DeleteProductCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
