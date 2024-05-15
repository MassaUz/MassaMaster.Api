

using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.CouponCases.Commands;
using MassaMaster.Domain.Entities.DTOs;
using MassaMaster.Domain.Entities.Models;
using MediatR;

namespace MassaMaster.Application.UseCases.CouponCases.Handlers.CommandHandlers
{
    public class CreateCouponCommandHandler : IRequestHandler<CreateCouponCommand, ResponseModel>
    {
        private readonly IMassaMasterDbContext _context;

        public CreateCouponCommandHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var coupon = new Coupon()
                {
                    Code = request.Code,
                    ExpireDate = request.ExpireDate,
                    Limit = request.Limit,
                    Percent = request.Percent,
                };

                await _context.Coupons.AddAsync(coupon, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Coupon Created",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Coupon is might be null",
                StatusCode = 400
            };
        }
    }
}
