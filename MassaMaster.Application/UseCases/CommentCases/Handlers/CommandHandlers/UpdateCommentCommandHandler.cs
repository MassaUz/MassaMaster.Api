using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.CommentCases.Commands;
using MassaMaster.Domain.Entities.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassaMaster.Application.UseCases.CommentCases.Handlers.CommandHandlers
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, ResponseModel>
    {
        private readonly IMassaMasterDbContext _context;

        public UpdateCommentCommandHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (comment != null)
            {
                comment.Name = request.Name;
                comment.Email = request.Email;
                comment.TelegramLogin = request.TelegramLogin;
                comment.Text = request.Text;
                comment.UserId = (Guid)request.UserId;

                _context.Comments.Update(comment);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Comment Updated",
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
