using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses.CourseTemplates.Dto
{
    public class CourseTemplateRequestDto
    {
        public bool? IsPublic { get; set; }

        public string Name { get; set; }

        public Guid? UserSemesterId { get; set; }

        public Guid? CourseId { get; set; }
    }
}
