using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Faksistent.Courses.Dto;
using Faksistent.Semesters.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Semesters.SemesterCourses.Dto
{
    [AutoMapFrom(typeof(SemesterCourse))]
    public class SemesterCourseDto : EntityDto<Guid>
    {
        public Guid UserSemesterId { get; set; }

        public Guid CourseId { get; set; }

        public Guid? CourseTemplateId { get; set; }

        //public UserSemesterDto UserSemester { get; set; }

        public CourseDto Course { get; set; }
    }
}
