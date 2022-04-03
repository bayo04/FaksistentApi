using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Faksistent.Comments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Comments
{
    [AbpAuthorize]
    public class CommentAppService : AsyncCrudAppService<Comment, CommentDto, Guid, CommentRequestDto, CreateCommentDto, UpdateCommentDto>,
        ICommentAppService
    {
        public CommentAppService(IRepository<Comment, Guid> repository) : base(repository)
        {
        }

        protected override IQueryable<Comment> CreateFilteredQuery(CommentRequestDto input)
        {
            return Repository.GetAll();
        }
    }
}
