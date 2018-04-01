using Tangent.Core.Authentication;

namespace Tangent.Services.Authentication
{
    public interface IAuthenticationService
    {
        SecurityToken GetToken();
    }
}
