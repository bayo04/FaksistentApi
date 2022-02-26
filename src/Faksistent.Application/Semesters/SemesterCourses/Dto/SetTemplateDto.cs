using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Semesters.SemesterCourses.Dto
{
    public class SetTemplateDto
    {
        public Guid CourseTemplateId { get; set; }

        public Guid UserSemesterId { get; set; }
    }
}
