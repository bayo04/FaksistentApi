using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Semesters.SemesterCourses.Dto
{
    public class SetPointsDto
    {
        public Guid CourseTestId { get; set; }

        public Guid SemesterCourseId { get; set; }

        public decimal Points { get; set; }
    }
}
