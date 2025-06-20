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

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is ViewModels.ListagemRequisicaoViewModel vm)
        {
            _ = vm.LoadRequisicoes();
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }
}
