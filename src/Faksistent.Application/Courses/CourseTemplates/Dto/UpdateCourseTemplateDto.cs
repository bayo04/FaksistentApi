using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses.CourseTemplates.Dto
{
    [AutoMapFrom(typeof(CourseTemplateDto))]
    [AutoMapTo(typeof(CourseTemplate))]
    public class UpdateCourseTemplateDto : CreateCourseTemplateDto, IEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}
