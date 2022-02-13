using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Semesters.Dto
{
    [AutoMapTo(typeof(UserSemester))]
    public class CreateUserSemesterDto
    {
        [Required]
        [MaxLength(UserSemester.MaxNameLength)]
        public string Name { get; set; }

        public int SemesterNo { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsSelected { get; set; }
    }
}
