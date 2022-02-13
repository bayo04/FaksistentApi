using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses
{
    public class CourseTest : FullAuditedEntity<Guid>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public Guid CourseTemplateId { get; set; }

        public decimal TotalPoints { get; set; }

        public decimal PointsForPass { get; set; }

        public decimal PointsForSignature { get; set; }
    }
}
