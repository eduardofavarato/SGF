﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
            currentView.BackRequested += backButton_Tapped;
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
        private void backButton_Tapped(object sender, BackRequestedEventArgs e)
        {
            e.Handled = true;
            if (Frame.CanGoBack)
                try { Frame.GoBack(); }
                catch (Exception) { }
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                databaseMethods.insertTurma(tbxNome.Text, cbxSerie.SelectedValue.ToString());
                await new MessageDialog("Nova Turma Inserida Com Sucesso!").ShowAsync();
            }
            catch (Exception) { }
        }
    }
}
