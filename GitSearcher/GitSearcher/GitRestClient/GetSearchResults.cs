using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

namespace GitSearcher.GitRestClient
{
    //Class that is responsible for communicating with Git API
    public class GetSearchResults<T>
    {
        private const string GitAPI = Settings.RestUrl;
        private const string Key = "";
        HttpClient _httpClient = new HttpClient();
        private JsonSerializer _serializer = new JsonSerializer();
        public async Task<T> GetAllUsers(string query)
        {
            //The actual request to Git API that returns 100 users of the search query
            //P.S. :Potentially a page numerator can be created and all of the responses can be retrieved in the app
            var response = await _httpClient.GetAsync(GitAPI + query + "&per_page=100", HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            //The deserialization of the response to an object
            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            using (var json = new JsonTextReader(reader))
            {
                return _serializer.Deserialize<T>(json);
            }
            
        }
    }
}