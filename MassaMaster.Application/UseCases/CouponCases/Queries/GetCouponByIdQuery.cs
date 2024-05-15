using MassaMaster.Domain.Entities.Models;
using MediatR;


namespace MassaMaster.Application.UseCases.CouponCases.Queries
{
    public class GetCouponByIdQuery : IRequest<Coupon>
    {
        public Guid Id { get; set; }

    }
}
