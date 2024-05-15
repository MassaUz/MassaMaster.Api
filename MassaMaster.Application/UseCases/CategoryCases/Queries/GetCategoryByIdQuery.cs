using MassaMaster.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassaMaster.Application.UseCases.CategoryCases.Queries
{
    public class GetCategoryByIdQuery : IRequest<Category>
    {
        public short Id { get; set; }

    }
}
