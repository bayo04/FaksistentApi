using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Semesters.SemesterCourses.Dto
{
    public class CreateMultiSemesterCoursesDto
    {
        public Guid UserSemesterId { get; set; }

        public List<CreateSemesterCourseDto> Courses { get; set; }
    }
}
