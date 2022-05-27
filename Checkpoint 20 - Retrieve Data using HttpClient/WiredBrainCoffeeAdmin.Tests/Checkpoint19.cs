using HtmlAgilityPack;
using Moq;
using Moq.Protected;
using SoloX.CodeQuality.Test.Helpers.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using WiredBrainCoffeeAdmin.Data;
using WiredBrainCoffeeAdmin.Data.Models;
using Xunit;

namespace WiredBrainCoffeeAdmin.Tests
{
    public class Checkpoint19
    {
        [Fact]
        public async void CH20_VerifyHttpClientGetData()
        {
            var items = JsonSerializer.Deserialize<List<HelpTicket>>("[{\"Id\":1,\"Title\":\"Menu item issue\",\"Description\":\"Adding a new menu item sometimes errors.\",\"Status\":\"Pending\"}]");
            
            // ARRANGE
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent("[{\"id\":1,\"title\":\"Menu item issue\",\"description\":\"Adding a new menu item sometimes errors.\",\"status\":\"Pending\"}]"),
               })
               .Verifiable();

            // use real http client with mocked handler here
            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://wiredbraincoffeeadmin.azurewebsites.net/api/tickets"),
            };

            var subjectUnderTest = new TicketService(httpClient);

            // ACT
            var result = await subjectUnderTest.GetAll();

            // Assert
            Assert.True(result != null && items.FirstOrDefault()?.Title == result.FirstOrDefault()?.Title);
        }
    }
}