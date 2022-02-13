using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses.CourseTemplates.Dto
{
    [AutoMapFrom(typeof(CourseRestrictionTest))]
    public class CourseRestrictionTestDto
    {
        public Guid CourseTestId { get; set; }

        public Guid CourseRestrictionId { get; set; }

        public CourseTestDto CourseTest { get; set; }
    }
}
