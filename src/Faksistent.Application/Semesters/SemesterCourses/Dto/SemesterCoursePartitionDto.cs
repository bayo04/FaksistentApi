using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Semesters.SemesterCourses.Dto
{
    [AutoMapFrom(typeof(SemesterCoursePartition))]
    public class SemesterCoursePartitionDto : EntityDto<Guid>
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool IsRecorded { get; set; }

        public bool WasSignatureRecorded { get; set; }

        public bool WasPresent { get; set; }

        public Guid SemesterCourseId { get; set; }

        public Guid CoursePartitionId { get; set; }
    }
}
