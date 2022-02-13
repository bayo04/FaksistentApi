using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Faksistent.Configuration.Dto;

namespace Faksistent.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : FaksistentAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
