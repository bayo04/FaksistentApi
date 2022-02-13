using Abp.Application.Services;
using Faksistent.Courses.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses
{
    public interface ICourseAppService : IAsyncCrudAppService<CourseDto, Guid, CourseRequestDto, CreateCourseDto, UpdateCourseDto>
    {
    }
}
