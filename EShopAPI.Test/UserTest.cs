using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net;

namespace EShopAPI.Test
{
    [TestClass]
   public class UserTest
    {
        private HttpClient _client;

        public UserTest()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [TestMethod]
        public void UserGetAllTest()
        {
            var request = new HttpRequestMessage(new HttpMethod("Get"), "/Api/Users");

            var response = _client.SendAsync(request).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        [DataRow(1)]
        public void UserGetOneTest(int id)
        {
            var request = new HttpRequestMessage(new HttpMethod("Get"), $"/Api/Users/{id}");

            var response = _client.SendAsync(request).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [TestMethod]
        public void UserPostTest()
        {
            var request = new HttpRequestMessage(new HttpMethod("Post"), $"/Api/Users");
            var response = _client.SendAsync(request).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [TestMethod]
        public void UserPutTest()
        {
            var request = new HttpRequestMessage(new HttpMethod("Put"), $"/Api/Users");
            var response = _client.SendAsync(request).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [TestMethod]
        public void UserDeleteTest(int id)
        {
            var request = new HttpRequestMessage(new HttpMethod("Delete"), $"/Api/Users/{id}");
            var response = _client.SendAsync(request).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
