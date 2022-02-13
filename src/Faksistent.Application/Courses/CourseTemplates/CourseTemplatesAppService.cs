using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Faksistent.Courses.CourseTemplates.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses.CourseTemplates
{
    public class CourseTemplatesAppService : AsyncCrudAppService<CourseTemplate, CourseTemplateDto, Guid, CourseTemplateRequestDto, CreateCourseTemplateDto, UpdateCourseTemplateDto>,
        ICourseTemplatesAppService
    {
        private readonly IRepository<CoursePartition, Guid> _coursePartitionsRepository;
        private readonly IRepository<CourseTest, Guid> _courseTestsRepository;
        private readonly IRepository<CourseRestriction, Guid> _courseRestrictionsRepository;
        public CourseTemplatesAppService(IRepository<CourseTemplate, Guid> repository,
            IRepository<CoursePartition, Guid> coursePartitionsRepository,
            IRepository<CourseTest, Guid> courseTestsRepository,
            IRepository<CourseRestriction, Guid> courseRestrictionsRepository) : base(repository)
        {
            _coursePartitionsRepository = coursePartitionsRepository;
            _courseTestsRepository = courseTestsRepository;
            _courseRestrictionsRepository = courseRestrictionsRepository;
        }

        public async Task<CourseTemplateDto> CreatePartitionsAsync(CreatePartitionsDto input)
        {
            await _coursePartitionsRepository.DeleteAsync(x => x.CourseTemplateId == input.CourseTemplateId);

            foreach (var partitionDto in input.Partitions)
            {
                var partition = ObjectMapper.Map<CoursePartition>(partitionDto);

                partition.CourseTemplateId = input.CourseTemplateId;

                _coursePartitionsRepository.Insert(partition);
            }

            return await GetAsync(new EntityDto<Guid>(input.CourseTemplateId));
        }

        public async Task<CourseTemplateDto> CreateTestsAsync(CreateCourseTestsDto input)
        {
            await _courseTestsRepository.DeleteAsync(x => x.CourseTemplateId == input.CourseTemplateId);

            foreach (var testDto in input.Tests)
            {
                var test = ObjectMapper.Map<CourseTest>(testDto);

                test.CourseTemplateId = input.CourseTemplateId;

                _courseTestsRepository.Insert(test);
            }

            return await GetAsync(new EntityDto<Guid>(input.CourseTemplateId));
        }

        public async Task<CourseTemplateDto> CreateRestrictionsAsync(CreateCourseRestrictionsDto input)
        {
            await _courseRestrictionsRepository.DeleteAsync(x => x.CourseTemplateId == input.CourseTemplateId);

            foreach (var restrictionDto in input.Restrictions)
            {
                var restriction = ObjectMapper.Map<CourseRestriction>(restrictionDto);

                restriction.CourseTemplateId = input.CourseTemplateId;

                restriction.Tests = restrictionDto.CourseTestIds.Select(x => new CourseRestrictionTest { CourseTestId = x }).ToList();

                _courseRestrictionsRepository.Insert(restriction);
            }

            return await GetAsync(new EntityDto<Guid>(input.CourseTemplateId));
        }

        protected override IQueryable<CourseTemplate> CreateFilteredQuery(CourseTemplateRequestDto input)
        {
            return Repository.GetAllIncluding(x => x.Course, x => x.CoursePartitions, x => x.CourseTests, x => x.CourseRestrictions)
                .Include(x => x.SemesterCourse).ThenInclude(x => x.Course);
        }

        public override async Task<CourseTemplateDto> GetAsync(EntityDto<Guid> input)
        {
            var template = Repository.GetAllIncluding(x => x.CoursePartitions, x => x.CourseTests, x => x.CourseRestrictions)
                .FirstOrDefault(x => x.Id == input.Id);

            return ObjectMapper.Map<CourseTemplateDto>(template);
        }
    }
}
