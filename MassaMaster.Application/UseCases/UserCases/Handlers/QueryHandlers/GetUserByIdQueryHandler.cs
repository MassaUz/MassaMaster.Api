using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.UserCases.Queries;
using MassaMaster.Domain.Entities.Auth;
using MediatR;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassaMaster.Application.UseCases.UserCases.Handlers.QueryHandlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery,User>
    {
        private readonly IMassaMasterDbContext _context;

        public GetUserByIdQueryHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (user != null)
            {
                return user;
            }

            throw new Exception("User Not Found!");
        }
    }
}
