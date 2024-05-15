using MassaMaster.Domain.Entities.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassaMaster.Application.UseCases.CommentCases.Commands
{
    public class DeleteCommentCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }

    }
}
