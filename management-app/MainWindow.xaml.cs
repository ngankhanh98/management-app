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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace management_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private managementdbEntities db;
        private CAdd addform;
        private PAdd paddform;
        private string newCate, newPro;
        private CATEGORY selectedCate = new CATEGORY();
        private PRODUCT selectedPro = new PRODUCT();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Add new category
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            addform = new CAdd();
            addform.DatabaseChanged += addform_DatabaseChanged;
            addform.ShowDialog();

            db = new managementdbEntities();
            CATEGORY newCategory = db.CATEGORies.Where(x => x.CNAME == newCate).Select(x => x).FirstOrDefault();
            if (newCategory == null)
            {
                newCategory.CNAME = newCate;
                newCategory.CSTATUS = 1;
                db.CATEGORies.Add(newCategory);
            }
            else
            {
                newCategory.CSTATUS = 1;
            }
            db.SaveChanges();

            this.Page_Loaded(sender, e);
        }
        void addform_DatabaseChanged(string newDatabaseName)
        {
            // This will get called everytime you call "DatabaseChanged" on child
            newCate = newDatabaseName;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Category List
            db = new managementdbEntities();
            db.Configuration.ProxyCreationEnabled = false;
            db.CATEGORies.ToList();

            var filteredCate = db.CATEGORies.Local
                             .Where(x => x.CSTATUS == 1);
            lvCategory.ItemsSource = filteredCate;

            // Product List
            db.Configuration.ProxyCreationEnabled = false;
            db.PRODUCTs.ToList();

            var filteredProduct = db.PRODUCTs.Local
                             .Where(x => x.PSTATUS == 1);
            lvProduct.ItemsSource = filteredProduct;
        }

        // Select category
        private void getSelectedItem(object sender, MouseButtonEventArgs e)
        {
            selectedCate = (CATEGORY)lvCategory.SelectedItems[0];
        }
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            db = new managementdbEntities();
            CATEGORY delEntry = db.CATEGORies.Where(x => x.CNAME == selectedCate.CNAME).Select(x => x).FirstOrDefault();
            delEntry.CSTATUS = 0;
            db.SaveChanges();

            this.Page_Loaded(sender, e);
        }

        // Select product
        private void getSelectedItemProduct(object sender, MouseButtonEventArgs e)
        {
            selectedPro = (PRODUCT)lvProduct.SelectedItems[0];
        }

        private void Button_Click_AddPro(object sender, RoutedEventArgs e)
        {
            paddform = new PAdd();
            paddform.DatabaseChanged += paddform_DatabaseChanged;
            paddform.ShowDialog();

            db = new managementdbEntities();
            MessageBox.Show(newPro.ToString());
            //PRODUCT newProduct = db.PRODUCTs.Where(x => x.PNAME == newPro).Select(x => x).FirstOrDefault();
            //if (newProduct == null)
            //{
            //    newProduct.PNAME = newCate;
            //    newProduct.CSTATUS = 1;
            //    db.PRODUCTs.Add(newProduct);
            //}
            //else
            //{
            //    newCategory.CSTATUS = 1;
            //}
            //db.SaveChanges();

            //this.Page_Loaded(sender, e);
        }
        void paddform_DatabaseChanged(string newDatabaseName)
        {
            // This will get called everytime you call "DatabaseChanged" on child
            newPro = newDatabaseName;
        }
    }
}
