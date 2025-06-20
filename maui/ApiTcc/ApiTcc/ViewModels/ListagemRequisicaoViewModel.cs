using ApiTcc.Models;
using ApiTcc.Services;
using System.Collections.ObjectModel;
using MvvmHelpers;
using System.Windows.Input;

namespace ApiTcc.ViewModels;

public class ListagemRequisicaoViewModel : BaseViewModel
{
    public ObservableCollection<Models.Requisicao> Requisicoes { get; set; }
    public ICommand BuscarCommand { get; }
    public ICommand RemoverCommand { get; }
    public ICommand EditarCommand { get; }

    private RequisicaoService _service;

    public ListagemRequisicaoViewModel()
    {
        _service = new RequisicaoService();
        BuscarCommand = new Command(async () => await Buscar());
        RemoverCommand = new Command<int>(async (id) => await Remover(id));
        EditarCommand = new Command<int>(async (id) => await Editar(id));
        _ = Buscar();
    }

    private async Task Buscar()
    {
        Requisicoes = await _service.GetRequisicoesAsync();
        OnPropertyChanged(nameof(Requisicoes));
    }

    private async Task Remover(int id)
    {
        await _service.DeleteRequisicaoAsync(id);
        await Buscar();
    }

    private async Task Editar(int id)
    {
        var requisicao = await _service.GetRequisicaoAsync(id);

        if (requisicao != null)
        {
            // Monta a URL passando os parâmetros por query
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
