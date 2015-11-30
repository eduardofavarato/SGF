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
    public sealed partial class Disciplina : Page
    {
        public Disciplina()
        {
            this.InitializeComponent();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                listViewDisciplinas.ItemsSource = await databaseMethods.getAllDisciplinasToListView();
            }
            catch (Exception) { }
        }


        private async void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Disciplina d = (Model.Disciplina)listViewDisciplinas.SelectedItem;
                d.Nome = tbxNome.Text;
                databaseMethods.updateDisciplina(d);
                await new MessageDialog("Disciplina Atualizada Com Sucesso!").ShowAsync();
                Frame.Navigate(typeof(Disciplina));
            }
            catch (Exception) { }
        }
        private async void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Disciplina d = (Model.Disciplina)listViewDisciplinas.SelectedItem;
                List<Model.TurmaDisciplina> turmaDisciplinas = await databaseMethods.getAllTurmaDisciplinasByDisciplinaId(d.Id);
                if (turmaDisciplinas.Count() > 0)
                {
                    await new MessageDialog("Existem " + turmaDisciplinas.Count().ToString() + " turmas utilizando esta disciplina. Para excluir uma disciplina, não devem existir turmas a utilizando!").ShowAsync();
                }
                else
                {
                    databaseMethods.deleteDisciplina(d);
                    await new MessageDialog("Disciplina Excluída Com Sucesso!").ShowAsync();
                    Frame.Navigate(typeof(Disciplina));

                }
            }
            catch (Exception) { }
        }
        private async void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Disciplina disciplina = await databaseMethods.insertDisciplina(tbxNome.Text);
                await new MessageDialog("Nova Disciplina Inserida Com Sucesso!").ShowAsync();
                Frame.Navigate(typeof(Disciplina));
            }
            catch (Exception) { }
        }
    }
}
