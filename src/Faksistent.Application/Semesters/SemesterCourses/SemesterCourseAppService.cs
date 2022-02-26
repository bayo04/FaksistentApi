using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Faksistent.Courses;
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
        private readonly IRepository<CourseTemplate, Guid> _courseTemplateRepository;
        public SemesterCourseAppService(IRepository<SemesterCourse, Guid> repository,
            IRepository<CourseTemplate, Guid> courseTemplateRepository) : base(repository)
        {
            _courseTemplateRepository = courseTemplateRepository;
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

        public async Task SetTemplate(SetTemplateDto input)
        {
            var template = _courseTemplateRepository.FirstOrDefault(input.CourseTemplateId);

            var course = await Repository.FirstOrDefaultAsync(x => x.UserSemesterId == input.UserSemesterId && x.CourseId == template.CourseId);

            if (course != null)
            {
                course.CourseTemplateId = input.CourseTemplateId;
            }
        }
    }
}
