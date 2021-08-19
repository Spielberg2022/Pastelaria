using System;
using System.Net.Http;
using System.Net.Http.Headers;


namespace _2_Pastelaria.Application.Infra
{
    public abstract class BaseApplication
    {
        protected readonly HttpClient _httpClient;

        protected BaseApplication(string uri)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(uri);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
