using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.NewsCases.Queries;
using MassaMaster.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace MassaMaster.Application.UseCases.NewsCases.Handlers.QueryHandlers
{
    public class GetNewsByIdQueryHandler : IRequestHandler<GetNewsByIdQuery, News>
    {
        private readonly IMassaMasterDbContext _context;

        public GetNewsByIdQueryHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<News> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
        {
            var news = await _context.News.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (news != null)
            {
                return news;
            }

            throw new Exception("News Not Found!");
        }
    }
}
