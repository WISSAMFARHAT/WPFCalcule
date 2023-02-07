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
    /// Interaction logic for condition.xaml
    /// </summary>
    public partial class condition : Window
    {
        float TVA, lb1, lb2, lb3, lb4, lb5, d1, d2, d3, d4, d5, d6;
        public condition()
        {
            InitializeComponent();
            using (StreamReader r = new StreamReader("./db.json"))
            {
                string json = r.ReadToEnd();
                data items = JsonConvert.DeserializeObject<data>(json);
                TVA = items.TVA;
                lb1 = items.lb1;
                lb2 = items.lb2;
                lb3 = items.lb3;
                lb4 = items.lb4;
                lb5 = items.lb5;
                d1 = items.d1;
                d2 = items.d2;
                d3 = items.d3;
                d4 = items.d4;
                d5 = items.d5;
                d6 = items.d6;
                LB1.Text = items.tolb1.ToString();
                LB2.Text = items.tolb2.ToString();
                LB3.Text = items.tolb3.ToString();
                LB4.Text = items.tolb4.ToString();
                D1.Text = items.toD1.ToString();
                D2.Text = items.toD2.ToString();
                D3.Text = items.toD3.ToString();
                D5.Text = items.toD4.ToString();
                D6.Text = items.toD5.ToString();

                l1.Text = "LB <= "+items.tolb1.ToString()+" : ";
                l2.Text = "LB <= " + items.tolb2.ToString() + " : ";
                l3.Text = "LB <= " + items.tolb3.ToString() + " : ";
                l4.Text = "LB <= " + items.tolb4.ToString() + " : ";
                ld1.Text = "dollar <= " + items.toD1.ToString() + " : ";
                ld2.Text = "dollar <= " + items.toD2.ToString() + " : ";
                ld3.Text = "dollar <= " + items.toD3.ToString() + " : ";
                ld5.Text = "dollar <= " + items.toD4.ToString() + " : ";
                ld6.Text = "dollar <= " + items.toD5.ToString() + " : ";



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
                    tolb1 = float.Parse(LB1.Text),
                    tolb2 = float.Parse(LB2.Text),
                    tolb3 = float.Parse(LB3.Text),
                    tolb4 = float.Parse(LB4.Text),
                    toD1 = float.Parse(D1.Text),
                    toD2 = float.Parse(D2.Text),
                    toD3 = float.Parse(D3.Text),
                    toD4 = float.Parse(D5.Text),
                    toD5 = float.Parse(D6.Text),
                    lb1=this.lb1,
                    lb2 = this.lb2,
                    lb3 = this.lb3,
                    lb4 = this.lb4,
                    lb5 = this.lb5,
                    d1=this.d1,
                    d2 = this.d2,
                    d3 = this.d3,
                    d4 = this.d4,
                    d5 = this.d5,
                    d6 = this.d6,
                    TVA=this.TVA
                };
                var jsonTowriter = JsonConvert.SerializeObject(newvalue, Formatting.Indented);
                using (var writer = new StreamWriter("./db.json"))
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
