using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

namespace GitSearcher.GitRestClient
{
    public class GetSearchResults<T>
    {
        private const string OpenWeatherApi = Settings.RestUrl;
        private const string Key = "653b1f0bf8a08686ac505ef6f05b94c2";
        HttpClient _httpClient = new HttpClient();
        private JsonSerializer _serializer = new JsonSerializer();
        public async Task<T> GetAllUsers(string query)
        {


        
    //Potentially a page numerator can be created and all of the responses can be retrieved in the app
            var response = await _httpClient.GetAsync(OpenWeatherApi + query + "&per_page=100", HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            using (var json = new JsonTextReader(reader))
            {
                return _serializer.Deserialize<T>(json);
            }
            
        }
    }
}