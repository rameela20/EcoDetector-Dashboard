using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using System.Windows.Threading;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace EcoDetector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        DispatcherTimer timer;
        string response;
        ListViewItem item;
       JObject resObj;
        String msgT="";

        public static double tTemp=40.0;
        public static double tHum= 80.0;
        public static double tLight= 500.0;
        public static double tCo2= 1000.0;

        public static double tLTemp= 25.0;
        public static double tLHum= 40.0;
        public static double tLLight= 30.0;
        public static double tLCo2= 400.0;


        public MainWindow()
        {
            InitializeComponent();
            
            item = new ListViewItem();
            item.ContentTemplate = (DataTemplate)this.FindResource("DataTemplate1");
            listView.Items.Add(item);



            ListViewItem item2 = new ListViewItem();
            item2.ContentTemplate = (DataTemplate)this.FindResource("DataTemplate1");
            //listView.Items.Add(item2);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();








        }
        void timer_Tick(object sender, EventArgs e)
        {
            /* backgroundWorker = new BackgroundWorker();
             backgroundWorker.DoWork +=
                 new DoWorkEventHandler(backgroundWorker_DoWork);
             backgroundWorker.RunWorkerAsync();*/
            GetRequest();
            
            // textBox.Background = Brushes.Red;

        }
        
        public async void GetRequest()
        {

            msgText.Clear();
            msgT = "";

            Uri geturi = new Uri("https://ecodetector-3d39d.firebaseio.com/ecoLog.json?orderBy=\"$key\"&limitToLast=1&auth=lvWBlD7IubAta3uWRlaWwTZdXIRckAa3qFH8gsaB"); //replace your url  
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage responseGet = await client.GetAsync(geturi);
            response = await responseGet.Content.ReadAsStringAsync();
            resObj = JObject.Parse(response);
            string t = resObj.First.Children().First().ToString();
            JObject obj = JObject.Parse(t);
            string te = obj.GetValue("temp").ToString();
            string temp = te + " Celcius";
            double t1 = Double.Parse(te);
            if ((t1 < tLTemp))
            {
                //msgGrid.Visibility = Visibility.Visible;
                //msgText.Clear();
                msgT += "Temperature Low\n\n";
            }
            else if ((t1 > tTemp))
            {
                //msgText.Clear();
                //msgGrid.Visibility = Visibility.Visible;
                msgT += "Temperature High\n\n";
            }


           
            string hum = obj.GetValue("hum").ToString();
            string h = hum + " %";
            double h1 = Double.Parse(hum);
            if ((h1 < tLHum))
            {
                //msgGrid.Visibility = Visibility.Visible;
               // msgText.Clear();
                msgT += "Humidity Low\n\n";
            }
            else if ((h1 > tHum))
            {
               //msgText.Clear();
                //msgGrid.Visibility = Visibility.Visible;
                msgT += "Humidity High\n\n";
            }

            string satu1 = obj.GetValue("light").ToString();
            string satu = satu1 + " Lux";
            double s = Double.Parse(satu1);
            if ((s < tLLight))
            {
                //msgText.Clear();
                //msgGrid.Visibility = Visibility.Visible;
                msgT += "Light Low\n\n";
            }
            else if ((s > tLight))
            {
               //msgText.Clear();
                //msgGrid.Visibility = Visibility.Visible;
                msgT += "Light High\n\n";
            }
            string car = obj.GetValue("co2").ToString();
            string c = car + " PPM";
            double c1 = Double.Parse(car);
            if ((c1 < tLCo2))
            {
               //msgText.Clear();
                //msgGrid.Visibility = Visibility.Visible;
                msgT += "CO2 Low\n\n";
            }
            else if ((c1 > tCo2))
            {
               // msgText.Clear();
                //msgGrid.Visibility = Visibility.Visible;
                msgT += "CO2 High\n\n";
            }


            //textBox.Background = Brushes.Green;

            //setting data to datatemplate controls

            item = new ListViewItem();

            //DataTemplate d1=FindResource("Data")
            tempText.Text = temp;
            satuText.Text = satu;
            nameText.Text = h;
            bpText.Text = c;
            if(!msgT.Equals(""))
                msgGrid.Visibility = Visibility.Visible;
            msgText.Text = msgT;
            msgT = "";
            //msgText.Clear();

            //pulseText.Text=
            
            //Console.WriteLine(response.ToString());
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            new Thresholds().Visibility=Visibility.Visible;
        }
    }
}
