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

namespace SGF.View.Admin.Cadastro
{
    public sealed partial class Admin : Page
    {
        public Admin()
        {
            this.InitializeComponent();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                listViewAdmins.ItemsSource = await databaseMethods.getAllAdminsToListView();
            }
            catch (Exception) { }
        }


        private async void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Admin a = (Model.Admin)listViewAdmins.SelectedItem;
                a.Matricula = tbxMatricula.Text;
                a.Usuario.Nome = tbxNome.Text;
                a.Usuario.Login = tbxLogin.Text;
                a.Usuario.Senha = tbxSenha.Text;

                databaseMethods.updateAdmin(a, a.Usuario);
                await new MessageDialog("Admin Atualizado Com Sucesso!").ShowAsync();
                Frame.Navigate(typeof(Admin));
            }
            catch (Exception){ }
        }
        private async void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Admin a = (Model.Admin)listViewAdmins.SelectedItem;
                databaseMethods.deleteAdmin(a);
                await new MessageDialog("Admin Excluído Com Sucesso!").ShowAsync();
                Frame.Navigate(typeof(Admin));
            }
            catch (Exception) { }
        }
        private async void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Admin admin = await databaseMethods.insertAdmin(tbxLogin.Text, tbxNome.Text, tbxSenha.Text, tbxMatricula.Text);
                await new MessageDialog("Novo Admin Inserido Com Sucesso!").ShowAsync();
                Frame.Navigate(typeof(Admin));
            }
            catch (Exception) { }
        }
    }
}
