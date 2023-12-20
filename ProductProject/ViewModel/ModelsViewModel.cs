using ProductProject.Models;
using ProductProject.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProductProject.ViewModel
{
    public class ModelsViewModel: INotifyPropertyChanged
    {
        private List<Product> productsList = DataOperations.AllProducts();
        private List<Link> linksList = DataOperations.AllLinks();
        private List<Product> ProductsWithRemovedElement = new List<Product>();

        #region Commands For Windows
        private RelayCommand openAddNewProductWindow;
        public RelayCommand OpenAddNewProductWindow
        {
            get { 
                return openAddNewProductWindow ?? new RelayCommand(obj =>
                    {
                        AddProductWindow();
                }
                ); 
            }
        }

        private RelayCommand openAddNewLinkWindow;
        public RelayCommand OpenAddNewLinkWindow
        {
            get
            {
                return openAddNewLinkWindow ?? new RelayCommand(obj =>
                {
                    AddLinkWindow();
                }
                );
            }
        }
        #endregion

        public System.Windows.Controls.TabItem SelectedItem { get; set; }
        public static Product SelectedProduct { get; set; }
        public static Link SelectedLink { get; set; }

        private RelayCommand deleteItem;
        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new RelayCommand(obj =>
                {
                    //Window window = obj as Window;
                    if (SelectedItem.Name == "Product_Item" && SelectedProduct != null)
                    {
                        DataOperations.DeleteProduct(SelectedProduct);
                        UpdateAllModels();
                    }else if(SelectedItem.Name == "Link_Item" && SelectedLink != null)
                    {
                        DataOperations.DeleteLink(SelectedLink);
                        UpdateAllModels();
                    }
                });
            }
        }

        private RelayCommand editItemWindow;
        public RelayCommand EditItemWindow
        {
            get
            {
                return editItemWindow ?? new RelayCommand(obj =>
                {
                    //Window window = obj as Window;
                    if (SelectedItem.Name == "Product_Item" && SelectedProduct != null)
                    {
                        EditProductWindow(SelectedProduct);
                    }
                    else if (SelectedItem.Name == "Link_Item" && SelectedLink != null)
                    {
                        EditLinkWindow(SelectedLink);
                    }
                });
            }
        }

        #region Product
        public List<Product> ProductsList
        {
            get
            {
                return productsList;
            }
            set
            {
                productsList = value;
                NotifyPropertyChanged("ProductsList");
            }
        }

        #region Product_Windows

        public static string Name { get; set; }
        public static double Price { get; set; }

        private void AddProductWindow()
        {
            AddNewProductWindow addNewProductWindow = new AddNewProductWindow();
            SetCenterWindow(addNewProductWindow);
        }

        private void EditProductWindow(Product product)
        {
            EditProductWindow editProductWindow = new EditProductWindow(product);
            SetCenterWindow(editProductWindow);
        }
        #endregion


        private RelayCommand addNewProduct;
        public RelayCommand AddNewProduct
        {
            get
            {
                return addNewProduct ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if(Name != null && Price != 0)
                    {
                        DataOperations.AddProduct(Name, Price);
                        ShowAdditionalWindow();
                        UpdateAllModels();
                        SetNullProperties();
                        window.Close();
                    }
                });
            }
        }

        private RelayCommand editProduct;
        public RelayCommand EditProduct
        {
            get
            {
                return editProduct ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if (Name != null && Price != 0 && SelectedProduct != null)
                    {
                        DataOperations.EditProduct(SelectedProduct, Name, Price);
                        ShowAdditionalWindow();
                        UpdateAllModels();
                        SetNullProperties();
                        window.Close();
                    }
                });
            }
        }

        #region Update Product View
        private void UpdateAllProducts()
        {
            ProductsList = DataOperations.AllProducts();
            MainWindow.ViewProductsList.ItemsSource = null;
            MainWindow.ViewProductsList.Items.Clear();
            MainWindow.ViewProductsList.ItemsSource = ProductsList;
            MainWindow.ViewProductsList.Items.Refresh();
        }

        #endregion

        #endregion

        #region Link
        public List<Link> LinksList
        {
            get
            {
                return linksList;
            }
            set
            {
                linksList = value;
                NotifyPropertyChanged("LinksList");
            }
        }

        #region Link_Windows

        public static Product UpProduct { get; set; }
        public static Product Product { get; set; }
        public static int Count { get; set; }

        private void AddLinkWindow()
        {
            AddNewLinkWindow addNewLinkWindow = new AddNewLinkWindow();
            SetCenterWindow(addNewLinkWindow);

        }

        private void EditLinkWindow(Link link)
        {
            EditLinkWindow editLinkWindow = new EditLinkWindow(link);
            SetCenterWindow(editLinkWindow);
        }

        private RelayCommand addNewLink;
        public RelayCommand AddNewLink
        {
            get
            {
                return addNewLink ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if (Product != null && Count != 0)
                    {
                        DataOperations.AddLink(UpProduct, Product, Count);
                        ShowAdditionalWindow();
                        UpdateAllModels();
                        SetNullProperties();
                        window.Close();
                    }
                });
            }
        }

        private RelayCommand editLink;
        public RelayCommand EditLink
        {
            get
            {
                return editLink ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if (Product != null && SelectedLink != null)
                    {
                        DataOperations.EditLink(SelectedLink,UpProduct,Product,Count);
                        ShowAdditionalWindow();
                        UpdateAllModels();
                        SetNullProperties();
                        window.Close();
                    }
                });
            }
        }
        //private RelayCommand removeProductFromListCommand;
        //public RelayCommand RemoveProductFromListCommand
        //{
        //    get
        //    {
        //        return removeProductFromListCommand ?? new RelayCommand(obj =>
        //        {
        //            Window window = obj as Window;
        //            if (Product != null)
        //            {
        //                ProductsWithRemovedElement = DataOperations.RemoveProductFromList(Product);
        //                window.Close();
        //            }
        //        });
        //    }
        //}

        #endregion

        #region Update Links View
        private void UpdateAllLinks()
        {
            LinksList = DataOperations.AllLinks();
            MainWindow.ViewLinksList.ItemsSource = null;
            MainWindow.ViewLinksList.Items.Clear();
            MainWindow.ViewLinksList.ItemsSource = LinksList;
            MainWindow.ViewLinksList.Items.Refresh();
        }
        #endregion

        #endregion

        private void SetCenterWindow(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        private void ShowAdditionalWindow()
        {
            AdditionalWindow additionalWindow = new AdditionalWindow();
            SetCenterWindow(additionalWindow);
        }

        private void UpdateAllModels()
        {
            UpdateAllLinks();
            UpdateAllProducts();
        }

        private void SetNullProperties()
        {
            Name = null;
            Price = 0;
            Product = null;
            UpProduct = null;
            Count = 0;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
            }
        }
    }
}
