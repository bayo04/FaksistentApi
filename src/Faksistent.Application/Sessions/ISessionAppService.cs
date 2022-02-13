using System.Threading.Tasks;
using Abp.Application.Services;
using Faksistent.Sessions.Dto;

namespace Faksistent.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
