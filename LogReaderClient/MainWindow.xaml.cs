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
using LogReaderClient.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.ObjectModel;

namespace LogReaderClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Incident> CollectionforListView { get; set; }
        static HttpClient client = new HttpClient();

        public MainWindow()
        {
            RunAsync().Wait();
            client.BaseAddress = new Uri("http://localhost:1361/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }
        static async Task<List<Incident>> GetProductAsync(string path)
        {
            List<Incident> incident = new List<Incident>();
            incident = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                incident = await response.Content.ReadAsAsync<List<Incident>>();
            }
            return incident;
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:1361/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void fetchlog_Click(object sender, RoutedEventArgs e)
        {
            connectionErrorTextBlock.Visibility = Visibility.Hidden;

            try
            {
                CollectionforListView = await GetProductAsync("api/log/getlog");
                CollectionforListView.RemoveAt(0);

                foreach (Incident incident in CollectionforListView)
                {
                    listView.Items.Add(incident);
                }
            }
            catch (Exception)
            {
                connectionErrorTextBlock.Visibility = Visibility.Visible;
            }

        }
    }
}
