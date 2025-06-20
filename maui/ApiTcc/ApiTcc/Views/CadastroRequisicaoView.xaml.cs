using ApiTcc.ViewModels;

namespace ApiTcc.Views;

public partial class CadastroRequisicaoView : ContentPage, IQueryAttributable
{
    public CadastroRequisicaoView()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (BindingContext is CadastroRequisicaoViewModel vm)
        {
            if (query.ContainsKey("Id"))
                vm.Id = Convert.ToInt32(query["Id"]);

            if (query.ContainsKey("Prompt"))
                vm.Prompt = query["Prompt"].ToString();

            if (query.ContainsKey("UsuarioId"))
                vm.UsuarioId = Convert.ToInt32(query["UsuarioId"]);
        }
    }
}
