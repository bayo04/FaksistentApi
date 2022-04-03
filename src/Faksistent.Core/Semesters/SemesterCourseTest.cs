using Abp.Domain.Entities.Auditing;
using Faksistent.Courses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Semesters
{
    public class SemesterCourseTest : FullAuditedEntity<Guid>
    {
        public decimal Points { get; set; }

        public Guid SemesterCourseId { get; set; }

        public Guid CourseTestId { get; set; }

        [ForeignKey(nameof(SemesterCourseId))]
        public SemesterCourse SemesterCourse { get; set; }

        [ForeignKey(nameof(CourseTestId))]
        public CourseTest CourseTest { get; set; }
    }
}
