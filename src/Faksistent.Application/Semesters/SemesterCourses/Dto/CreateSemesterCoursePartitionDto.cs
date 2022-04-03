using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Semesters.SemesterCourses.Dto
{
    [AutoMapTo(typeof(SemesterCoursePartition))]
    public class CreateSemesterCoursePartitionDto
    {
        public Guid? Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool IsRecorded { get; set; }

        public bool WasSignatureRecorded { get; set; }

        public bool WasPresent { get; set; }

        public Guid SemesterCourseId { get; set; }

        public Guid CoursePartitionId { get; set; }
    }
}
