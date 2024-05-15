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
    public class GetAllReviewsQueryHandler : IRequestHandler<GetAllReviewsQuery, IEnumerable<Review>>
    {

        private readonly IMassaMasterDbContext _context;

        public GetAllReviewsQueryHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Reviews.ToListAsync(cancellationToken);
        }

    }
}
