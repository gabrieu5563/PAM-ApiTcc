using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace ApiTcc.Services
{
    public class Request
    {
        public async Task<TResult> GetAsync<TResult>(string uri)
        {
            HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync(uri);
            string serialized = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(serialized);

            return JsonConvert.DeserializeObject<TResult>(serialized);
        }

        public async Task<TResult> PostAsync<TResult>(string uri, TResult data)
        {
            HttpClient client = new();
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(uri, content);
            string serialized = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return JsonConvert.DeserializeObject<TResult>(serialized);
            }
            else
            {
                throw new Exception(serialized);
            }
        }


        public async Task<int> PutAsync<TResult>(string uri, TResult data)
        {
            HttpClient client = new();
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(uri, content);
            string serialized = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return 1;
            }
            else
            {
                throw new Exception(serialized);
            }
        }


        public async Task DeleteAsync(string uri)
        {
            HttpClient client = new();

            HttpResponseMessage response = await client.DeleteAsync(uri);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("Requisição não encontrada.");
            }

            if (!response.IsSuccessStatusCode)
            {
                string serialized = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erro: {response.StatusCode} - {serialized}");
            }
        }

    }
}
