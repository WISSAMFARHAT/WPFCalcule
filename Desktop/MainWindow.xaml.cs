using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

namespace Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int a = 1;
        public float TVA;
        public float lb1;
        public float lb2;
        public float lb3;
        public float lb4;
        public float lb5;
        public float d1;
        public float d2;
        public float d3;
        public float d4;
        public float d5;
        public float d6;

        public float tolb1;
        public float tolb2;
        public float tolb3;
        public float tolb4;
        public float toD1;
        public float toD2;
        public float toD3;
        public float toD4;
        public float toD5;
        public MainWindow()
        {
            InitializeComponent();
            
            dollar.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#131313");
            dollar.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#f8b100");
            LBP.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#f8b100");
            LBP.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#f8b100");
            a = 1;
            CostInsert.Focus();
            
        }
    
       private void Dollar_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            LBP.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#131313");
            LBP.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#f8b100");
            btn.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#f8b100");
            btn.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#f8b100");
            a = 2;
            CostInsert.Text = "" ;
            selling.Text = "";
            sellingVAT.Text = "";
            CostInsert.Focus();
        }

        private void LBP_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            dollar.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#131313");
            dollar.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#f8b100");
            btn.Background= (SolidColorBrush)new BrushConverter().ConvertFrom("#f8b100");
            btn.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#f8b100");
            a = 1;
            CostInsert.Text = "" ;
            selling.Text = "";
            sellingVAT.Text = "";
            CostInsert.Focus();
        }

        private void Btnclose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btnclear_Click(object sender, RoutedEventArgs e)
        {
            CostInsert.Text = "";
            selling.Text = "";
            sellingVAT.Text = "";
        }
       
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (a == 1) { 
            Regex regex = new Regex("[^0-9]+");
             e.Handled = regex.IsMatch(e.Text);
                
               
                
               
                
            }
            if (a == 2)
            {
                Regex regex = new Regex("[^0-9\\.]+"); 
                e.Handled = regex.IsMatch(e.Text);
               
               

            }

     
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if(CostInsert.Text.Length != 0) {
                    
                    Calcule(); }

                
                
            }

        }

        private void Calcule()
        {
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

           
            ulong total = 0;
            ulong totalvat = 0;
            Decimal LPBTOTAL = 0;
            Decimal LPBTOTALVAT = 0;
            if (a == 1)
            {
                var result = new string(CostInsert.Text.Where(c => char.IsDigit(c)).ToArray());
                ulong vOut = Convert.ToUInt64(result);
                decimal d = Convert.ToDecimal(CostInsert.Text);
                CostInsert.Text = d.ToString("#,0");
                if (vOut <= tolb1)//lb1
                {
                    total = (ulong)(vOut * lb1);
                }
                else if (vOut <= tolb2)//lb2
                {
                    total = (ulong)(vOut * lb2);
                }
                else if (vOut <= tolb3)//lb3
                {
                    total = (ulong)(vOut * lb3);
                }
                else if (vOut <= tolb4)//lb3
                {
                    total = (ulong)(vOut * lb4);
                }
                else//lb4
                {
                    total = (ulong)(vOut * lb5 );
                }
                totalvat = (ulong)(total * TVA);
                total = RoundLBP(total.ToString(), total);
                totalvat= RoundLBP(totalvat.ToString(), totalvat);
                selling.Text = total.ToString("#,0") + "  LBP";
                sellingVAT.Text= totalvat.ToString("#,0") + "  LBP";
            }
            else
            {
                Decimal v = Convert.ToDecimal(CostInsert.Text);

                if (v <= (Decimal)toD1)//d1
                {
                    LPBTOTAL = Decimal.Multiply(v, (Decimal)d1);
                    LPBTOTALVAT = Decimal.Multiply(LPBTOTAL, (Decimal)TVA);
                }
                else if (v <= (Decimal)toD2)//d2
                {
                    LPBTOTAL = Decimal.Multiply(v, (Decimal)d2);
                    LPBTOTALVAT = Decimal.Multiply(LPBTOTAL, (Decimal)TVA);
                }
                else if (v <= (Decimal)toD3)//d3
                {
                    LPBTOTAL = Decimal.Multiply(v, (Decimal)d3);
                    LPBTOTALVAT = Decimal.Multiply(LPBTOTAL, (Decimal)TVA);
                }
                else if (v <= (Decimal)toD4)//d4
                {
                    LPBTOTAL = Decimal.Multiply(v, (Decimal)d4);
                    LPBTOTALVAT = Decimal.Multiply(LPBTOTAL, (Decimal)TVA);
                }
                else if (v <= (Decimal)toD5)//d5
                {
                    LPBTOTAL = Decimal.Multiply(v, (Decimal)d5);
                    LPBTOTALVAT = Decimal.Multiply(LPBTOTAL, (Decimal)TVA);
                }
                else//d6
                {
                    LPBTOTAL = Decimal.Multiply(v, (Decimal)d6);
                    LPBTOTALVAT = Decimal.Multiply(LPBTOTAL, (Decimal)TVA);
                }

                selling.Text = LPBTOTAL.ToString("C");
                sellingVAT.Text = LPBTOTALVAT.ToString("C");
            }
        }

        private ulong RoundLBP(string t,ulong total)
        {

            char[] ch = t.ToCharArray();
            var s = "" + ch[ch.Length - 3] + "" + ch[ch.Length - 2] + "" + ch[ch.Length - 1];
            int test = Int32.Parse(s);
            if(test <250)
            {
                total = total - Convert.ToUInt64(test) + 250;
                return total;
            }else if(test <500)
            {
                total = total - Convert.ToUInt64(test) + 500;
                return total;
            }else if (test <750)
            {
                total = total - Convert.ToUInt64(test) + 750;
                return total;
            }else
            {
                total = total - Convert.ToUInt64(test) + 1000;
                return total;
            }
            
        }

        private void Btncalcule_Click(object sender, RoutedEventArgs e)
        {
            if (CostInsert.Text.Length != 0) { Calcule(); }
            CostInsert.Focus();
            
        }
        private void Btnshady_Click(object sender, RoutedEventArgs e)
        {
            login l = new login();
            l.Show();


        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

 }
}
