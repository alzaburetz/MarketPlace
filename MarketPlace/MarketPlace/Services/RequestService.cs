using System;
using System.Collections.Generic;
using System.Text;

using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Xamarin.Forms;
using System.IO;

namespace MarketPlace.Services
{
    public class RequestService : IRequest
    {
        private string endpoint;
        private string token;
        public string Token { get => token; set => token = value; }
        public string Endpoint { get => endpoint; set => endpoint = value; }
        private HttpClient client;
        private JsonSerializerSettings SerializerSettings { get; set; }

        public RequestService()
        {
            client = new HttpClient();
            client.BaseAddress = new System.Uri("https://sharing-byteteam.ru");
            SerializerSettings = new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            };
            TrySetToken();
        }

        private void TrySetToken()
        {
            try
            {
                Token = Application.Current.Properties["Token"].ToString();
            } catch
            {
                Token = "";
            }
        }
        public async Task<string> GetResponse(string endpoint, bool token)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (token)
            {
                client.DefaultRequestHeaders.Add("Token", this.Token);
            }
            var response = await client.GetAsync(string.Concat("api/v1/", endpoint));
            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<T> GetRequest<T>(string endpoint, bool token)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (token)
            {
                client.DefaultRequestHeaders.Add("Token", this.Token);
            }
            var response = await client.GetAsync(string.Concat("api/v1/", endpoint));
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                try
                {
                    return JsonConvert.DeserializeObject<T>(body, SerializerSettings);
                }
                catch
                {
                    return default(T);
                }
            else
                return default(T);
        }

        public async Task<T> PostRequest<T,D>(string endpoint, D postData, bool token)
        {
            client.DefaultRequestHeaders.Clear();
            var formData = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (token)
            {
                client.DefaultRequestHeaders.Add("Token", this.Token);
            }
            var response = await client.PostAsync(string.Concat("api/v1/", endpoint), formData);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var obj = JsonConvert.DeserializeObject<T>(body, SerializerSettings);
                    return obj;
                }
                catch
                {
                    return default(T);
                }
            }
                 
            else
                return default(T);
        }

        public async Task<string> PostRequest<T>(string endpoint, T postData, bool token)
        {
            client.DefaultRequestHeaders.Clear();
            var formData = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (token)
            {
                client.DefaultRequestHeaders.Add("Token", this.Token);
            }
            var response = await client.PostAsync(string.Concat("api/v1/", endpoint), formData);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return body;
            else
                return string.Empty;
        }

        public async Task<string> UploadFile(string endpoint, byte[] file)
        {
            client.DefaultRequestHeaders.Clear();
            var image = new MemoryStream(file);
            var content = new StreamContent(image);
            var form = new MultipartFormDataContent();
            form.Add(content, "file", "file.jpg");
            client.DefaultRequestHeaders.Add("Token", this.Token);

            var response = await client.PostAsync(string.Concat("api/v1/", endpoint), form);
            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<string> PostWebForm(string adress, Dictionary<string, string> form)
        {
            var client = new HttpClient()
            {
                BaseAddress = new System.Uri("https://skat.server.paykeeper.ru/")
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            var content = new FormUrlEncodedContent(form);
            var response = await client.PostAsync("create/", content);
            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task GetRequest<T>(string endpoint, bool token, Action<HttpStatusCode, T> _callback)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (token)
            {
                client.DefaultRequestHeaders.Add("Token", this.Token);
            }
            var response = await client.GetAsync(string.Concat("api/v1/", endpoint));
            var body = await response.Content.ReadAsStringAsync();
            try
            {
                var obj = JsonConvert.DeserializeObject<T>(body, SerializerSettings);
                _callback.Invoke(response.StatusCode, obj);
            }
            catch
            {
                _callback.Invoke(response.StatusCode, default(T));
            }
        }
    }
}
