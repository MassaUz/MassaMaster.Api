using MassaMaster.Domain.Entities.DTOs;
using MediatR;


namespace MassaMaster.Application.UseCases.ReviewCases.Commands
{
    public class UpdateReviewCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public Guid? ProductId { get; set; }

    }
}
