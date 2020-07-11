using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LUM.Services.Material.Test.Helper
{
    public class IntegrationTestBase
    {
        protected readonly HttpClient TestClient;

        protected IntegrationTestBase()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        
                    });
                });

            TestClient = appFactory.CreateClient();
        }


        protected async Task<string> PostAsync<TRequest>(TRequest request,string url)
        {
            var response = await TestClient.PostAsJsonAsync(url, request);
            return await response.Content.ReadAsStringAsync();
        }
        protected async Task<TResponse> GetAsync<TResponse>(string url)
        {
            var response = await TestClient.GetAsync(url);
            return await response.Content.ReadAsAsync<TResponse>();
        }
        protected async Task<HttpStatusCode> UpdateAsync<TRequest>(TRequest request, string url)
        {
            var response = await TestClient.PutAsJsonAsync(url,request);
                return response.StatusCode;
        }
        protected async Task<HttpStatusCode> DeleteAsync( string url)
        {
            var response = await TestClient.DeleteAsync(url);
            return response.StatusCode;
        }
    }
}
