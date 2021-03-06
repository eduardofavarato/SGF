﻿using Microsoft.WindowsAzure.MobileServices;
using SGF.Model;
using System;
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

namespace SGF
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        // criando um  objeto de configuração.
        Windows.Storage.ApplicationDataContainer localsettings =
            Windows.Storage.ApplicationData.Current.LocalSettings;

        public Login()
        {
            this.InitializeComponent();
            carregarConfiguracao();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.BackRequested += backButton_Tapped;
        }
        private void backButton_Tapped(object sender, BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame.CanGoBack)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            salvarConfiguracao();
            processaLogin(textBox_Usuario.Text, textBox_Senha.Password);
        }

        private async void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            var messageDialog = new MessageDialog("Desejar realmente fechar o SGF ?");
            messageDialog.Commands.Add(new UICommand("Sim", (command) =>
            {
                Application.Current.Exit();
            }));
            messageDialog.Commands.Add(new UICommand("Não", null));
            messageDialog.DefaultCommandIndex = 1;

            await messageDialog.ShowAsync();
        }

        private async void processaLogin(string login, string senha)
        {
            try
            {
                if (login != "" && senha != "")
                {
                    if (!await databaseMethods.checkLogin(login, senha))
                    {
                        await new MessageDialog("Acesso Negado!").ShowAsync();
                    }
                    else
                    {
                        // await new MessageDialog("Bem Vindo!").ShowAsync();                    
                        this.Frame.Navigate(typeof(View.Admin.Admin));
                    }
                }
                else
                {
                    await new MessageDialog("Por Favor Preencha todos os campos!").ShowAsync();
                }
            }
            catch (Exception)
            {
                await new MessageDialog("Falha na conexão!").ShowAsync();
            }
            
        }

        private void salvarConfiguracao()
        {
            // criando uma configuração simples. 
            localsettings.CreateContainer("nome_usuario", Windows.Storage.ApplicationDataCreateDisposition.Always);
            localsettings.Values["nome_usuario"] = textBox_Usuario.Text;
        }

        private void carregarConfiguracao()
        {
            // validando se existe a configuração.
            if (localsettings.Containers.ContainsKey("nome_usuario"))
            {
                string data = localsettings.Values["nome_usuario"].ToString();
                textBox_Usuario.Text = data; // retornando o resultado da busca
            }
        }

        private void textBox_Senha_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                salvarConfiguracao();
                processaLogin(textBox_Usuario.Text, textBox_Senha.Password);
            }
        }
    }
}
