using System.Threading.Tasks;
using Faksistent.Configuration.Dto;

namespace Faksistent.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
