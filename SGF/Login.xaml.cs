using Microsoft.WindowsAzure.MobileServices;
using SGF.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
        public Login()
        {
            this.InitializeComponent();
            // insertAdmin();
            // getAdminList();
        }

        public async void getAdminList()
        {
            IMobileServiceTable<Usuario> admin = App.MobileService.GetTable<Usuario>();
            
            MobileServiceCollection<Usuario, Usuario> adminCollection;
            adminCollection = await admin.ToCollectionAsync();
        }

        public async void insertAdmin()
        {
            Admin item = new Admin { Matricula = "1", Usuario = new Usuario() { Login="admin", Nome="Teste", Senha="teste" } };
            await App.MobileService.GetTable<Admin>().InsertAsync(item);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            processaLogin(textBox_Usuario.Text, textBox_Senha.Text);
        }

        private void processaLogin(string login, string senha)
        {
            // Implementar consulta no banco...
        }
    }
}
