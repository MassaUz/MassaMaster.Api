
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MassaMaster.Application.UseCases.CommentCases.Handlers;
using MassaMaster.Application.Abstractions;
using MassaMaster.Domain.Entities.DTOs;
using MassaMaster.Domain.Entities.Models;
using MassaMaster.Application.UseCases.CommentCases.Commands;

namespace MassaMaster.Application.UseCases.CommentCases.Handlers.CommandHandlers
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, ResponseModel>
    {
        private readonly IMassaMasterDbContext _context;

        public CreateCommentCommandHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var comment = new Comment()
                {
                    Name = request.Name,
                    Email = request.Email,
                    TelegramLogin = request.TelegramLogin,
                    Text = request.Text,
                    UserId = (Guid)request.UserId
                };

                await _context.Comments.AddAsync(comment, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Comment Created",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Comment is might be null",
                StatusCode = 400
            };
        }
    }
}
