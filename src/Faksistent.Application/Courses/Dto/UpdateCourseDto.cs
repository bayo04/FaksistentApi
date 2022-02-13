using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses.Dto
{
    [AutoMapFrom(typeof(CourseDto))]
    [AutoMapTo(typeof(Course))]
    public class UpdateCourseDto : CreateCourseDto, IEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}
