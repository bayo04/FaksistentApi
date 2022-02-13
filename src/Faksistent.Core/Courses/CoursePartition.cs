using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses
{
    public class CoursePartition : FullAuditedEntity<Guid>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public Guid CourseTemplateId { get; set; }

        public int TotalAttendances { get; set; }

        public int AllowedAbsences { get; set; }

        public int AllowedAbsencesWithStimulation { get; set; }
    }
}
