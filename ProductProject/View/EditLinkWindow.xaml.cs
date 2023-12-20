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
    /// Логика взаимодействия для EditLinkWindow.xaml
    /// </summary>
    public partial class EditLinkWindow : Window
    {
        public EditLinkWindow(Link link)
        {
            InitializeComponent();
            DataContext = new ModelsViewModel();
            ModelsViewModel.SelectedLink = link;
            ModelsViewModel.UpProduct = DataOperations.GetNameByID((int)link.UpProduct);
            //Product product = DataOperations.GetNameByID(link.ProductId);
            ModelsViewModel.Product = DataOperations.GetNameByID(link.ProductId);
            ModelsViewModel.Count = link.Count;

        }
    }
}
