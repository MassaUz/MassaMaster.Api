using MassaMaster.Domain.Entities.Models;
using MediatR;


namespace MassaMaster.Application.UseCases.NewsCases.Queries
{
    public class GetNewsByIdQuery : IRequest<News>
    {
        public Guid Id { get; set; }
    }
}
