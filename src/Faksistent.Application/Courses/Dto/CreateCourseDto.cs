using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses.Dto
{
    [AutoMapTo(typeof(Course))]
    public class CreateCourseDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ShortName { get; set; }

        public int SemesterNo { get; set; }
    }
}
