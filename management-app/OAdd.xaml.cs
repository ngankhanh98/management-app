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
    /// Interaction logic for OAdd.xaml
    /// </summary>
    public partial class OAdd : Window
    {
        private managementdbEntities db;
        public event DatabaseChangeHandler DatabaseChanged;
        public delegate void DatabaseChangeHandler(string newDatabaseName);
        COUPON validCoupon;
        PRODUCT pro;
        int quatity = 0;
        double total;

        public OAdd()
        {
            InitializeComponent();
            db = new managementdbEntities();
            cbProduct.ItemsSource = db.PRODUCTs.Where(x => x.PSTATUS == 1).ToList();
        }

        private void BtnCoupon_Click(object sender, RoutedEventArgs e)
        {
            db = new managementdbEntities();
            string coupon = txtCoupon.Text;

            validCoupon = db.COUPONs.Where(x => x.CODE == coupon).Select(x=>x).SingleOrDefault();

            if(validCoupon==null)
            {
                lblCouponError.Content = "This coupon is not valid.";
            }
            else
            {
                lblCouponError.Content = "Coupon applied, " + validCoupon.VALUE + "% discount.";
                total -= (int)validCoupon.VALUE / 100.0 * total;
                lblTotal.Content = total.ToString();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            pro = (PRODUCT)cbProduct.SelectedItem;
            
            if(this.DatabaseChanged!=null)
            {
                
                this.DatabaseChanged(pro.BARCODE + "," + txtQty.Text + "," + datePicker.SelectedDate.ToString() + "," + lblTotal.Content + "," + validCoupon.CODE.ToString());
            }
            this.Close();
        }

        private void TxtQty_TextChanged(object sender, TextChangedEventArgs e)
        {
            quatity = int.Parse(txtQty.Text);
            if (pro != null)
                total = (int)pro.PRICE * quatity;
            lblTotal.Content = total.ToString();
        }

        private void CbProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pro = (PRODUCT)cbProduct.SelectedItem;
            if(quatity!=0)
                total = (int)pro.PRICE * quatity;
            lblTotal.Content = total.ToString();
        }

    }
}
