using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Faksistent.Courses;
using Faksistent.Semesters.SemesterCourses.Dto;
using Microsoft.EntityFrameworkCore;
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
        private readonly IRepository<SemesterCoursePartition, Guid> _semesterCoursePartitionRepository;
        private readonly IRepository<SemesterCourseTest, Guid> _semesterCourseTestRepository;
        public SemesterCourseAppService(IRepository<SemesterCourse, Guid> repository,
            IRepository<CourseTemplate, Guid> courseTemplateRepository,
            IRepository<SemesterCoursePartition, Guid> semesterCoursePartitionRepository,
            IRepository<SemesterCourseTest, Guid> semesterCourseTestRepository) : base(repository)
        {
            _courseTemplateRepository = courseTemplateRepository;
            _semesterCoursePartitionRepository = semesterCoursePartitionRepository;
            _semesterCourseTestRepository = semesterCourseTestRepository;
        }

        protected override IQueryable<SemesterCourse> CreateFilteredQuery(SemesterCourseRequestDto input)
        {
            return Repository.GetAllIncluding(x => x.Course, x => x.SemesterCoursePartitions)
                .Include(x => x.CourseTemplate).ThenInclude(x => x.CoursePartitions)
                .Include(x => x.CourseTemplate).ThenInclude(x => x.CourseTests)
                .Include(x => x.CourseTemplate).ThenInclude(x => x.CourseRestrictions).ThenInclude(x => x.Tests)
                .Where(x => x.CreatorUserId == AbpSession.UserId.Value)
                .WhereIf(input.UserSemesterId.HasValue, x => x.UserSemesterId == input.UserSemesterId.Value);
        }

        public async Task CreateCoursesForSemester(CreateMultiSemesterCoursesDto input)
        {
            await Repository.DeleteAsync(x => x.UserSemesterId == input.UserSemesterId && !input.Courses.Select(y => y.CourseId).Contains(x.CourseId));

            foreach(var course in input.Courses)
            {
                var oldCourse = await Repository.FirstOrDefaultAsync(x => x.UserSemesterId == input.UserSemesterId && x.CourseId == course.CourseId);

                if (oldCourse == null)
                {
                    await CreateAsync(course);
                }
            }
        }

        public override async Task<SemesterCourseDto> GetAsync(EntityDto<Guid> input)
        {
            var template = Repository.GetAllIncluding(x => x.SemesterCoursePartitions,x => x.SemesterCourseTests)
                .Include(x => x.CourseTemplate).ThenInclude(x => x.CourseRestrictions).ThenInclude(x => x.Tests)
                .Include(x => x.CourseTemplate).ThenInclude(x => x.CoursePartitions)
                .Include(x => x.CourseTemplate).ThenInclude(x => x.CourseTests)
                .FirstOrDefault(x => x.Id == input.Id);

            return ObjectMapper.Map<SemesterCourseDto>(template);
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

        public async Task SetPoints(SetPointsDto input)
        {
            //var tests = _courseTemplateRepository.GetAllIncluding(x => x.CourseTests)
            //    .Where(x => x.CourseTests.Select(z => z.Id).Contains(input.CourseTestId)).Select(x => x.CourseTests).ToList();
            //.FirstOrDefault(x => x.Select(z => z.Id).Contains(input.CourseTestId));

            //var courseTest = tests.FirstOrDefault(x => x.Id == input.CourseTestId);
            var test = _semesterCourseTestRepository.FirstOrDefault(x => x.CourseTestId == input.CourseTestId && x.SemesterCourseId == input.SemesterCourseId);

            if(test != null)
            {
                test.Points = input.Points;
            }
            else
            {
                _semesterCourseTestRepository.Insert(new SemesterCourseTest
                {
                    CourseTestId = input.CourseTestId,
                    SemesterCourseId = input.SemesterCourseId,
                    Points = input.Points
                });
            }
        }

        public async Task CreateSemesterCoursePartitions(List<CreateSemesterCoursePartitionDto> partitions)
        {
            foreach (var partitionDto in partitions)
            {
                var partition = _semesterCoursePartitionRepository.FirstOrDefault(x => x.SemesterCourseId == partitionDto.SemesterCourseId && 
                    x.CoursePartitionId == partitionDto.CoursePartitionId &&
                    x.StartTime == partitionDto.StartTime &&
                    x.EndTime == partitionDto.EndTime);

                if(partition == null)
                {
                    partition = ObjectMapper.Map<SemesterCoursePartition>(partitionDto);

                    _semesterCoursePartitionRepository.Insert(partition);
                }
            }
        }
    }
}
