using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses.CourseTemplates.Dto
{
    [AutoMapTo(typeof(CourseTest))]
    [AutoMapFrom(typeof(CourseTestDto))]
    public class CreateCourseTestDto
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public decimal TotalPoints { get; set; }

        public decimal PointsForPass { get; set; }

        public decimal PointsForSignature { get; set; }
    }
}
