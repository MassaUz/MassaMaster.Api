using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.ReviewCases.Commands;
using MassaMaster.Domain.Entities.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace MassaMaster.Application.UseCases.ReviewCases.Handlers.CommandHandlers
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, ResponseModel>
    {

        private readonly IMassaMasterDbContext _context;

        public DeleteReviewCommandHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (review != null)
            {
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Review Deleted",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Review is not found",
                StatusCode = 400
            };
        }

    }
}
