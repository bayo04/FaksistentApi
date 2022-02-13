using System.Threading.Tasks;
using Abp.Application.Services;
using Faksistent.Authorization.Accounts.Dto;

namespace Faksistent.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
