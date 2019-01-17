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
        private PUpdate pupdform;
        private OAdd oaddform;
        private Stats statsform;
        private string newCate, newPro, updPro, newOrd;
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

            if (newCate == null)
                return;

            db = new managementdbEntities();
            CATEGORY newCategory = db.CATEGORies.Where(x => x.CNAME == newCate).Select(x => x).FirstOrDefault();
            if (newCategory == null)
            {
                newCategory = new CATEGORY();
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
            newCate = null;
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
            List<CATEGORY> cATEGORies = filteredCate.ToList();
            lvCategory.ItemsSource = cATEGORies;

            // Product List = status == 1 && cstatus == 1
            db.Configuration.ProxyCreationEnabled = false;
            db.PRODUCTs.ToList();

            var filteredProduct = db.PRODUCTs.Local
                             .Where(x => x.PSTATUS == 1); // pstatus = 1
            PRODUCT newProduct = new PRODUCT();
            List<PRODUCT> pRODUCTs = filteredProduct.ToList();
            filteredProduct = from product in pRODUCTs
                              join category in cATEGORies
                              on product.CATE equals category.CNAME
                              select product;

            lvProduct.ItemsSource = filteredProduct.ToList() ;

            // Order list
            db.Configuration.ProxyCreationEnabled = false;
            lvOrder.ItemsSource = db.ORDERs.ToList();

            // Category in combobox
            cbCatagory.ItemsSource = db.CATEGORies.Where(x => x.CSTATUS == 1).ToList();

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

            if (newPro == null)
                return;

            //MessageBox.Show(newPro.ToString());
            var result = newPro.ToString();
            var tokens = newPro.Split(new string[] { "," },
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(token => token.Trim())
                    .ToArray();

            string barcode = tokens[0].ToString();
            PRODUCT newProduct = db.PRODUCTs.Where(x => x.BARCODE == barcode).Select(x => x).FirstOrDefault();
            if (newProduct == null)
            {
                newProduct = new PRODUCT();
                newProduct.BARCODE = tokens[0];
                newProduct.PNAME = tokens[1];
                newProduct.PRICE = int.Parse(tokens[2]);
                newProduct.QTY = int.Parse(tokens[3]);
                newProduct.CATE = tokens[4];
                newProduct.PSTATUS = 1;
                db.PRODUCTs.Add(newProduct);
            }
            else
            {
                newProduct.PSTATUS = 1;
            }
            db.SaveChanges();
            this.Page_Loaded(sender, e);
            newPro = null;
        }

        private void Button_Click_UpdPro(object sender, RoutedEventArgs e)
        {
            if (selectedPro == null)
                return;
            
            if (selectedPro.BARCODE == null)
                return;

            pupdform = new PUpdate(selectedPro);
            pupdform.DatabaseChanged += pupdform_DatabaseChanged;
            pupdform.ShowDialog();

            if (updPro == "")
                return;

            var result = updPro.ToString();
            //MessageBox.Show(result);
            var tokens = updPro.Split(new string[] { "," },
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(token => token.Trim())
                    .ToArray();

            PRODUCT updProduct = db.PRODUCTs.Where(x => x.BARCODE == selectedPro.BARCODE).Select(x => x).FirstOrDefault();
            
            // update = add + delete
            if(updProduct!=null)
            {
                // Not edit Barcode
                if (updProduct.BARCODE != tokens[0])
                {
                    PRODUCT newProduct = new PRODUCT();
                    newProduct.BARCODE = tokens[0];
                    newProduct.PNAME = tokens[1];
                    newProduct.PRICE = int.Parse(tokens[2]);
                    newProduct.QTY = int.Parse(tokens[3]);
                    newProduct.CATE = tokens[4];
                    newProduct.PSTATUS = 1;
                    updProduct.PSTATUS = 0;
                    db.PRODUCTs.Add(newProduct);
                }
                else
                {
                    updProduct.PNAME = tokens[1];
                    updProduct.PRICE = int.Parse(tokens[2]);
                    updProduct.QTY = int.Parse(tokens[3]);
                    updProduct.CATE = tokens[4];
                    updProduct.PSTATUS = 1;
                }
            }
            db.SaveChanges();
            this.Page_Loaded(sender, e);
            selectedPro = null;
        }

        private void Button_Click_DelPro(object sender, RoutedEventArgs e)
        {
            db = new managementdbEntities();
            if (selectedPro.BARCODE == null)
                return;

            PRODUCT delPro = db.PRODUCTs.Where(x => x.BARCODE == selectedPro.BARCODE).Select(x => x).SingleOrDefault();

            if (delPro != null)
                delPro.PSTATUS = 0;
            
            db.SaveChanges();
            this.Page_Loaded(sender, e);
        }

        private void Button_Click_AddOrder(object sender, RoutedEventArgs e)
        {
            oaddform = new OAdd();
            oaddform.DatabaseChanged += oadddform_DatabaseChanged;
            oaddform.ShowDialog();

            if (newOrd == null)
                return;

            var result = newOrd.ToString();
            var tokens = newOrd.Split(new string[] { "," },
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(token => token.Trim())
                    .ToArray();
            // BARCODE, QUANTITY, DATE, TOTAL, COUPON
            db = new managementdbEntities();

            // add to transaction data
            ORDER newOrder = new ORDER();
            newOrder.BARCODE = tokens[0];
            newOrder.QTY = int.Parse(tokens[1]);
            newOrder.DATE = DateTime.Parse(tokens[2]);
            newOrder.TOTAL = int.Parse(tokens[3]);
            db.ORDERs.Add(newOrder);

            // modify master data
           PRODUCT updProduct = db.PRODUCTs.Where(x => x.BARCODE == newOrder.BARCODE).Select(x => x).SingleOrDefault();
            if (updProduct != null)
                updProduct.QTY = updProduct.QTY - newOrder.QTY;
            //db.SaveChanges();

            // modify coupon date
            string couponCode = tokens[4].ToString();
            COUPON updCoupon = db.COUPONs.Where(x => x.CODE == couponCode).Select(x => x).SingleOrDefault();
            if (updCoupon != null)
                updCoupon.AVAILABLE = updCoupon.AVAILABLE - 1;
            //db.SaveChanges();

            db.SaveChanges();
            this.Page_Loaded(sender, e);
        }

        private void Button_Click_Stat(object sender, RoutedEventArgs e)
        {
            statsform = new Stats();
            statsform.ShowDialog();
        }

        private void getSelectedOrder(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click_Filter(object sender, RoutedEventArgs e)
        {
            if (cbCatagory.SelectedItem != null)
            {
                CATEGORY filterCate = (CATEGORY)cbCatagory.SelectedItem;

                var filteredProduct = db.PRODUCTs.Local
                                 .Where(x => x.PSTATUS == 1 && x.CATE == filterCate.CNAME); // pstatus = 1

                lvProduct.ItemsSource = filteredProduct.ToList();
            }
        }

        private void Button_Click_ClearSearch(object sender, RoutedEventArgs e)
        {
            this.Page_Loaded(sender, e);
        }

        void paddform_DatabaseChanged(string newDatabaseName)
        {
            // This will get called everytime you call "DatabaseChanged" on child
            newPro = newDatabaseName;
        }

        void pupdform_DatabaseChanged(string newDatabaseName)
        {
            // This will get called everytime you call "DatabaseChanged" on child
            updPro = newDatabaseName;
        }

        void oadddform_DatabaseChanged(string newDatabaseName)
        {
            // This will get called everytime you call "DatabaseChanged" on child
            newOrd = newDatabaseName;
        }
    }
}
