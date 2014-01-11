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
using TimberYardSoft.ClassStructure;

namespace TimberYardSoft
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Firm firm = new Firm("Pesho OOD");
        //Order order = new Order();
        //private List<Lot> orderedListViewSource = new List<Lot>();

        public MainWindow()
        {
            InitializeComponent();

            // ============================================================
            this.DataContext = this.firm;

            firm.AddYard(new TimberYard("Main Yard"));
            foreach (var yard in firm.GetAllYards())
            {
                firm.Journal.TraceYard(yard);
            }

            firm.GetYard(0).AddLot(new BukLot(new LotSize(300, 40, 4000), 50, 300m));
            firm.GetYard(0).AddLot(new BukLot(new LotSize(300, 40, 4000), 50, 300m));
            firm.GetYard(0).AddLot(new BukLot(new LotSize(300, 40, 4000), 50, 300m));
            firm.GetYard(0).AddLot(new DubLot(new LotSize(30, 80, 470), 50, 300m));
            firm.GetYard(0).AddLot(new YavorLot(new LotSize(145, 371, 1000), 50, 300m));
            firm.GetYard(0).AddLot(new YavorLot(new LotSize(145, 371, 1000), 50, 300m));
            firm.GetYard(0).AddLot(new BukLot(new LotSize(30, 40, 400), 60, 30m));
            firm.GetYard(0).AddLot(new BukLot(new LotSize(300, 40, 4000), 50, 700m));
            firm.GetYard(0).AddLot(new DubLot(new LotSize(30, 40, 500), 50, 300m));

            this.YardSelector.ItemsSource = firm.GetAllYards();
            this.firm.FirmYardAdded += (snd, args) =>
                {
                    this.YardSelector.Items.Refresh();
                };

            this.OrderedListView.ItemsSource = this.firm.Order.GetOrderedLots;
            this.OrderPriceTextBlock.DataContext = this.Order;
          
            this.Closed += (snd, args) =>
                {
                    this.firm.Journal.CreateReport();
                };
        }

        public Firm Firm
        {
            get { return this.firm; }
        }

        public Order Order
        {
            get { return this.firm.Order; }
        }

        public void OnFileNewYard_Click(object sender, RoutedEventArgs e)
        {
            AddYardWindow addYardWindow = new AddYardWindow();
            addYardWindow.Owner = this;
            addYardWindow.ShowDialog();
        }

        private void OnYardSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = this.YardSelector.SelectedValue;
            this.AvailabilityListView.ItemsSource = (selected as TimberYard).GetLots;
        }

        private void OnAddLot_Click(object sender, RoutedEventArgs e)
        {
            if (this.YardSelector.SelectedItem == null)
            {
                MessageBox.Show("Please first select a yard.");
            }
            else
            {
                AddLotWindow addYardWindow = new AddLotWindow();
                addYardWindow.Owner = this;
                addYardWindow.ShowDialog();
            }
        }

        #region sorting availability listview
        //sorting by columns events
        
        private void OnIDColumn_Click(object sender, RoutedEventArgs e)
        {
            var source = (this.YardSelector.SelectedValue as TimberYard).GetLots.OrderBy(l => l.Id);
            this.AvailabilityListView.ItemsSource = source;
        }

        private void OnWoodColumn_Click(object sender, RoutedEventArgs e)
        {
            var source = (this.YardSelector.SelectedValue as TimberYard).GetLots.OrderBy(l => l.Wood);
            this.AvailabilityListView.ItemsSource = source;
        }

        private void OnWidthColumn_Click(object sender, RoutedEventArgs e)
        {
            var source = (this.YardSelector.SelectedValue as TimberYard).GetLots.OrderBy(l => l.Size.Width);
            this.AvailabilityListView.ItemsSource = source;
        }

        private void OnHeightColumn_Click(object sender, RoutedEventArgs e)
        {
            var source = (this.YardSelector.SelectedValue as TimberYard).GetLots.OrderBy(l => l.Size.Height);
            this.AvailabilityListView.ItemsSource = source;
        }

        private void OnLengthColumn_Click(object sender, RoutedEventArgs e)
        {
            var source = (this.YardSelector.SelectedValue as TimberYard).GetLots.OrderBy(l => l.Size.Length);
            this.AvailabilityListView.ItemsSource = source;
        }

        private void OnPriceColumn_Click(object sender, RoutedEventArgs e)
        {
            var source = (this.YardSelector.SelectedValue as TimberYard).GetLots.OrderBy(l => l.Price);
            this.AvailabilityListView.ItemsSource = source;
        }

        private void OnPiecesColumn_Click(object sender, RoutedEventArgs e)
        {
            var source = (this.YardSelector.SelectedValue as TimberYard).GetLots.OrderBy(l => l.Pieces);
            this.AvailabilityListView.ItemsSource = source;
        }
        #endregion

        #region sorting ordered listview
        //ordered listview items sorting by columns

        private void OnOrderListViewIDCol_Click(object sender, RoutedEventArgs e)
        {
            var orderedListViewSource = this.Firm.Order.GetOrderedLots.OrderBy(l => l.Id);
            this.OrderedListView.ItemsSource = orderedListViewSource;
        }

        private void OnOrderListViewWoodCol_Click(object sender, RoutedEventArgs e)
        {
            var orderedListViewSource = this.Firm.Order.GetOrderedLots.OrderBy(l => l.Wood);
            this.OrderedListView.ItemsSource = orderedListViewSource;
        }

        private void OnOrderListViewWidthCol_Click(object sender, RoutedEventArgs e)
        {
            var orderedListViewSource = this.Firm.Order.GetOrderedLots.OrderBy(l => l.Size.Width);
            this.OrderedListView.ItemsSource = orderedListViewSource;
        }

        private void OnOrderListViewHeightCol_Click(object sender, RoutedEventArgs e)
        {
            var orderedListViewSource = this.Firm.Order.GetOrderedLots.OrderBy(l => l.Size.Height);
            this.OrderedListView.ItemsSource = orderedListViewSource;
        }

        private void OnOrderListViewLengthCol_Click(object sender, RoutedEventArgs e)
        {
            var orderedListViewSource = this.Firm.Order.GetOrderedLots.OrderBy(l => l.Size.Length);
            this.OrderedListView.ItemsSource = orderedListViewSource;
        }

        private void OnOrderListViewPriceCol_Click(object sender, RoutedEventArgs e)
        {
            var orderedListViewSource = this.Firm.Order.GetOrderedLots.OrderBy(l => l.Price);
            this.OrderedListView.ItemsSource = orderedListViewSource;
        }

        private void OnOrderListViewPiecesCol_Click(object sender, RoutedEventArgs e)
        {
            var orderedListViewSource = this.Firm.Order.GetOrderedLots.OrderBy(l => l.Pieces);
            this.OrderedListView.ItemsSource = orderedListViewSource;
        }
        #endregion

        private void OnToOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int pieceCount = int.Parse(this.PiecesTextBox.Text);
                Lot selectedLot = AvailabilityListView.SelectedItem as Lot;
                if (selectedLot == null)
                {
                    throw new ArgumentNullException("Please select a lot from the in-stock list!");
                }
                if (selectedLot != null && pieceCount > selectedLot.Pieces)
                {
                    throw new OrderPiecesException<int>("Pieces cannot be more than are available in the selected lot!", 1, selectedLot.Pieces);
                }
                else if (pieceCount == selectedLot.Pieces)
                {
                    //if all pieces are required, remove the lot
                    int selectedYardIndex = this.YardSelector.SelectedIndex;
                    TimberYard selectedYard = this.Firm.GetYard(selectedYardIndex);
                    selectedYard.RemoveLot(selectedLot);
                    this.AvailabilityListView.Items.Refresh();
                    this.Firm.Order.AddLot(selectedLot);
                    this.OrderedListView.Items.Refresh();
                }
                else
                {
                    Lot orderedLot = selectedLot.Clone();
                    orderedLot.Pieces = pieceCount;
                    orderedLot.Price = Math.Round(((selectedLot.Price / selectedLot.Pieces) * orderedLot.Pieces),2);
                    this.Firm.Order.AddLot(orderedLot);
                    OrderedListView.Items.Refresh();
                    selectedLot.Price = (selectedLot.Price / selectedLot.Pieces) * (selectedLot.Pieces - pieceCount);
                    selectedLot.Pieces -= pieceCount;

                    AvailabilityListView.Items.Refresh();
                }
            }
            catch (ArgumentException ar)
            {
                MessageBox.Show(ar.Message);
            }
            catch (OrderPiecesException<int> orEx)
            {
                MessageBox.Show(orEx.Message);
            }
        }

        private void OnPiecesTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                int piecesInput;
                string piecesStr = this.PiecesTextBox.Text;
                if (!int.TryParse(piecesStr, out piecesInput))
                {
                    throw new ArgumentException("Invalid pieces number!");
                }
            }
            catch (ArgumentException ar)
            {
                MessageBox.Show(ar.Message);
                this.PiecesTextBox.Text = "0";
            }
        }

        private void OnReport_Click(object sender, RoutedEventArgs e)
        {
            this.Firm.Order.CreateReport();
        }
    }
}
