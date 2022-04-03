using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
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
        private readonly IRepository<CourseRestrictionTest, Guid> _courseRestrictionTestsRepository;
        public CourseTemplatesAppService(IRepository<CourseTemplate, Guid> repository,
            IRepository<CoursePartition, Guid> coursePartitionsRepository,
            IRepository<CourseTest, Guid> courseTestsRepository,
            IRepository<CourseRestriction, Guid> courseRestrictionsRepository,
            IRepository<CourseRestrictionTest, Guid> courseRestrictionTestsRepository) : base(repository)
        {
            _coursePartitionsRepository = coursePartitionsRepository;
            _courseTestsRepository = courseTestsRepository;
            _courseRestrictionsRepository = courseRestrictionsRepository;
            _courseRestrictionTestsRepository = courseRestrictionTestsRepository;
        }

        public async Task<CourseTemplateDto> CreatePartitionsAsync(CreatePartitionsDto input)
        {
            await _coursePartitionsRepository.DeleteAsync(x => x.CourseTemplateId == input.CourseTemplateId && !input.Partitions.Select(x => x.Code).Contains(x.Code));

            foreach (var partitionDto in input.Partitions)
            {
                var oldPartition = await _coursePartitionsRepository.FirstOrDefaultAsync(x => x.CourseTemplateId == input.CourseTemplateId && x.Code == partitionDto.Code);

                if(oldPartition != null)
                {
                    _coursePartitionsRepository.Update(oldPartition);
                }
                else
                {
                    var partition = ObjectMapper.Map<CoursePartition>(partitionDto);

                    partition.CourseTemplateId = input.CourseTemplateId;

                    _coursePartitionsRepository.Insert(partition);
                }
            }

            return await GetAsync(new EntityDto<Guid>(input.CourseTemplateId));
        }

        public async Task<CourseTemplateDto> CreateTestsAsync(CreateCourseTestsDto input)
        {
            await _courseTestsRepository.DeleteAsync(x => x.CourseTemplateId == input.CourseTemplateId && !input.Tests.Select(x => x.Code).Contains(x.Code));

            foreach (var testDto in input.Tests)
            {
                var oldTest = await _courseTestsRepository.FirstOrDefaultAsync(x => x.CourseTemplateId == input.CourseTemplateId && x.Code == testDto.Code);

                if (oldTest != null)
                {
                    oldTest.Name = testDto.Name;
                    oldTest.PointsForPass = testDto.PointsForPass;
                    oldTest.PointsForSignature = testDto.PointsForSignature;
                    oldTest.TotalPoints = testDto.TotalPoints;
                    _courseTestsRepository.Update(oldTest);
                }
                else
                {
                    var test = ObjectMapper.Map<CourseTest>(testDto);

                    test.CourseTemplateId = input.CourseTemplateId;

                    _courseTestsRepository.Insert(test);
                }
            }

            return await GetAsync(new EntityDto<Guid>(input.CourseTemplateId));
        }

        public async Task<CourseTemplateDto> CreateRestrictionsAsync(CreateCourseRestrictionsDto input)
        {
            var restrictionIds = _courseRestrictionsRepository.GetAll().Where(x => x.CourseTemplateId == input.CourseTemplateId).Select(x => x.Id).ToList();
            await _courseRestrictionTestsRepository.DeleteAsync(x => restrictionIds.Contains(x.CourseRestrictionId));
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
                .Include(x => x.SemesterCourse).ThenInclude(x => x.Course)
                .WhereIf(input.IsPublic.HasValue, x => x.IsPublic == input.IsPublic.Value)
                .WhereIf(input.IsMine.HasValue && input.IsMine.Value == true, x => x.CreatorUserId == AbpSession.UserId);
        }

        public override async Task<CourseTemplateDto> GetAsync(EntityDto<Guid> input)
        {
            var template = Repository.GetAllIncluding(x => x.CoursePartitions, x => x.CourseTests).Include(x => x.CourseRestrictions).ThenInclude(x => x.Tests)
                .FirstOrDefault(x => x.Id == input.Id);

            return ObjectMapper.Map<CourseTemplateDto>(template);
        }

        public async Task<CourseTemplateDto> CreatePrivate(EntityDto<Guid> input)
        {
            var template = await GetAsync(input);
            var dto = ObjectMapper.Map<CreateCourseTemplateDto>(template);

            if (dto != null)
            {
                dto.IsPublic = false;
                var createdTemplate = await CreateAsync(dto);

                await CreatePartitionsAsync(new CreatePartitionsDto
                {
                    CourseTemplateId = createdTemplate.Id,
                    Partitions = template.CoursePartitions.Select(x => ObjectMapper.Map<CreatePartitionDto>(x)).ToList()
                });

                await CreateTestsAsync(new CreateCourseTestsDto
                {
                    CourseTemplateId = createdTemplate.Id,
                    Tests = template.CourseTests.Select(x => ObjectMapper.Map<CreateCourseTestDto>(x)).ToList()
                });

                await CreateRestrictionsAsync(new CreateCourseRestrictionsDto
                {
                    CourseTemplateId = createdTemplate.Id,
                    Restrictions = template.CourseRestrictions.Select(x => ObjectMapper.Map<CreateCourseRestrictionDto>(x)).ToList()
                });

                return await GetAsync(new EntityDto<Guid>(createdTemplate.Id));
            }
            else
            {
                throw new Exception("Template not found");
            }
        }
    }
}
