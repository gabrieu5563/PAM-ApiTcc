namespace ApiTcc.Views;

public partial class ListagemRequisicaoView : ContentPage
{
    public ListagemRequisicaoView()
    {
        InitializeComponent();
    }

    private async void OnCadastrarClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("cadastroRequisicaoView");
    }
}
