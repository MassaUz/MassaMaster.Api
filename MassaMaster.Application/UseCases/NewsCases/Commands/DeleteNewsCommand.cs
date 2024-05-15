using MassaMaster.Domain.Entities.DTOs;
using MediatR;


namespace MassaMaster.Application.UseCases.NewsCases.Commands
{
    public class DeleteNewsCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
