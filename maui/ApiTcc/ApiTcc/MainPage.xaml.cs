using ApiTcc.Views;

namespace ApiTcc;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCreateClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(CadastroRequisicaoView));
    }

    private async void OnReadClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ListagemRequisicaoView));
    }

    private async void OnUpdateClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(CadastroRequisicaoView));
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(DeleteRequisicaoView));
    }
}
