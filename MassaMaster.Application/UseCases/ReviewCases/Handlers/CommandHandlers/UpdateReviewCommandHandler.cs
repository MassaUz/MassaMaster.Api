using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.ReviewCases.Commands;
using MassaMaster.Domain.Entities.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace MassaMaster.Application.UseCases.ReviewCases.Handlers.CommandHandlers
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, ResponseModel>
    {

        private readonly IMassaMasterDbContext _context;

        public UpdateReviewCommandHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (review != null)
            {
                review.Username = request.Username;
                review.Email = request.Email;
                review.Text = request.Text;
                review.ProductId = request.ProductId;

                _context.Reviews.Update(review);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Review Updated",
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
