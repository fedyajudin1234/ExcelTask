using ProductProject.ViewModel;
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

namespace ProductProject.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewProductWindow.xaml
    /// </summary>
    public partial class AddNewProductWindow : Window
    {
        private static Random random = new Random();
        public AddNewProductWindow()
        {
            InitializeComponent();
            DataContext = new ModelsViewModel();
        }

        //private void Create_Values_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    if(Name_TextBox.Text != null)
        //    {
        //        Name_TextBox.Text.Remove(0);
        //    }
        //    if(Price_TextBox.Text != null)
        //    {
        //        Price_TextBox.Text.Remove(0);
        //    }

        //    int length = random.Next(5, 10);
        //    Name_TextBox.Text = RandomString(length);
        //    Price_TextBox.Text = random.Next(1,10000).ToString();

        //}

        //public static string RandomString(int length)

        //{

        //    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        //    return new string(Enumerable.Repeat(chars, length)

        //.Select(s => s[random.Next(s.Length)]).ToArray());

        //}
    }
}
