using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.ReviewCases.Queries;
using MassaMaster.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassaMaster.Application.UseCases.ReviewCases.Handlers.QueryHandlers
{
    public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, Review>
    {

        private readonly IMassaMasterDbContext _context;

        public GetReviewByIdQueryHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<Review> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (review != null)
            {
                return review;
            }

            throw new Exception("Review Not Found!");
        }

    }
}
