using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses.CourseTemplates.Dto
{
    public class CreateCourseTestsDto
    {
        public Guid CourseTemplateId { get; set; }

        public List<CreateCourseTestDto> Tests { get; set; }
    }
}
