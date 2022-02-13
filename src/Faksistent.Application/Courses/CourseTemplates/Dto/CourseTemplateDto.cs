using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Faksistent.Courses.Dto;
using Faksistent.Semesters.SemesterCourses.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses.CourseTemplates.Dto
{
    [AutoMapFrom(typeof(CourseTemplate))]
    public class CourseTemplateDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public Guid? SemesterCourseId { get; set; }

        public Guid CourseId { get; set; }

        public bool IsPublic { get; set; }

        public SemesterCourseDto SemesterCourse { get; set; }

        public CourseDto Course { get; set; }

        public List<CoursePartitionDto> CoursePartitions { get; set; }

        public List<CourseTestDto> CourseTests { get; set; }

        public List<CourseRestrictionDto> CourseRestrictions { get; set; }
    }
}
