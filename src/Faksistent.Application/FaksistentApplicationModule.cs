using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Faksistent.Authorization;

namespace Faksistent
{
    [DependsOn(
        typeof(FaksistentCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class FaksistentApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<FaksistentAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(FaksistentApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
