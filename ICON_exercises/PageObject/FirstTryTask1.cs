using Newtonsoft.Json;
using RestSharp;
using Serilog;

namespace ICON_exercises.PageObject
{
    public class UserResponse
    {
        public int Page { get; set; }
        public int Per_Page { get; set; }
        public int Total { get; set; }
        public int Total_Pages { get; set; }
        public List<User> Data { get; set; }
        public Support Support { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Avatar { get; set; }
    }

    public class Support
    {
        public string Url { get; set; }
        public string Text { get; set; }
    }
    public class Tests
    {
        private const string url = "https://reqres.in/api/users?page=1";
        [SetUp]
        public void Setup()
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        }

        [Test]
        [Obsolete]
        public async Task Scenario1()
        {
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            var response = await client.ExecuteAsync(request);
            var userResponse = JsonConvert.DeserializeObject<UserResponse>(response.Content);

            Assert.Multiple(() =>
            {
                Assert.That((int)response.StatusCode, Is.EqualTo(200));
                Assert.That(userResponse.Page, Is.EqualTo(1));
                Assert.That(userResponse.Data, Is.Not.Empty);
                Assert.That(userResponse.Support.Url, Is.EqualTo("https://reqres.in/#support-heading"));
            });

            if (userResponse != null)
            {
                Assert.That(userResponse.Data.Count, Is.EqualTo(6));
            }

            int pages = int.Parse(url.Substring(url.IndexOf("=") + 1));
            Assert.That(pages, Is.EqualTo(userResponse.Page));

            var users = userResponse.Data;
            var userFound = false;

            foreach (var user in users)
            {
                if (user.First_name == "Janet"
                    && user.Last_name == "Weaver"
                    && user.Email == "janet.weaver@reqres.in"
                    && user.Avatar == "https://reqres.in/img/faces/2-image.jpg")
                {
                    userFound = true;
                    break;
                }
            }

            Assert.That(userFound, Is.True);


            Log.Information("Request URL: {Url}", client.BuildUri(request).ToString());
            Log.Information("HTTP Method: {Method}", request.Method);
            Log.Information("Status Code: {StatusCode}", (int)response.StatusCode);
            Log.Information("Response Body: {Response}", response.Content);
        }
    }
}