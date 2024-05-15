using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.NewsCases.Commands;
using MassaMaster.Domain.Entities.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace MassaMaster.Application.UseCases.NewsCases.Handlers.CommandHandlers
{
    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, ResponseModel>
    {
        private readonly IMassaMasterDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UpdateNewsCommandHandler(IMassaMasterDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            var news = await _context.News.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (news != null)
            {
                if (request.CardPhoto != null)
                {
                    var photoPath = news.CardPhotoPath;
                    if (File.Exists(photoPath))
                    {
                        File.Delete(photoPath);
                    }

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

                        news.CardPhotoPath = filePath;
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
                }

                news.Title = request.Title;
                news.Date = request.Date;
                news.Description = request.Description;
                news.UserId = request.UserId;

                _context.News.Update(news);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"News Updated",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "News is not found",
                StatusCode = 400
            };
        }
    }
}
