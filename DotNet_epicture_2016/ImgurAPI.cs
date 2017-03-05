using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_epicture_2016
{
    public class ImgurAPI
    {
        private string ClientId = "3029bb298f15f24";
        private string ClientSecret = "ada3123a9c9e56bb4e73b99d8d4599d0dd42e833";
        private string BasicUri = "https://api.imgur.com/3/";
        private HttpClient HttpClient = new HttpClient();
        public ImgurAPI()
        {
            HttpClient.DefaultRequestHeaders.Add("Authorization", "Client-ID " + ClientId);
        }

        private async Task<HttpContent> doRequest(string urlQuery)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(urlQuery);
            return response.Content;
        }
        public async Task<HttpContent> getImages(string search, string size, string imageType, int page)
        {
            var url = BasicUri + "gallery/search/top/" + page.ToString();
            url += "?q_exactly=" + search;
            if (size != "any")
            {
                url += "?q_size_px=" + size;
            }
            if (imageType != "any")
            {
                url += "?q_type=" + imageType;
            }
            return await doRequest(url);
        }

        public async Task<HttpResponseMessage> uploadFile(byte[] file, string title, string description)
        {

            string fileToString = Convert.ToBase64String(file);
            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Add(new StringContent(title), "title");
            form.Add(new StringContent(title), "name");
            form.Add(new StringContent("file"), "base64");
            form.Add(new StringContent(fileToString), "image");

           // string fileToString = System.Text.Encoding.UTF8.GetString(file);
          //  string fileToString = Convert.ToBase64String(file);
            var jsonString = JsonConvert.SerializeObject(new[]
            {
                new KeyValuePair<string, string>("title", title),
                new KeyValuePair<string, string>("name", title),
                new KeyValuePair<string, string>("type", "base64"),
                new KeyValuePair<string, string>("image", fileToString),
                new KeyValuePair<string, string>("description", description)
            });
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            try
            {
                string url = BasicUri + "image.json";
                HttpResponseMessage msg=  await HttpClient.PostAsync(url, form);
                HttpContent pepe = msg.Content;
                string jsoncontent = pepe.ReadAsStringAsync().Result;
                return msg;
            }
            catch (Exception e)
            {
                int a = 0;
            }
            return null;
        }
    }
}
