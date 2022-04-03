using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Comments.Dto
{
    [AutoMapTo(typeof(Comment))]
    public class CreateCommentDto
    {
        public string Content { get; set; }

        public Guid? ParentId { get; set; }

        public Guid? CourseId { get; set; }

        public string Tag { get; set; }
    }
}
