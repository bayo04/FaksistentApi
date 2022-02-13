using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Faksistent.Configuration;

namespace Faksistent.Web.Host.Startup
{
    [DependsOn(
       typeof(FaksistentWebCoreModule))]
    public class FaksistentWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public FaksistentWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FaksistentWebHostModule).GetAssembly());
        }
    }
}
