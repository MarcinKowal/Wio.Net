
namespace Wio.Net.Tests
{
    using System;
    using Wio.Net;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class Tests
    {
        private WioClient cut;

        [TestInitialize]
        public void Init()
        {
            this.cut = new WioClient(new Uri(Constants.ServerUri));
        }

        [TestMethod]
        public async Task ShouldReturnUserTokenWhenLoginWithValidCredentials()
        {
            var token = await this.cut.LoginAsync(Constants.Email, Constants.Password);


            //var nodes = await this.cut.GetNodesAsync(token.AuthenticationKey);

            //var nodeToken = await this.cut.CreateNodeAsync(token.AuthenticationKey, "node from code");


            //nodes = await this.cut.GetNodesAsync(token.AuthenticationKey);


            Assert.IsNotNull(token);
            Assert.AreNotEqual(string.Empty, token.AuthenticationKey);
            Assert.AreNotEqual(string.Empty, token.UserId);
        }

        [TestMethod]
        public async Task ShouldReturnTokenWhenUserCreated()
        {
            const string FakeEmail = "aa1a@fake.com";
            const string FakePassword = "fakePassword";

            var token = await this.cut.CreateUserAsync(FakeEmail, FakePassword);
            Assert.IsNotNull(token);
            Assert.AreNotEqual(string.Empty,token.AuthenticationKey);
            Assert.IsNull(token.UserId);
        }
    }
}
