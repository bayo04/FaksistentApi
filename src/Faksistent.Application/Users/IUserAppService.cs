using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Faksistent.Roles.Dto;
using Faksistent.Users.Dto;

namespace Faksistent.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task DeActivate(EntityDto<long> user);
        Task Activate(EntityDto<long> user);
        Task<ListResultDto<RoleDto>> GetRoles();
        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<UserDto> GetCurrentUserAsync();

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
