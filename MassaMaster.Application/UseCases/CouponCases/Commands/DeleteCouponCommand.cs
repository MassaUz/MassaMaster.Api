using MassaMaster.Domain.Entities.DTOs;
using MediatR;


namespace MassaMaster.Application.UseCases.CouponCases.Commands
{
    public class DeleteCouponCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }

    }
}
