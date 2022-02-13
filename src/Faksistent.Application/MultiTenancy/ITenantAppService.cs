using Abp.Application.Services;
using Faksistent.MultiTenancy.Dto;

namespace Faksistent.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

