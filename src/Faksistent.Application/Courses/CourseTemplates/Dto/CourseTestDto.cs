using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses.CourseTemplates.Dto
{
    [AutoMapFrom(typeof(CourseTest))]
    public class CourseTestDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public decimal TotalPoints { get; set; }

        public decimal PointsForPass { get; set; }

        public decimal PointsForSignature { get; set; }
    }
}
