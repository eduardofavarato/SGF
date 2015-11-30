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
    public sealed partial class Professor : Page
    {
        public Professor()
        {
            this.InitializeComponent();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                listViewProfessores.ItemsSource = await databaseMethods.getAllProfessoresToListView();
            }
            catch (Exception) { }
        }


        private async void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Professor a = (Model.Professor)listViewProfessores.SelectedItem;
                a.Matricula = tbxMatricula.Text;
                a.Usuario.Nome = tbxNome.Text;
                a.Usuario.Login = tbxLogin.Text;
                a.Usuario.Senha = tbxSenha.Text;

                databaseMethods.updatetProfessor(a, a.Usuario);
                await new MessageDialog("Professor Atualizado Com Sucesso!").ShowAsync();
                Frame.Navigate(typeof(Professor));
            }
            catch (Exception) { }
        }
        private async void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Professor p = (Model.Professor)listViewProfessores.SelectedItem;
                databaseMethods.deleteProfessor(p);
                await new MessageDialog("Professor Excluído Com Sucesso!").ShowAsync();
                Frame.Navigate(typeof(Professor));
            }
            catch (Exception) { }
        }
        private async void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Professor professor = await databaseMethods.insertProfessor(tbxLogin.Text, tbxNome.Text, tbxSenha.Text, tbxMatricula.Text);
                await new MessageDialog("Novo Professor Inserido Com Sucesso!").ShowAsync();
                Frame.Navigate(typeof(Professor));
            }
            catch (Exception) { }
        }
    }
}
