using Microsoft.Owin.Hosting;
using NUnit.Framework;
using System;
using System.Net.Http;

namespace TicketMaster.Tests.Integration
{
    [TestFixture]
    public class TicketsApiTests
    {
        [Test]
        public void Get_Tickets_Should_Be_Successfull()
        {
            // Setup - Should be extracted into a one-time setup
            // Could also be extracted into a fixture-setup
            // Port-Number should be random and ideally find an empty port
            // because port doesn't get release right away
            var baseAddress = "http://localhost:9000/";
            var webApp = WebApp.Start<TestAppStartup>(url: baseAddress);
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            var httpClient = new HttpClient(handler) { BaseAddress = new Uri(baseAddress) };

            // Exercise SUT
            var response = httpClient.GetAsync("api/tickets").Result;

            // Verify
            Assert.IsTrue(response.IsSuccessStatusCode, "Actual Status Code " + response.StatusCode);

            // Cleanup
            // This should also be extracted into a one-time tear-down
            httpClient.Dispose();
            webApp.Dispose();
        }
    }
}
