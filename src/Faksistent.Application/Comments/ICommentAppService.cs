using Abp.Application.Services;
using Faksistent.Comments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Comments
{
    public interface ICommentAppService : IAsyncCrudAppService<CommentDto, Guid, CommentRequestDto, CreateCommentDto, UpdateCommentDto>
    {
    }
}
