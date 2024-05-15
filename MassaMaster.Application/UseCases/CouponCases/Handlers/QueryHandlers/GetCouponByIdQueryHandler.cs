using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.CouponCases.Queries;
using MassaMaster.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace MassaMaster.Application.UseCases.CouponCases.Handlers.QueryHandlers
{
    public class GetCouponByIdQueryHandler : IRequestHandler<GetCouponByIdQuery, Coupon>
    {
        private readonly IMassaMasterDbContext _context;

        public GetCouponByIdQueryHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<Coupon> Handle(GetCouponByIdQuery request, CancellationToken cancellationToken)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (coupon != null)
            {
                return coupon;
            }

            throw new Exception("Coupon Not Found!");
        }
    }
}
