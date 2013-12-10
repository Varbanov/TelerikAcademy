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
    public partial class AddLotWindow : Window
    {
        int newID = IdGenerator.GetId();

        public AddLotWindow()
        {
            InitializeComponent();
            Wood[] materialTypesArr = { Wood.Buk, Wood.Dub, Wood.Yavor, Wood.Yasen };
            this.WoodComboBox.ItemsSource = materialTypesArr;
            this.WoodComboBox.SelectedValue = materialTypesArr[0];
            this.NewID.Text = newID.ToString();
        }


        private void OnAddYard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow main = this.Owner as MainWindow;
                TimberYard currYard = main.YardSelector.SelectedItem as TimberYard;
                if (currYard == null)
                {
                    throw new NullReferenceException("Error: Yard has null value. Please select a yard.");
                }
                Lot lot = LotParser();
                currYard.AddLot(lot);
                main.AvailabilityListView.Items.Refresh();
                this.Close();

            }
            catch (ArgumentException ar)
            {
                MessageBox.Show(ar.Message);
            }

            catch (NullReferenceException ne)
            {
                MessageBox.Show(ne.Message);
            }
            
        }

        private Lot BasicLotCreator(Wood wood)
        {
            switch (wood)
            {
                case Wood.Buk: return new BukLot(new LotSize(), 0, 0);
                case Wood.Dub: return new DubLot(new LotSize(), 0, 0);
                case Wood.Yavor: return new YavorLot(new LotSize(), 0, 0);
                case Wood.Yasen: return new YasenLot(new LotSize(), 0, 0);
                default: throw new ArgumentException("Invalid wood type");
            }
        }

        private Lot LotParser()
        {
            Wood wood = (Wood)WoodComboBox.SelectedItem;
            int tempW = int.Parse(NewWidthTextBox.Text);
            int tempH = int.Parse(NewHeightTextBox.Text);
            int tempL = int.Parse(NewLengthTextBox.Text);
            int tempPieces = int.Parse(NewPiecesTextBox.Text);
            decimal tempPrice = decimal.Parse(NewPriceTextBox.Text);
            LotSize tempSize = new LotSize(tempW, tempH, tempL);

            switch (wood)
            {
                case Wood.Buk: return new BukLot(tempSize, tempPieces, tempPrice);
                case Wood.Dub: return new DubLot(tempSize, tempPieces, tempPrice);
                case Wood.Yavor: return new YavorLot(tempSize, tempPieces, tempPrice);
                case Wood.Yasen: return new YasenLot(tempSize, tempPieces, tempPrice);
                default: throw new ArgumentException("Invalid wood type");
            }
        }
        

        private void OnNewSizeWLostFocus(object sender, EventArgs e)
        {
        }
    }
}
