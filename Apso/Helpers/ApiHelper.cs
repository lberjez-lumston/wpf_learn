using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Apso.Helpers
{
    public class ApiHelper<T>
    {
        private string url { get; set; }
        private HttpClient client { get; set; }

        #region Initialization
        public ApiHelper(string url)
        {
            this.url = url;
            client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(15);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void addHeaders(Dictionary<string, string> headers)
        {
            foreach (KeyValuePair<string, string> item in headers)
            {
                addHeader(item.Key, item.Value);
            }
        }

        public void addHeader(string key, string value)
        {
            if (client.DefaultRequestHeaders.GetValues(key).Count() > 0)
                client.DefaultRequestHeaders.Remove(key);

            client.DefaultRequestHeaders.Add(key, value);
        }
        #endregion

        #region Methods
        public async Task<T> Get(Uri u)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            await Task.Run(async () => {
                response = await client.GetAsync(u);
            });

            if (response.IsSuccessStatusCode)
            {
                IApiResponse apiResponse = await response.Content.ReadAsAsync<IApiResponse>();
                if (apiResponse.success)
                    return JsonConvert.DeserializeObject<T>(apiResponse.data.ToString());
                else
                    throw new Exception(apiResponse.message);
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        public async Task<T> Post(Uri u, HttpContent c)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            await Task.Run(async () => {
                response = await client.PostAsync(u, c);
            });

            if (response.IsSuccessStatusCode)
            {
                IApiResponse apiResponse = await response.Content.ReadAsAsync<IApiResponse>();

                if (apiResponse.success)
                    return JsonConvert.DeserializeObject<T>(apiResponse.data.ToString());
                else
                    throw new Exception(apiResponse.message);
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        public async Task<T> Put(Uri u, HttpContent c)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            await Task.Run(async () => {
                response = await client.PutAsync(u, c);
            });

            if (response.IsSuccessStatusCode)
            {
                IApiResponse apiResponse = await response.Content.ReadAsAsync<IApiResponse>();

                if (apiResponse.success)
                    return JsonConvert.DeserializeObject<T>(apiResponse.data.ToString());
                else
                    throw new Exception(apiResponse.message);
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        public async Task<T> Delete(Uri u)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            await Task.Run(async () => {
                response = await client.DeleteAsync(u);
            });

            if (response.IsSuccessStatusCode)
            {
                IApiResponse apiResponse = await response.Content.ReadAsAsync<IApiResponse>();

                if (apiResponse.success)
                    return JsonConvert.DeserializeObject<T>(apiResponse.data.ToString());
                else
                    throw new Exception(apiResponse.message);
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }
        #endregion
    }
}
