using ProjectRVA.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectRVA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Logovanje klijenta na EES.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void login_button(object sender, RoutedEventArgs e)
        {
            //Singleton.
            UserManager userManager = UserManager.Instance();

            bool popunjeno = true;
            bool validan = false;

            if (textBoxUsername.Text.Equals(""))
            {
                textBoxUsername.BorderThickness = new Thickness(1, 1, 1, 1);
                textBoxUsername.BorderBrush = Brushes.Red;
                textBoxUsername.Text = "";
                popunjeno = false;
            }

            if (textBoxPassword.Text.Equals(""))
            {
                textBoxPassword.BorderThickness = new Thickness(1, 1, 1, 1);
                textBoxPassword.BorderBrush = Brushes.Red;
                textBoxPassword.Text = "";
                popunjeno = false;
            }
            

            //Oba polja popunjena -> pokusaj se prijaviti
            if (popunjeno)
            {
                validan = userManager.CheckUser(textBoxUsername.Text, textBoxPassword.Text);
            }

            if(validan)
            {
                //Show Network
                Network Network = new Network();
                Network.Show();

                this.Close();
            }
            else
            {
                label2Error.Visibility = Visibility.Visible;
            }

        }
    }
}
