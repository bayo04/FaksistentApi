using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses.Dto
{
    public class CourseRequestDto
    {
        public int? SemesterNo { get; set; }

        public Guid? UserSemesterId { get; set; }
    }
}
