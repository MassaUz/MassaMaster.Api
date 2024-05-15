using MassaMaster.Domain.Entities.DTOs;
using MediatR;


namespace MassaMaster.Application.UseCases.CouponCases.Commands
{
    public class UpdateCouponCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public DateTimeOffset ExpireDate { get; set; }
        public int Limit { get; set; }
        public short Percent { get; set; }
    }
}
