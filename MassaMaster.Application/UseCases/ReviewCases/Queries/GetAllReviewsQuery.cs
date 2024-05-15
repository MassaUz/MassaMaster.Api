using MassaMaster.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassaMaster.Application.UseCases.ReviewCases.Queries
{
    public class GetAllReviewsQuery : IRequest<IEnumerable<Review>>
    {
    }
}
