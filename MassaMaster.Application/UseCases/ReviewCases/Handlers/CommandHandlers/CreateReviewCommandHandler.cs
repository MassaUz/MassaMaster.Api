
using MediatR;
using MassaMaster.Application.Abstractions;
using MassaMaster.Domain.Entities.DTOs;
using MassaMaster.Domain.Entities.Models;
using MassaMaster.Application.UseCases.ReviewCases.Commands;

namespace MassaMaster.Application.UseCases.ReviewCases.Handlers.CommandHandlers
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, ResponseModel>
    {

        private readonly IMassaMasterDbContext _context;

        public CreateReviewCommandHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var review = new Review()
                {
                   Username = request.Username,
                   Email = request.Email,
                   Text = request.Text,
                   ProductId = request.ProductId,
                };

                await _context.Reviews.AddAsync(review, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Review Created",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Review is might be null",
                StatusCode = 400
            };
        }

    }
}
