using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Faksistent.Semesters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses
{
    public class CourseTemplate : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public string Name { get; set; }

        public Guid? SemesterCourseId { get; set; }

        public Guid CourseId { get; set; }

        public bool IsPublic { get; set; }

        public int TenantId { get; set; }

        public List<CoursePartition> CoursePartitions { get; set; }

        public List<CourseTest> CourseTests { get; set; }

        public List<CourseRestriction> CourseRestrictions { get; set; }

        [ForeignKey(nameof(SemesterCourseId))]
        public SemesterCourse SemesterCourse { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
    }
}
