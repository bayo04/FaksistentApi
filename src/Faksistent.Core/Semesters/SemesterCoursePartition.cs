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
    public class SemesterCoursePartition : FullAuditedEntity<Guid>
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool IsRecorded { get; set; }

        public bool WasSignatureRecorded { get; set; }

        public bool WasPresent { get; set; }

        public Guid SemesterCourseId { get; set; }

        public Guid CoursePartitionId { get; set; }

        [ForeignKey(nameof(SemesterCourseId))]
        public SemesterCourse SemesterCourse { get; set; }

        [ForeignKey(nameof(CoursePartitionId))]
        public CoursePartition CoursePartition { get; set; }
    }
}
