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

namespace Desktop
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
           
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Btnlog_Click(object sender, RoutedEventArgs e)
        {
            string id = name.Text;
            string password = pwd.Password;
            subnit(id, password);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (pwd.Password.Length != 0)
                {
                    string id = name.Text;
                    string password = pwd.Password;
                    subnit(id, password);


                }



            }

        }

        public void subnit(string name ,string pwd)
        {
            if(name=="Maliks" && pwd =="Maliksadmin123456")
            {
                if(price.IsChecked==true)
                {
                    change ch = new change();
                    ch.Show();
                }
                else
                {
                    condition c = new condition();
                    c.Show();
                }
               
                this.Close();
            }
            else
            {
                MessageBox.Show( "Incorrect !! ", "Alert !!");
            }

        }

        private void Btnclose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
