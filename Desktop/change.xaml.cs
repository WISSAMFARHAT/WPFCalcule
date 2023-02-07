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
        float tolb1,tolb2,tolb3, tolb4, toD1, toD2, toD3, toD4, toD5;
        public change()
        {
            InitializeComponent();
            using (StreamReader r = new StreamReader("./db.json"))
            {
                string json = r.ReadToEnd();
                data items = JsonConvert.DeserializeObject<data>(json);
                TVA.Text = items.TVA.ToString();
                LB1.Text = items.lb1.ToString();
                LB2.Text = items.lb2.ToString();
                LB3.Text = items.lb3.ToString();
                LB4.Text = items.lb4.ToString();
                LB5.Text = items.lb5.ToString();
                l1.Text = "LB <= "+(Int32)items.tolb1+" :";
                l2.Text = "LB <= " + (Int32)items.tolb2 + " :";
                l3.Text = "LB <= " + (Int32)items.tolb3 + " :";
                l4.Text = "LB <= " + (Int32)items.tolb4 + " :";
                l5.Text = "LB > " + (Int32)items.tolb4 + " :";
                D1.Text = items.d1.ToString();
                D2.Text = items.d2.ToString();
                D3.Text = items.d3.ToString();
                D4.Text = items.d4.ToString();
                D5.Text = items.d5.ToString();
                D6.Text = items.d6.ToString();
                ld1.Text = "dollar <= " + items.toD1 + " :";
                ld2.Text = "dollar <= " + items.toD2 + " :";
                ld3.Text = "dollar <= " + items.toD3 + " :";
                ld4.Text = "dollar <= " + items.toD4 + " :";
                ld5.Text = "dollar <= " + items.toD5 + " :";
                ld6.Text = "dollar > " + items.toD5 + " :";
                tolb1 = items.tolb1;
                tolb2 = items.tolb2;
                tolb3 = items.tolb3;
                tolb4 = items.tolb4;
                toD1 = items.toD1;
                toD2 = items.toD2;
                toD3 = items.toD3;
                toD4 = items.toD4;
                toD5 = items.toD5;


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
                    lb1 = float.Parse(LB1.Text),
                    lb2 = float.Parse(LB2.Text),
                    lb3 = float.Parse(LB3.Text),
                    lb4 = float.Parse(LB4.Text),
                    lb5= float.Parse(LB5.Text),
                    d1 = float.Parse(D1.Text),
                    d2 = float.Parse(D2.Text),
                    d3= float.Parse(D3.Text),
                    d4 = float.Parse(D4.Text),
                    d5 = float.Parse(D5.Text),
                    d6 = float.Parse(D6.Text),
                    tolb1=this.tolb1,
                    tolb2 = this.tolb2,
                    tolb3 = this.tolb3,
                    tolb4=this.tolb4,
                    toD1=this.toD1,
                    toD2 = this.toD2,
                    toD3 = this.toD3,
                    toD4 = this.toD4,
                    toD5 = this.toD5,
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
