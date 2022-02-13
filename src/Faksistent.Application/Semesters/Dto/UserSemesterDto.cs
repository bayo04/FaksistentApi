using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Faksistent.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Semesters.Dto
{
    [AutoMapFrom(typeof(UserSemester))]
    public class UserSemesterDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public int SemesterNo { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsSelected { get; set; }

        public int? TenantId { get; set; }
    }
}
