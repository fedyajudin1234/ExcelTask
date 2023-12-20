using ProductProject.Models;
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
    /// Логика взаимодействия для EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        public EditProductWindow(Product product)
        {
            InitializeComponent();
            DataContext = new ModelsViewModel();
            ModelsViewModel.SelectedProduct = product;
            ModelsViewModel.Name = product.Name;
            ModelsViewModel.Price = product.Price;
        }
    }
}
