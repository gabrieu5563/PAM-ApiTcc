using ApiTcc.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace ApiTcc.Services
{
    public class RequisicaoService : Request
    {
        private readonly string apiUrlBase = "http://localhost:5125/Requisicao";

        public async Task<Requisicao> PostRequisicaoAsync(Requisicao requisicao)
        {
            return await PostAsync(apiUrlBase, requisicao);
        }


        public async Task<ObservableCollection<Requisicao>> GetRequisicoesAsync()
        {
            return await GetAsync<ObservableCollection<Requisicao>>(apiUrlBase);
        }

        public async Task<Requisicao> GetRequisicaoAsync(int id)
        {
            string url = $"{apiUrlBase}/{id}";
            return await GetAsync<Requisicao>(url);
        }

        public async Task<int> PutRequisicaoAsync(Requisicao requisicao)
        {
            return await PutAsync(apiUrlBase, requisicao);
        }

        public async Task DeleteRequisicaoAsync(int id)
        {
            string url = $"{apiUrlBase}/{id}";
            await DeleteAsync(url);
        }
    }
}
