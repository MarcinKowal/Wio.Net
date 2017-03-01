
namespace Wio.Net.Tests
{
    using System;
    using Wio.Net;
    using Xunit;
    using System.Threading.Tasks;

    public class Tests
    {
        private readonly WioClient cut;

        public Tests()
        {
            this.cut = new WioClient(new Uri(Constants.ServerUri));
        }

        [Fact]
        public async Task ShouldReturnUserTokenWhenLoginWithValidCredentials()
        {
            var token = await this.cut.LoginAsync(Constants.Email, Constants.Password);


            //var nodes = await this.cut.GetNodesAsync(token.AuthenticationKey);

            //var nodeToken = await this.cut.CreateNodeAsync(token.AuthenticationKey, "node from code");


            //nodes = await this.cut.GetNodesAsync(token.AuthenticationKey);


            Assert.NotNull(token);
            Assert.NotEmpty(token.AuthenticationKey);
            Assert.NotEmpty(token.UserId);
        }

        [Fact]
        public async Task ShouldReturnTokenWhenUserCreated()
        {
            const string FakeEmail = "aa1a@fake.com";
            const string FakePassword = "fakePassword";

            var token = await this.cut.CreateUserAsync(FakeEmail, FakePassword);
            Assert.NotNull(token);
            Assert.NotEmpty(token.AuthenticationKey);
            Assert.Null(token.UserId);
        }
    }
}
