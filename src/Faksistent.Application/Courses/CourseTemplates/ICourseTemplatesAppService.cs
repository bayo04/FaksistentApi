using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Faksistent.Courses.CourseTemplates.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses.CourseTemplates
{
    public interface ICourseTemplatesAppService : IAsyncCrudAppService<CourseTemplateDto, Guid, CourseTemplateRequestDto, CreateCourseTemplateDto, UpdateCourseTemplateDto>
    {
        Task<CourseTemplateDto> CreatePartitionsAsync(CreatePartitionsDto input);

        Task<CourseTemplateDto> CreateTestsAsync(CreateCourseTestsDto input);

        Task<CourseTemplateDto> CreateRestrictionsAsync(CreateCourseRestrictionsDto input);

        Task<CourseTemplateDto> CreatePrivate(EntityDto<Guid> input);
    }
}
