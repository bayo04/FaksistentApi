using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses.CourseTemplates.Dto
{
    public class CreateCourseRestrictionsDto
    {
        public Guid CourseTemplateId { get; set; }

        public List<CreateCourseRestrictionDto> Restrictions { get; set; }
    }
}
