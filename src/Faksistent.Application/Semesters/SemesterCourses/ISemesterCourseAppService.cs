using Abp.Application.Services;
using Faksistent.Semesters.SemesterCourses.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Semesters.SemesterCourses
{
    public interface ISemesterCourseAppService : IAsyncCrudAppService<SemesterCourseDto, Guid, SemesterCourseRequestDto, CreateSemesterCourseDto, UpdateSemesterCourseDto>
    {
        Task CreateCoursesForSemester(CreateMultiSemesterCoursesDto input);

        Task SetTemplate(SetTemplateDto entity);
    }
}
