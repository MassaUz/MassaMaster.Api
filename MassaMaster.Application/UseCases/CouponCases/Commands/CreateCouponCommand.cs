using MassaMaster.Domain.Entities.DTOs;
using MediatR;

namespace MassaMaster.Application.UseCases.CouponCases.Commands
{
    public class CreateCouponCommand : IRequest<ResponseModel>
    {
        public string Code { get; set; }
        public DateTimeOffset ExpireDate { get; set; } = DateTimeOffset.UtcNow;
        public int Limit { get; set; }
        public short Percent { get; set; }
    }
}
