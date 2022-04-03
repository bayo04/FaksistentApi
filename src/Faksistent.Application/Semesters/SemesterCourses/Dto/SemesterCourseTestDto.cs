using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Semesters.SemesterCourses.Dto
{
    [AutoMapFrom(typeof(SemesterCourseTest))]
    public class SemesterCourseTestDto : EntityDto<Guid>
    {
        public decimal Points { get; set; }

        public Guid SemesterCourseId { get; set; }

        public Guid CourseTestId { get; set; }
    }
}
