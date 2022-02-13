using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Faksistent.EntityFrameworkCore;
using Faksistent.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Faksistent.Web.Tests
{
    [DependsOn(
        typeof(FaksistentWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class FaksistentWebTestModule : AbpModule
    {
        public FaksistentWebTestModule(FaksistentEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FaksistentWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(FaksistentWebMvcModule).Assembly);
        }
    }
}