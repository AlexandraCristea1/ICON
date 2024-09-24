using ICON_exercises.PageObject;
using Newtonsoft.Json;
using RestSharp;
using Serilog;
using TechTalk.SpecFlow;

namespace ICON_exercises.StepDefinitions
{
    [Binding]
    internal class ScenariosStepsDefinitions
    {
        private string BaseUrl;
        private RestClient? client;
        private RestRequest? request;
        private RestResponse? response;
        private UserResponse? userResponse;

        [Given(@"^I have the API endpoint (.*)")]
        public void GivenIHaveTheAPIEndpointAsync(string url)
        {
            BaseUrl = url;
        }

        [When(@"I send a GET request to the API endpoint")]
        public async Task WhenISendAGETRequestToTheAPIEndpoint()
        {
            client = new RestClient(BaseUrl);
            request = new RestRequest(BaseUrl, Method.Get);
            response = await client.ExecuteAsync(request);
            userResponse = JsonConvert.DeserializeObject<UserResponse>(response.Content);
        }

        [Then(@"the API request should return a successful response")]
        public void ThenTheAPIRequestShouldReturnASuccessfulResponse()
        {
            Assert.Multiple(() =>
            {
                Assert.That((int)response.StatusCode, Is.EqualTo(200));
                Assert.That(userResponse.Data, Is.Not.Empty);
                Assert.That(userResponse.Support.Url, Is.EqualTo("https://reqres.in/#support-heading"));
            });
        }

        [Then(@"^the API request should return (.*) users in total")]
        public void ThenTheAPIRequestShouldReturnUsersInTotal(int expectedCount)
        {
            if (userResponse != null)
            {
                Assert.That(userResponse.Data.Count, Is.EqualTo(expectedCount));
            }
        }

        [Then(@"the page number returned matches the one specified in the URL")]
        public void ThenThePageNumberReturnedMatchesTheOneSpecifiedInTheURL()
        {
            int pages = int.Parse(BaseUrl.Substring(BaseUrl.IndexOf("=") + 1));
            Assert.That(pages, Is.EqualTo(userResponse.Page));
        }

        [Then(@"the API request should return a user with specific information:")]
        public void ThenTheAPIRequestShouldReturnAUserWithSpecificInformation(Table table)
        {
            var row = table.Rows.Select(x => x.Values.ToArray());

            var users = userResponse.Data;
            var userFound = false;

            foreach (var user in users)
            {
                for (int i = 0; i < row.Count(); i++)
                {
                    if (row.ElementAt(i).Contains(user.Email))
                    {
                        userFound = true;
                        break;
                    }
                }
            }

            Assert.That(userFound, Is.True);
        }

        [Then(@"the API request should return no response")]
        public void ThenTheAPIRequestShouldReturnNoResponse()
        {
            Assert.That(userResponse.Data, Is.Empty);
        }

        [Then(@"I log specific information from page")]
        public void ThenILogSpecificInformationFromPage()
        {
            Log.Information("Request URL: {Url}", client.BuildUri(request).ToString());
            Log.Information("HTTP Method: {Method}", request.Method);
            Log.Information("Status Code: {StatusCode}", (int)response.StatusCode);
            Log.Information("Response Body: {Response}", response.Content);
        }
    }
}
