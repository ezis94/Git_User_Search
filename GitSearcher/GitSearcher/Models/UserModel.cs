using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace GitSearcher.Models
{

   //The model that represents the object created from Git response


    public class Item 
    {
        public int Total_count { get; set; }

        [JsonProperty("login")]
        public string name { get; set; }

        [JsonProperty("score")]
        public float score { get; set; }

        [JsonProperty("html_url")]
        public string url { get; set; }

        
    }

    public class UserModel

    {
        [JsonProperty("total_count")]
        public int Total_count { get; set; }

        public List<Item> items { get; set; }
    }

    

}
