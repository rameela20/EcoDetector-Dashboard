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

namespace EcoDetector
{
    /// <summary>
    /// Interaction logic for Thresholds.xaml
    /// </summary>
    public partial class Thresholds : Window
    {
        public Thresholds()
        {
            InitializeComponent();
            tText.Text = MainWindow.tLTemp.ToString();
            hText.Text = MainWindow.tLHum.ToString();
            lText.Text = MainWindow.tLLight.ToString();
            cText.Text = MainWindow.tLCo2.ToString();
            t2Text.Text = MainWindow.tTemp.ToString();
            h2Text.Text = MainWindow.tHum.ToString();
            l2Text.Text = MainWindow.tLight.ToString();
            c2Text.Text = MainWindow.tCo2.ToString();
        }

        private void btnSetL_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.tLTemp = Double.Parse(tText.Text);
            MainWindow.tLHum = Double.Parse(hText.Text);
            MainWindow.tLLight = Double.Parse(lText.Text);
            MainWindow.tLCo2 = Double.Parse(cText.Text);
            MainWindow.tTemp = Double.Parse(t2Text.Text);
            MainWindow.tHum = Double.Parse(h2Text.Text);
            MainWindow.tLight = Double.Parse(l2Text.Text);
            MainWindow.tCo2 = Double.Parse(c2Text.Text);
            this.Close();
           // MessageBox.Show("Threshold are :" + MainWindow.tTemp+" "+MainWindow.tHum + " " + MainWindow.tLight + " " + MainWindow.tCo2);
            //MessageBox.Show("Threshold are :" + MainWindow.tLTemp + " " + MainWindow.tLHum + " " + MainWindow.tLLight + " " + MainWindow.tLCo2);
        }

        private void btnCancelL_Click(object sender, RoutedEventArgs e)
        {
            tText.Text = "";
            hText.Text = "";
            lText.Text = "";
            cText.Text = "";
            t2Text.Text = "";
            h2Text.Text = "";
            l2Text.Text = "";
            c2Text.Text = "";
        }
    }
}
