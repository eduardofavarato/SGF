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
    public sealed partial class Serie : Page
    {
        public Serie()
        {
            this.InitializeComponent();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                listViewSeries.ItemsSource = await databaseMethods.getAllSeriesToListView();
            }
            catch (Exception) { }
        }


        private async void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Serie s = (Model.Serie)listViewSeries.SelectedItem;
                s.Nome = tbxNome.Text;
                databaseMethods.updateSerie(s);
                await new MessageDialog("Série Atualizada Com Sucesso!").ShowAsync();
                Frame.Navigate(typeof(Serie));
            }
            catch (Exception) { }
        }
        private async void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Serie s = (Model.Serie)listViewSeries.SelectedItem;
                List<Model.Turma> turmas = await databaseMethods.getAllTurmasToListViewBySerieId(s.Id);
                if (turmas.Count() > 0)
                {
                    await new MessageDialog("Existem " + turmas.Count().ToString() + " turmas nesta turma. Para excluir uma série, não devem existir turmas nela!").ShowAsync();
                }
                else
                {
                    databaseMethods.deleteSerie(s);
                    await new MessageDialog("Série Excluída Com Sucesso!").ShowAsync();
                    Frame.Navigate(typeof(Serie));

                }
            }
            catch (Exception) { }
        }
        private async void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Serie serie = await databaseMethods.insertSerie(tbxNome.Text);
                await new MessageDialog("Nova Série Inserida Com Sucesso!").ShowAsync();
                Frame.Navigate(typeof(Serie));
            }
            catch (Exception) { }
        }
    }
}
