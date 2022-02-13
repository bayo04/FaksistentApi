using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses.CourseTemplates.Dto
{
    [AutoMapFrom(typeof(CourseRestriction))]
    public class CourseRestrictionDto
    {
        public Guid Id { get; set; }

        public decimal PointsForPass { get; set; }

        public decimal PointsForSignature { get; set; }

        public Guid CourseTemplateId { get; set; }

        public List<CourseRestrictionTestDto> Tests { get; set; }
    }
}
