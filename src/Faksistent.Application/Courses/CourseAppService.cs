using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Faksistent.Courses.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses
{
    [AbpAuthorize]
    public class CourseAppService : AsyncCrudAppService<Course, CourseDto, Guid, CourseRequestDto, CreateCourseDto, UpdateCourseDto>,
        ICourseAppService
    {
        public CourseAppService(IRepository<Course, Guid> repository) : base(repository)
        {

        }

        protected override IQueryable<Course> CreateFilteredQuery(CourseRequestDto input)
        {
            return Repository.GetAllIncluding(x => x.SemesterCourses)
                .WhereIf(input.SemesterNo.HasValue, x => x.SemesterNo%2 == input.SemesterNo.Value%2)
                .WhereIf(input.UserSemesterId.HasValue, x => x.SemesterCourses.Any(x => x.UserSemesterId == input.UserSemesterId.Value))
                ;
        }
    }
}
