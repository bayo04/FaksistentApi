using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faksistent.Comments.Dto
{
    public class CommentRequestDto
    {
        public Guid? CourseId { get; set; }

        public string Tag { get; set; }
    }
}
