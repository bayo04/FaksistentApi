using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Faksistent.Semesters.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Semesters
{
    [AbpAuthorize]
    public class UserSemesterAppService : AsyncCrudAppService<UserSemester, UserSemesterDto, Guid, UserSemesterRequestDto, CreateUserSemesterDto, UpdateUserSemesterDto>, 
        IUserSemesterAppService
    {
        public UserSemesterAppService(IRepository<UserSemester, Guid> repository) : base(repository)
        {

        }

        protected override IQueryable<UserSemester> CreateFilteredQuery(UserSemesterRequestDto input)
        {
            return Repository.GetAll().Where(x => x.CreatorUserId == AbpSession.UserId.Value);
        }

        public override Task<UserSemesterDto> CreateAsync(CreateUserSemesterDto input)
        {

            return base.CreateAsync(input);
        }

        public async Task SetIsSelected(EntityDto<Guid> entity)
        {
            var oldSemester = await Repository.FirstOrDefaultAsync(x => x.IsSelected);

            if(oldSemester != null)
                oldSemester.IsSelected = false;

            var semester = await Repository.FirstOrDefaultAsync(entity.Id);
            semester.IsSelected = true;
        }

        public override Task<UserSemesterDto> UpdateAsync(UpdateUserSemesterDto input)
        {
            input.IsSelected = Repository.FirstOrDefault(input.Id).IsSelected;

            return base.UpdateAsync(input);
        }
    }
}
