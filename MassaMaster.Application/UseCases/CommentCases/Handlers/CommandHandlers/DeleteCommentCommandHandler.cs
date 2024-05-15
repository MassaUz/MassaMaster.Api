using MassaMaster.Application.Abstractions;
using MassaMaster.Domain.Entities.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MassaMaster.Application.UseCases.CommentCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassaMaster.Application.UseCases.CommentCases.Commands;

namespace MassaMaster.Application.UseCases.CommentCases.Handlers.CommandHandlers
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, ResponseModel>
    {
        private readonly IMassaMasterDbContext _context;

        public DeleteCommentCommandHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Comment Deleted",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Comment is not found",
                StatusCode = 400
            };
        }
    }
}
