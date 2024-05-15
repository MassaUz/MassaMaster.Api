using MassaMaster.Domain.Entities.Models;
using MediatR;


namespace MassaMaster.Application.UseCases.CouponCases.Queries
{
    public class GetAllCouponsQuery : IRequest<IEnumerable<Coupon>>
    {
    }
}
