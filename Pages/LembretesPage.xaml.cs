using Microsoft.Maui.Controls;
using System;

namespace PrototipoERP.DesktopMaui.Pages
{
	public partial class LembretesPage : ContentPage
	{
		public LembretesPage(string authenticationToken)
		{
			InitializeComponent();

			myListView.ItemsSource = AppState.Lembretes;
			AppState.Lembretes.Add(new Models.LembreteModel() { UsuarioId = 1, DataHora = DateTime.Now, Texto = "aa" });
		}

        public void OnMeuUsuarioClicked(object sender, EventArgs args)
        {
            //AppState.Lembretes.Add(new TodoModel() { Id = 2, Title = "Ir a academia", CreatedAt = DateTime.Now, Done = false });
        }

        public void OnTodosUsuariosClicked(object sender, EventArgs args)
        {
            //AppState.Lembretes.Add(new TodoModel() { Id = 2, Title = "Ir a academia", CreatedAt = DateTime.Now, Done = false });
        }
    }
}
