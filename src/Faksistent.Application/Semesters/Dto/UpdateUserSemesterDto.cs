using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Semesters.Dto
{
    [AutoMapFrom(typeof(UserSemesterDto))]
    [AutoMapTo(typeof(UserSemester))]
    public class UpdateUserSemesterDto : CreateUserSemesterDto, IEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}
