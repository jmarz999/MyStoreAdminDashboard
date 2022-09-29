using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProductRepository
{
    public static class ProductRepository
    {
        public static async Task<T> Get<T>(string url)
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url).ConfigureAwait(false);
                T obj = (T)Activator.CreateInstance(typeof(T));

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<T>(json);
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public static async Task<T> Create<T>(string url)
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url).ConfigureAwait(false);
                T obj = (T)Activator.CreateInstance(typeof(T));

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<T>(json);
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public static async Task<T> Delete<T>(string url)
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url).ConfigureAwait(false);
                T obj = (T)Activator.CreateInstance(typeof(T));

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<T>(json);
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public static async Task<T> Update<T>(string url)
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url).ConfigureAwait(false);
                T obj = (T)Activator.CreateInstance(typeof(T));

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<T>(json);
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}