using MassaMaster.Domain.Entities.Models;
using MediatR;


namespace MassaMaster.Application.UseCases.NewsCases.Queries
{
    public class GetAllNewsQuery : IRequest<IEnumerable<News>>
    {
        public int PageIndex { get; set; }
        public int Size { get; set; }
    }
}
