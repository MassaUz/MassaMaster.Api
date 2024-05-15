using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.ProductCases.Commands;
using MassaMaster.Domain.Entities.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Rumassa.Application.UseCases.ProductCases.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ResponseModel>
    {
        private readonly IMassaMasterDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeleteProductCommandHandler(IMassaMasterDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (product != null)
            {
                var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, product.Name);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Product Deleted",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Product is not found",
                StatusCode = 400
            };
        }
    }
}
