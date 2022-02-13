using Abp.Authorization;
using Faksistent.Authorization.Roles;
using Faksistent.Authorization.Users;

namespace Faksistent.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
