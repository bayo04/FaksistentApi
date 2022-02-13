using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Semesters.SemesterCourses.Dto
{
    [AutoMapTo(typeof(SemesterCourse))]
    public class CreateSemesterCourseDto
    {
        public Guid UserSemesterId { get; set; }

        public Guid CourseId { get; set; }
    }
}
