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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        int newID=0;
        string newMaterialType = null;
        //int newSizeW = 0;
        //int newSizeH = 0;
        //int newSizeL = 0;
        //int newPeaces = 0;
        //decimal newPrice = 0m;
        public Window1()
        {
            InitializeComponent();
            // ================================= Fields =======
            
            string[] materialType = { "Buk", "Dub", "Yavor", "Yasen" };
            this.MaterialType.SelectedValue = materialType[0];            
            
            LotSize newSise = new LotSize(0,0,0);
            // ================================= 
            this.NewID.Text = IdGenerator.GetId().ToString();
            this.MaterialType.ItemsSource = materialType;
            
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {    
            
            //this.firm.GetYard(this.Skladove.SelectedIndex).AddLot(new YasenLot(new LotSize(3, 4, 5), 10, 15));
            this.Close();
        }
    }
}
