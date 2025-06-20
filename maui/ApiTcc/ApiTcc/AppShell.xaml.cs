using ApiTcc.Views;

namespace ApiTcc;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(CadastroRequisicaoView), typeof(CadastroRequisicaoView));
        Routing.RegisterRoute(nameof(ListagemRequisicaoView), typeof(ListagemRequisicaoView));
        Routing.RegisterRoute(nameof(DeleteRequisicaoView), typeof(DeleteRequisicaoView));
        Routing.RegisterRoute("cadastroRequisicaoView", typeof(CadastroRequisicaoView));
    }
}
