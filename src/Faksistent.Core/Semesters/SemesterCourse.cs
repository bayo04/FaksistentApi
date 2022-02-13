﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Faksistent.Courses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Semesters
{
    public class SemesterCourse : FullAuditedEntity<Guid>
    {
        public Guid UserSemesterId { get; set; }

        public Guid CourseId { get; set; }

        [ForeignKey(nameof(UserSemesterId))]
        public UserSemester UserSemester { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
    }
}
