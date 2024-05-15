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
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, Comment>
    {
        private readonly IMassaMasterDbContext _context;

        public GetCommentByIdQueryHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (comment != null)
            {
                return comment;
            }

            throw new Exception("Comment Not Found!");
        }
    }
}
