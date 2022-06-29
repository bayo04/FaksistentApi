using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Faksistent.Authorization.Users;
using Faksistent.Courses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Comments
{
    public class Comment : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public string Content { get; set; }

        public Guid? ParentId { get; set; }

        public Guid? CourseId { get; set; }

        public string Tag { get; set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public Comment Parent { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }

        [ForeignKey(nameof(CreatorUserId))]
        public User CreatorUser { get; set; }

        public List<Comment> Children { get; set; }
    }
}
