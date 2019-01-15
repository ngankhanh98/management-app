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

namespace management_app
{
    /// <summary>
    /// Interaction logic for PUpdate.xaml
    /// </summary>
    public partial class PUpdate : Window
    {
        public event DatabaseChangeHandler DatabaseChanged;
        public delegate void DatabaseChangeHandler(string newDatabaseName);
        private managementdbEntities db;
        private PRODUCT selectProduct;
        public PUpdate(PRODUCT selProduct)
        {
            InitializeComponent();
            db = new managementdbEntities();
            cbCatagory.ItemsSource = db.CATEGORies.ToList();
            txtBarcode.Text = selProduct.BARCODE;
            txtPName.Text = selProduct.PNAME;
            txtPrice.Text = selProduct.PRICE.ToString();
            txtQty.Text = selProduct.QTY.ToString();
            cbCatagory.SelectedItem = db.CATEGORies.Where(x => x.CNAME == selProduct.CATE).Select(x => x).SingleOrDefault();
            selectProduct = selProduct;
        }

        public void BtnUpdPro_Click(object sender, RoutedEventArgs e)
        {
            if (this.DatabaseChanged != null)
            {
                CATEGORY cate = (CATEGORY)cbCatagory.SelectedItem;
                this.DatabaseChanged(txtBarcode.Text + "," + txtPName.Text + "," + txtPrice.Text + "," + txtQty.Text + "," + cate.CNAME);
            }
            this.Close();
        }

    }
}
