using MassaMaster.Domain.Entities.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassaMaster.Application.UseCases.CommentCases.Commands
{
    public class UpdateCommentCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string TelegramLogin { get; set; }
        public string Text { get; set; }
        public Guid? UserId { get; set; }

    }
}
