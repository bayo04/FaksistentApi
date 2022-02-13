using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses
{
    public class CourseRestriction : FullAuditedEntity<Guid>
    {
        public decimal PointsForPass { get; set; }

        public decimal PointsForSignature { get; set; }

        public Guid CourseTemplateId { get; set; }

        [ForeignKey(nameof(CourseTemplateId))]
        public CourseTemplate CourseTemplate { get; set; }

        public List<CourseRestrictionTest> Tests { get; set; }
    }
}
