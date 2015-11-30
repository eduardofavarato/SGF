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
    public sealed partial class Aluno : Page
    {
        public Aluno()
        {
            this.InitializeComponent();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                listViewAlunos.ItemsSource = await databaseMethods.getAllAlunosToListView();
                cbxSerie.ItemsSource = await databaseMethods.getAllSeriesToListView();
            }
            catch (Exception) { }
        }


        private async void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Aluno a = (Model.Aluno)listViewAlunos.SelectedItem;
                a.Matricula = tbxMatricula.Text;
                a.TurmaId = cbxTurma.SelectedValue.ToString();
                a.Usuario.Nome = tbxNome.Text;
                a.Usuario.Login = tbxMatricula.Text;
                a.Usuario.Senha = tbxMatricula.Text;

                if (a.TurmaId != cbxTurma.SelectedValue.ToString())
                {
                    var messageDialog = new MessageDialog("Se você alterar a Turma deste Aluno, perderá todas as Frequências e Notas do mesmo. Desejar realmente continuar?");
                    messageDialog.Commands.Add(new UICommand("Sim", async (command) =>
                    {
                        databaseMethods.updateAlunoCompleto(a, a.Usuario);
                        await new MessageDialog("Aluno Atualizado Com Sucesso!").ShowAsync();
                        Frame.Navigate(typeof(Aluno));
                    }));
                    messageDialog.Commands.Add(new UICommand("Não", null));
                    messageDialog.DefaultCommandIndex = 1;

                    await messageDialog.ShowAsync();
                }
                else
                {
                    databaseMethods.updateAlunoBasico(a, a.Usuario);
                    await new MessageDialog("Aluno Atualizado Com Sucesso!").ShowAsync();
                    Frame.Navigate(typeof(Aluno));
                }
            }
            catch (Exception) { }
        }
        private async void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Aluno a = (Model.Aluno)listViewAlunos.SelectedItem;
                databaseMethods.deleteAluno(a);
                Task.WaitAll();
                await new MessageDialog("Aluno Excluído Com Sucesso!").ShowAsync();
                Frame.Navigate(typeof(Aluno));
            }
            catch (Exception) { }
        }
        private async void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Aluno aluno = await databaseMethods.insertAluno(tbxMatricula.Text, tbxNome.Text, tbxMatricula.Text, tbxMatricula.Text, cbxTurma.SelectedValue.ToString());
                await new MessageDialog("Novo Aluno Inserido Com Sucesso!").ShowAsync();
                Frame.Navigate(typeof(Aluno));
            }
            catch (Exception) { }
        }
        private async void cbxSerie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbxTurma.ItemsSource = await databaseMethods.getAllTurmasToListViewBySerieId(cbxSerie.SelectedValue.ToString());
            if(listViewAlunos.SelectedIndex > 0) cbxTurma.SelectedValue = ((Model.Aluno)listViewAlunos.SelectedItem).TurmaId;
            cbxTurma.PlaceholderText = "Escolha a turma do aluno..";
        }

        private async void listViewAlunos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbxSerie.SelectedValue = await databaseMethods.getSerieAlunoByAlunoId(((Model.Aluno)listViewAlunos.SelectedItem).TurmaId);
            cbxTurma.SelectedValue = ((Model.Aluno)listViewAlunos.SelectedItem).TurmaId;
        }
    }
}
