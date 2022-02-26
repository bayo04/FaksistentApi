using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Faksistent.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Semesters
{
    public class UserSemester : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public const int MaxNameLength = 128;

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        public int SemesterNo { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsSelected { get; set; }

        public int TenantId { get; set; }

        public List<SemesterCourse> SemesterCourses { get; set; }
    }
}
