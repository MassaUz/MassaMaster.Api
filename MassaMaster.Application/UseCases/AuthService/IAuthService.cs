using MassaMaster.Domain.Entities.Auth;

namespace MassaMaster.Application.UseCases.AuthService
{
    public interface IAuthService
    {
        public string GenerateToken(User user);
    }
}