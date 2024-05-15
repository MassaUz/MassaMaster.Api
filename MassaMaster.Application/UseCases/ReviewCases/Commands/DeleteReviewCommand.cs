using MassaMaster.Domain.Entities.DTOs;
using MediatR;


namespace MassaMaster.Application.UseCases.ReviewCases.Commands
{
    public class DeleteReviewCommand : IRequest<ResponseModel>
    {

        public Guid Id { get; set; }

    }
}
