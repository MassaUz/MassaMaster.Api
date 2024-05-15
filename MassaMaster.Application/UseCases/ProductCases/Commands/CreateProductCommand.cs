using MassaMaster.Domain.Entities.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace MassaMaster.Application.UseCases.ProductCases.Commands
{
    public class CreateProductCommand : IRequest<ResponseModel>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public List<IFormFile> Photos { get; set; }
        public short CategoryId { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? NewsId { get; set; }
    }
}
