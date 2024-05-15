using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.CommentCases.Queries;
using MassaMaster.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassaMaster.Application.UseCases.CommentCases.Handlers.QueryHandlers
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, IEnumerable<Comment>>
    {
        private readonly IMassaMasterDbContext _context;

        public GetAllCommentsQueryHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Comments.ToListAsync(cancellationToken);
        }
    }
}
