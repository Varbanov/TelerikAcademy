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
using TimberYardSoft.ClassStructure;

namespace TimberYardSoft
{
    /// <summary>
    /// Interaction logic for AddYardWindow.xaml
    /// </summary>
    public partial class AddYardWindow : Window
    {
        public AddYardWindow()
        {
            InitializeComponent();
        }

        private void OnOKButton_Click(object sender, RoutedEventArgs e)
        {
            string name = this.YardName.Text;
            if (String.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Error: The yard name is empty.");
            }
            else
            {
                MainWindow main = this.Owner as MainWindow;
                main.Firm.AddYard(new TimberYard(name));
                this.Close();
                MessageBox.Show(String.Format("Yard {0} created successfully.", name));
            }
        }
    }
}
