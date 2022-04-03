using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Comments.Dto
{
    public class UpdateCommentDto : IEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}
