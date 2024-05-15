using MassaMaster.Application.Abstractions;
using MassaMaster.Application.UseCases.CouponCases.Queries;
using MassaMaster.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MassaMaster.Application.UseCases.CouponCases.Handlers.QueryHandlers
{
    public class GetAllCouponsQueryHandler : IRequestHandler<GetAllCouponsQuery, IEnumerable<Coupon>>
    {
        private readonly IMassaMasterDbContext _context;

        public GetAllCouponsQueryHandler(IMassaMasterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Coupon>> Handle(GetAllCouponsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Coupons.ToListAsync(cancellationToken);
        }
    }
}
