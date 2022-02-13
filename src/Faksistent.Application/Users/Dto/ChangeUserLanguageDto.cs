using System.ComponentModel.DataAnnotations;

namespace Faksistent.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}