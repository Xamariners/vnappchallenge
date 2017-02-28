using System;
using Newtonsoft.Json;

namespace AzureMobileApp
{
    public class myTable
    {
        string desc;
        string name;
        string url;
        string id;

        [JsonProperty(PropertyName = "ID")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty(PropertyName = "NAME")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [JsonProperty(PropertyName = "DESC")]
        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }

        [JsonProperty(PropertyName = "URL")]
        public string URL
        {
            get { return url; }
            set { url = value; }
        }

    }
}
