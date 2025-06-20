using ApiTcc.Services;
using MvvmHelpers;
using System.Windows.Input;

namespace ApiTcc.ViewModels;

public class DeleteRequisicaoViewModel : BaseViewModel
{
    private readonly RequisicaoService _service;

    public int Id { get; set; }

    public ICommand DeleteCommand { get; }

    public DeleteRequisicaoViewModel()
    {
        _service = new RequisicaoService();
        DeleteCommand = new Command(async () => await Delete());
    }

    private async Task Delete()
    {
        await _service.DeleteRequisicaoAsync(Id);
        await Shell.Current.GoToAsync("..");
    }
}
