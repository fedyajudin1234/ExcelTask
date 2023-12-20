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
    /// Логика взаимодействия для AddNewLinkWindow.xaml
    /// </summary>
    public partial class AddNewLinkWindow : Window
    {
        public AddNewLinkWindow()
        {
            InitializeComponent();
            DataContext = new ModelsViewModel();
        }

        private void Is_Included_Checked(object sender, RoutedEventArgs e)
        {
            if (Is_Included.IsChecked == true)
            {
                Relation_TextBox.Visibility = Visibility.Visible;
                Relation_ComboBox.Visibility = Visibility.Visible;
                Count_TextBox.Visibility = Visibility.Visible;
                Count_TextBlock.Visibility = Visibility.Visible;
            }else if(Is_Included.IsChecked == false)
            {
                Relation_TextBox.Visibility = Visibility.Hidden;
                Relation_ComboBox.Visibility = Visibility.Hidden;
            }
        }
    }
}
