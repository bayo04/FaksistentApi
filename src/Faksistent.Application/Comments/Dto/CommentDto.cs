using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Comments.Dto
{
    [AutoMapFrom(typeof(Comment))]
    public class CommentDto : EntityDto<Guid>
    {
        public string Content { get; set; }

        public Guid? ParentId { get; set; }

        public Guid? CourseId { get; set; }

        public string Tag { get; set; }

        public DateTime CreationTime { get; set; }

        public string CreatorUserUserName { get; set; }

        public List<CommentDto> Children { get; set; }
    }
}
