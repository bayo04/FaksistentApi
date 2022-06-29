using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Faksistent.Comments.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
            return Repository.GetAllIncluding(x => x.CreatorUser)
                .Include(x => x.Children).ThenInclude(x => x.CreatorUser)
                .Where(x => !x.ParentId.HasValue)
                .WhereIf(input.CourseId.HasValue, x => x.CourseId == input.CourseId.Value)
                .WhereIf(!string.IsNullOrEmpty(input.Tag), x => x.Tag == input.Tag);
        }

        public override async Task<CommentDto> GetAsync(EntityDto<Guid> input)
        {
            var comment = Repository.GetAllIncluding(x => x.CreatorUser).Include(x => x.Children).ThenInclude(x => x.CreatorUser)
                .FirstOrDefault(x => x.Id == input.Id);

            return ObjectMapper.Map<CommentDto>(comment);
        }
    }
}
