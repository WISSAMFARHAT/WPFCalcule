using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Desktop
{
    /// <summary>
    /// Interaction logic for change.xaml
    /// </summary>
    public partial class change : Window
    {
        public change()
        {
            InitializeComponent();
            using (StreamReader r = new StreamReader("../../data/db.json"))
            {
                string json = r.ReadToEnd();
                data items = JsonConvert.DeserializeObject<data>(json);
                TVA.Text = items.TVA.ToString();
                LB50.Text = items.lb50.ToString();
                LB100.Text = items.lb100.ToString();
                LB200.Text = items.lb200.ToString();
                LB.Text = items.lb.ToString();
                D10.Text = items.d10.ToString();
                D50.Text = items.d50.ToString();
                D100.Text = items.d100.ToString();
                D.Text = items.d.ToString();
            }
             
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

     

        private void Btnclose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btnchange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newvalue = new data
                {
                    TVA = float.Parse(TVA.Text),
                    lb50 = float.Parse(LB50.Text),
                    lb100 = float.Parse(LB100.Text),
                    lb200 = float.Parse(LB200.Text),
                    lb = float.Parse(LB.Text),
                    d10 = float.Parse(D10.Text),
                    d50 = float.Parse(D50.Text),
                    d100 = float.Parse(D100.Text),
                    d = float.Parse(D.Text)
                };
                var jsonTowriter = JsonConvert.SerializeObject(newvalue, Formatting.Indented);
                using (var writer = new StreamWriter("../../data/db.json"))
                {
                    writer.Write(jsonTowriter);
                    MessageBox.Show("Update ");
                }
            }
            catch (Exception ex)
            {

            }


        }
    }
}
