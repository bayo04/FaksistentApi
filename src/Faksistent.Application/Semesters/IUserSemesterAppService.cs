using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Faksistent.Semesters.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Semesters
{
    public interface IUserSemesterAppService : IAsyncCrudAppService<UserSemesterDto, Guid, UserSemesterRequestDto, CreateUserSemesterDto, UpdateUserSemesterDto>
    {
        Task SetIsSelected(EntityDto<Guid> entity);

        UserSemesterDto GetSelected();
    }
}
