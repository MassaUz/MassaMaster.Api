using MassaMaster.Domain.Entities.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassaMaster.Application.UseCases.UserCases.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {

        public Guid Id { get; set; }

    }
}
