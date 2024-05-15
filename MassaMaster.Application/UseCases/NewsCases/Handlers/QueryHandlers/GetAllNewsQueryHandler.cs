using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.NewsCases.Queries;
using MassaMaster.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace MassaMaster.Application.UseCases.NewsCases.Handlers.QueryHandlers
{
    public class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQuery, IEnumerable<News>>
    {
        private readonly IMassaMasterDbContext _context;

        public GetAllNewsQueryHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<News>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
        {
            return await _context.News
                    .Skip(request.PageIndex - 1)
                        .Take(request.Size)
                            .ToListAsync(cancellationToken);
        }
    }
}
