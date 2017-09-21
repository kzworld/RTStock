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
using System.Collections.ObjectModel;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Windows.Threading;
using RTStockQuoteInfo;
using System.ComponentModel;
using System.Threading;

namespace RTStockQuote
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            /*Setting Timer To Do Real Time*/
            int seconds = 1;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(1000 * seconds);
            timer.Start();
            InitializeComponent();
            this.Topmost = true;          
        }
       
        private BackgroundWorker worker = new BackgroundWorker();

        void timer_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(50);
            worker.DoWork += worker_DoWork;
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            PullData();
        }

        /// <summary>
        /// Set Current Thread Dispatcher 
        /// </summary>
        private Dispatcher currentDispatcher = Dispatcher.CurrentDispatcher;

        /// <summary>
        /// Set ObservableCollectionList<string> To Store Quotes
        /// </summary>
        private ObservableCollection<string> list = new ObservableCollection<string>();

        /// <summary>
        /// Function To Pull Stock Data
        /// </summary>
        private void PullData()
        {
            StockList stocklist = new StockList();
            List<string> verifylist = new List<string>();
            lock (list)
            {
                foreach (string quote in list)
                {

                    Stock stock = new Stock(quote);
                    if (!verifylist.Contains(stock.Quote))
                    {
                        verifylist.Add(stock.Quote);

                        if (!string.IsNullOrEmpty(stock.Quote))
                            stocklist.Add(stock);
                    }
                }
            }
            currentDispatcher.Invoke(() => dg_StockList.ItemsSource = stocklist);
        }


        /// <summary>
        /// Button Add Function To Add Quote Into QuoteList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_Add_Click(object sender, RoutedEventArgs e)
        {

            string[] Quotes = txt_StockQuote.Text.ToUpper().Replace(" ", "").Trim().Split(',');
            lock (list)
            {
                foreach (string Quote in Quotes)
                {
                    if (!list.Contains(Quote))
                    {
                        if (!string.IsNullOrEmpty(Quote))
                            list.Add(Quote);
                    }
                }
            }
            await Task.Run(() => PullData());

        }

        /// <summary>
        /// Button Remove Function To Remove Quote From QuoteList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_Remove_Click(object sender, RoutedEventArgs e)
        {

            string[] RemoveQuotes = txt_StockQuote.Text.ToUpper().Replace(" ", "").Trim().Split(',');
            lock (list)
            {
                foreach (string Quote in RemoveQuotes)
                {
                    if (list.Contains(Quote))
                        list.Remove(Quote);
                }
            }
            await Task.Run(() => PullData());

        }

        /// <summary>
        /// Quit Application Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_Quit_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
                
                this.Dispatcher.Invoke((Action)(()=>Application.Current.Shutdown()))
                
                );
        }

        /// <summary>
        /// Making WPF UI DragMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DragMove(object sender, RoutedEventArgs e)
        {
            DragMove();
        }
    }
}
