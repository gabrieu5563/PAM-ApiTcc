using ApiTcc.Models;
using ApiTcc.Services;
using Microsoft.Maui.Controls;
using MvvmHelpers;
using System.Windows.Input;

namespace ApiTcc.ViewModels
{
    public class CadastroRequisicaoViewModel : BaseViewModel
    {
        private readonly RequisicaoService _service;

        public int Id { get; set; }
        public string Prompt { get; set; }
        public int UsuarioId { get; set; }

        public ICommand SalvarCommand { get; }

        public CadastroRequisicaoViewModel()
        {
            _service = new RequisicaoService();
            SalvarCommand = new Command(async () => await Salvar());
        }

        private async Task Salvar()
        {
            try
            {
                var requisicao = new Requisicao
                {
                    Id = Id,
                    Prompt = Prompt,
                    UsuarioId = UsuarioId,
                    CriadoEm = DateTime.Now
                };

                if (Id == 0)
                    await _service.PostRequisicaoAsync(requisicao);
                else
                    await _service.PutRequisicaoAsync(requisicao);

                // 🔥 Envia mensagem para atualizar a lista
                MessagingCenter.Send(this, "AtualizarRequisicoes");

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

    }
}
