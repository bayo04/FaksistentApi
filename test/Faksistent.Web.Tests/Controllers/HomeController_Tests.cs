using System.Threading.Tasks;
using Faksistent.Models.TokenAuth;
using Faksistent.Web.Controllers;
using Shouldly;
using Xunit;

namespace Faksistent.Web.Tests.Controllers
{
    public class HomeController_Tests: FaksistentWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}