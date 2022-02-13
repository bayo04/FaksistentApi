using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses
{
    public class CourseRestrictionTest : FullAuditedEntity<Guid>
    {
        public Guid CourseTestId { get; set; }

        public Guid CourseRestrictionId { get; set; }


        [ForeignKey(nameof(CourseTestId))]
        public CourseTest CourseTest { get; set; }


        [ForeignKey(nameof(CourseRestrictionId))]
        public CourseRestriction CourseRestriction { get; set; }
    }
}
