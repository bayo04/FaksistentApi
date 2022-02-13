using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Faksistent.Semesters.SemesterCourses.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Semesters.SemesterCourses
{
    [AbpAuthorize]
    public class SemesterCourseAppService : AsyncCrudAppService<SemesterCourse, SemesterCourseDto, Guid, SemesterCourseRequestDto, CreateSemesterCourseDto, UpdateSemesterCourseDto>,
        ISemesterCourseAppService
    {
        public SemesterCourseAppService(IRepository<SemesterCourse, Guid> repository) : base(repository)
        {

        }

        protected override IQueryable<SemesterCourse> CreateFilteredQuery(SemesterCourseRequestDto input)
        {
            return Repository.GetAllIncluding(x => x.Course).Where(x => x.CreatorUserId == AbpSession.UserId.Value)
                .WhereIf(input.UserSemesterId.HasValue, x => x.UserSemesterId == input.UserSemesterId.Value);
        }

        public async Task CreateCoursesForSemester(CreateMultiSemesterCoursesDto input)
        {
            await Repository.DeleteAsync(x => x.UserSemesterId == input.UserSemesterId);

            foreach(var course in input.Courses)
            {
                await CreateAsync(course);
            }
        }
    }
}
