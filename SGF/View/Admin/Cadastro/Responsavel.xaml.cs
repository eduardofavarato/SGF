using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SGF.View.Admin.Cadastro
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Responsavel : Page
    {
        public Responsavel()
        {
            this.InitializeComponent();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                listViewResponsaveis.ItemsSource = await databaseMethods.getAllResponsaveisToListView();
            }
            catch (Exception) { }
        }
        private async void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Responsavel a = (Model.Responsavel)listViewResponsaveis.SelectedItem;
                a.Usuario.Nome = tbxNome.Text;
                a.Usuario.Login = tbxLogin.Text;
                a.Usuario.Senha = tbxSenha.Text;

                databaseMethods.updateResponsavel(a, a.Usuario);
                await new MessageDialog("Responsável Atualizado Com Sucesso!").ShowAsync();
                Frame.Navigate(typeof(Responsavel));
            }
            catch (Exception) { }
        }
        private async void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Responsavel r = (Model.Responsavel)listViewResponsaveis.SelectedItem;
                databaseMethods.deleteResponsavel(r);
                await new MessageDialog("Responsável Excluído Com Sucesso!").ShowAsync();
                Frame.Navigate(typeof(Responsavel));
            }
            catch (Exception) { }
        }
        private async void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Responsavel responsavel = await databaseMethods.insertResponsavel(tbxLogin.Text, tbxNome.Text, tbxSenha.Text);
                await new MessageDialog("Novo Responsável Inserido Com Sucesso!").ShowAsync();
                listViewResponsaveis.Items.Add(responsavel);
                Frame.Navigate(typeof(Responsavel));
            }
            catch (Exception) { }
        }
    }
}
