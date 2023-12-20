using OfficeOpenXml;
using ProductProject.Models;
using ProductProject.ViewModel;
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

namespace ProductProject.View
{
    /// <summary>
    /// Логика взаимодействия для AdditionalWindow.xaml
    /// </summary>
    public partial class AdditionalWindow : Window
    {
        public AdditionalWindow()
        {
            InitializeComponent();
        }

        private void Close_Window_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var file = new FileInfo("excelFile.xlsx");
            List<string> products = new List<string>();
            List<Link> links = new List<Link>();
            //for(int i = 0; i < DataOperations.AllLinks().Count; i++)
            //{
            //    var link = products.Select(s => DataOperations.GetNameByID(s.ProductId));
            //    //DataOperations.AllLinks()[i] = DataOperations.AllLinks()[i].Re
            //}
            //var query = from l in DataOperations.AllLinks()
            //            join p in DataOperations.AllProducts()
            //            on l.ProductId equals p.Id
            //            select Name;

            foreach (var link in DataOperations.AllLinks())
            {
                //products = DataOperations.AllLinks().AsEnumerable().Select(r => r.ProductId);
                links.Add(link);
                //products.Select(p => DataOperations.GetNameByID(p.ProductId));
            }
            SaveLinks(links, file);
            //Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
            //application.Workbooks.Add();
            //Microsoft.Office.Interop.Excel.Worksheet worksheet = application.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
            //List<Link> links = DataOperations.AllLinks();
            //for (int i = 0; i < links.Count; i++)
            //{
            //    worksheet.Cells[i] = links[i];
            //}
            this.Close();
        }

        private void SaveLinks(List<Link> links, FileInfo file)
        {
            try
            {
                if (file.Exists)
                {
                    file.Delete();
                }

                using (var package = new ExcelPackage(file))
                {
                    var worksheet = package.Workbook.Worksheets.Add("Main");
                    //worksheet.DeleteColumn(1);
                    worksheet.Column(1).Hidden = true;
                    worksheet.Column(4).Hidden = true;
                    worksheet.Column(6).Hidden = true;
                    var range = worksheet.Cells["A1"].LoadFromCollection(links, true);
                    //range.SkipColumns(1);
                    range.AutoFitColumns();

                    package.Save();
                }
            }
            catch(IOException ioe)
            {
                MessageBox.Show($"Ошибка: {ioe.Message}. \nЗакройте приложение с редактированием файла");
            }
        }
    }
}
