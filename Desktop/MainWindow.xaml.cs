using System;
using System.Collections.Generic;
using System.Globalization;
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
            ulong total = 0;
            Decimal LPBTOTAL = 0;
            if (a == 1)
            {
                var result = new string(CostInsert.Text.Where(c => char.IsDigit(c)).ToArray());
                ulong vOut = Convert.ToUInt64(result);
                decimal d = Convert.ToDecimal(CostInsert.Text);
                CostInsert.Text = d.ToString("#,0");
                if (vOut <= 50000)//2
                {
                    total = (ulong)(vOut * 2 * 1.11);
                }
                else if (vOut <= 100000)//1.9
                {
                    total = (ulong)(vOut * 1.9 * 1.11);
                }
                else if (vOut <= 200000)//1.7
                {
                    total = (ulong)(vOut * 1.7 * 1.11);
                }
                else//1.5
                {
                    total = (ulong)(vOut * 1.5 * 1.11);
                }
                total = RoundLBP(total.ToString(), total);

                selling.Text = total.ToString("#,0") + "  LBP";
            }
            else
            {
                Decimal v = Convert.ToDecimal(CostInsert.Text);

                if (v <= 10)//2
                {
                    LPBTOTAL = Decimal.Multiply(v, 2);
                    LPBTOTAL = Decimal.Multiply(LPBTOTAL, (Decimal)1.11);
                }
                else if (v <= 50)//1.9
                {
                    LPBTOTAL = Decimal.Multiply(v, (Decimal)1.9);
                    LPBTOTAL = Decimal.Multiply(LPBTOTAL, (Decimal)1.11);
                }
                else if (v <= 100)//1.7
                {
                    LPBTOTAL = Decimal.Multiply(v, (Decimal)1.7);
                    LPBTOTAL = Decimal.Multiply(LPBTOTAL, (Decimal)1.11);
                }
                else//1.5
                {
                    LPBTOTAL = Decimal.Multiply(v, (Decimal)1.5);
                    LPBTOTAL = Decimal.Multiply(LPBTOTAL, (Decimal)1.11);
                }

                selling.Text = LPBTOTAL.ToString("C");
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
            Image img = new Image();
            img.Show();


        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void change(object sender, TextChangedEventArgs e)
        {
        }
    }
}
