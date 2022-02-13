using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Faksistent.Controllers
{
    public abstract class FaksistentControllerBase: AbpController
    {
        protected FaksistentControllerBase()
        {
            LocalizationSourceName = FaksistentConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
