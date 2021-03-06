using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses.CourseTemplates.Dto
{
    [AutoMapTo(typeof(CourseRestriction))]
    [AutoMapFrom(typeof(CourseRestrictionDto))]
    public class CreateCourseRestrictionDto
    {
        public decimal PointsForPass { get; set; }

        public decimal PointsForSignature { get; set; }

        public List<Guid> CourseTestIds { get; set; }
    }
}
