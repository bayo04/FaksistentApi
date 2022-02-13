using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses.CourseTemplates.Dto
{
    [AutoMapTo(typeof(CourseTemplate))]
    public class CreateCourseTemplateDto
    {
        public string Name { get; set; }

        public Guid? SemesterCourseId { get; set; }

        public Guid CourseId { get; set; }

        public bool IsPublic { get; set; }
    }
}
