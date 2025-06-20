using ApiTcc.Models;
using ApiTcc.Services;
using Microsoft.Maui.Controls;
using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ApiTcc.ViewModels
{
    public class ListagemRequisicaoViewModel : BaseViewModel
    {
        private readonly RequisicaoService _service;

        public ObservableCollection<Requisicao> Requisicoes { get; set; }

        public ICommand RemoverCommand { get; }
        public ICommand EditarCommand { get; }

        public ListagemRequisicaoViewModel()
        {
            _service = new RequisicaoService();
            Requisicoes = new ObservableCollection<Requisicao>();

            RemoverCommand = new Command<int>(async (id) => await Remover(id));
            EditarCommand = new Command<int>(async (id) => await Editar(id));

            MessagingCenter.Subscribe<CadastroRequisicaoViewModel>(this, "AtualizarRequisicoes", async (sender) =>
            {
                await LoadRequisicoes();
            });

            _ = LoadRequisicoes();
        }


        public async Task LoadRequisicoes()
        {
            var lista = await _service.GetRequisicoesAsync();
            Requisicoes.Clear();

            foreach (var item in lista)
                Requisicoes.Add(item);
        }

        private async Task Remover(int id)
        {
            bool confirm = await Shell.Current.DisplayAlert("Confirmação", "Deseja excluir essa requisição?", "Sim", "Não");
            if (!confirm) return;

            try
            {
                await _service.DeleteRequisicaoAsync(id);
                await LoadRequisicoes();
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private async Task Editar(int id)
        {
            var requisicao = await _service.GetRequisicaoAsync(id);

            if (requisicao != null)
            {
                var parametros = new Dictionary<string, object>
                {
                    { "Id", requisicao.Id },
                    { "Prompt", requisicao.Prompt },
                    { "UsuarioId", requisicao.UsuarioId }
                };

                await Shell.Current.GoToAsync($"cadastroRequisicaoView", parametros);
            }
        }
    }
}
