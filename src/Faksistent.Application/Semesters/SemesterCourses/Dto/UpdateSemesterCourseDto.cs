using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Semesters.SemesterCourses.Dto
{
    [AutoMapFrom(typeof(SemesterCourseDto))]
    [AutoMapTo(typeof(SemesterCourse))]
    public class UpdateSemesterCourseDto : CreateSemesterCourseDto, IEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}
