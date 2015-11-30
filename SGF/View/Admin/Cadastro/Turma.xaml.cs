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
    public sealed partial class Turma : Page
    {
        public Turma()
        {
            this.InitializeComponent();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                listViewTurmas.ItemsSource = await databaseMethods.getAllTurmasToListView();
                cbxSerie.ItemsSource = await databaseMethods.getAllSeriesToListView();
            }
            catch (Exception) { }
        }



        private async void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Turma t = (Model.Turma)listViewTurmas.SelectedItem;
                t.Nome = tbxNome.Text;
                t.SerieId = cbxSerie.SelectedValue.ToString();
                databaseMethods.updateTurma(t);
                await new MessageDialog("Turma Atualizada Com Sucesso!").ShowAsync();
                Frame.Navigate(typeof(Turma));
            }
            catch (Exception) { }
        }
        private async void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Turma t = (Model.Turma)listViewTurmas.SelectedItem;
                List<Model.Aluno> alunos = await databaseMethods.getAllAlunosToListViewByTurmaId(t.Id);
                if (alunos.Count() > 0)
                {
                    await new MessageDialog("Existem " + alunos.Count().ToString() + " alunos nesta turma. Para excluir uma turma, não devem existir alunos nela!").ShowAsync();
                }
                else
                {
                    databaseMethods.deleteTurma(t);
                    await new MessageDialog("Turma Excluída Com Sucesso!").ShowAsync();
                    Frame.Navigate(typeof(Turma));

                }
            }
            catch (Exception) { }
        }
        private async void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Turma turma = await databaseMethods.insertTurma(tbxNome.Text, cbxSerie.SelectedValue.ToString());
                await new MessageDialog("Nova Turma Inserida Com Sucesso!").ShowAsync();
                Frame.Navigate(typeof(Turma));
            }
            catch (Exception) { }
        }
    }
}
