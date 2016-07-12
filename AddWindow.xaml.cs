using ProjectRVA.CommandPattern;
using ProjectRVA.Database;
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
using System.Windows.Shapes;

namespace ProjectRVA
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private Commander commander;

        public AddWindow(Commander commander)
        {
            InitializeComponent();
            DataContext = DataBase.Instance();
            this.commander = commander;
        }
        
        //Substation
        private void add_substation_ok(object sender, RoutedEventArgs e)
        {
            //Validacija...

            //Command - AddSubstation
            Command addSubstation = new AddSubstationCommand(substation_name.Text, nominalVoltage_combobox.Text, substation_description.Text);
            commander.AddAndExecute(addSubstation);

            this.Close();
        }

        private void add_substation_cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void add_node_ok(object sender, RoutedEventArgs e)
        {
            //Validacija...

            //Command - AddNode
            Command addNode = new AddNodeCommand(node_name.Text, node_nominalVoltage.Text, node_description.Text, comboBox_substation.Text);
            commander.AddAndExecute(addNode);

            this.Close();
        }

        private void add_node_cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
