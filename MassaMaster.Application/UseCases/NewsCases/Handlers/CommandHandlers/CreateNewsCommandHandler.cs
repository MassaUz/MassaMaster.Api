using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.NewsCases.Commands;
using MassaMaster.Domain.Entities.DTOs;
using MassaMaster.Domain.Entities.Models;
using MediatR;


namespace MassaMaster.Application.UseCases.NewsCases.Handlers.CommandHandlers
{
    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, ResponseModel>
    {
        private readonly IMassaMasterDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateNewsCommandHandler(IMassaMasterDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var file = request.CardPhoto;
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "ProductPhotos");
                string fileName = "";

                try
                {
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                        Console.WriteLine("Directory created successfully.");
                    }

                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    filePath = Path.Combine(_webHostEnvironment.WebRootPath, "ProductPhotos", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                catch (Exception ex)
                {
                    return new ResponseModel()
                    {
                        Message = ex.Message,
                        StatusCode = 500,
                        IsSuccess = false
                    };
                }

                var news = new News()
                {
                    Title = request.Title,
                    CardPhotoPath = filePath,
                    Date = request.Date,
                    Description = request.Description,
                    UserId = request.UserId,
                };

                await _context.News.AddAsync(news, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel()
                {
                    StatusCode = 201,
                    Message = $"News Created",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "News is might be null",
                StatusCode = 400
            };
        }
    }
}
