using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Courses.CourseTemplates.Dto
{
    public class CourseTemplateMapProfile : Profile
    {
        public CourseTemplateMapProfile()
        {
            CreateMap<CourseRestrictionDto, CreateCourseRestrictionDto>().ForMember(x => x.CourseTestIds,
                opt => opt.MapFrom(x => x.Tests.Select(p => p.CourseTestId)));

        }
    }
}
