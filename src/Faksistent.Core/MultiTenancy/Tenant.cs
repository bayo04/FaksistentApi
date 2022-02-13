using Abp.MultiTenancy;
using Faksistent.Authorization.Users;

namespace Faksistent.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public int NoOfSemesters { get; set; }

        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
