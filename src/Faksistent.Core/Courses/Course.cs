using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Faksistent.Semesters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses
{
    public class Course : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public int SemesterNo { get; set; }

        public int TenantId { get; set; }

        public List<SemesterCourse> SemesterCourses { get; set; }
    }
}
