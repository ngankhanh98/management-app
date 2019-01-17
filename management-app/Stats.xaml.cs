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
    /// Interaction logic for Stats.xaml
    /// </summary>
    public partial class Stats : Window
    {
        private managementdbEntities db;

        public Stats()
        {
            InitializeComponent();
            db = new managementdbEntities();
            List<PRODUCT> SaleItems = new List<PRODUCT>();
            List<ORDER> SaleQty = new List<ORDER>();

            List<PRODUCT> productList = db.PRODUCTs.ToList();
            List<ORDER> orderList = db.ORDERs.ToList();

            PRODUCT Item = new PRODUCT();
            var innerJoinQuery =
             from order in orderList
             join prod in productList on order.BARCODE equals prod.BARCODE
             select new { Item = prod.PNAME, SaleQty = order.QTY };

            //this.DataContext = innerJoinQuery;
            //lvSaleProduct.ItemsSource = innerJoinQuery.ToList();


            /////////////////////////////////////////////////////////
            //var groupJoinQuery = from prod in productList
            //                     join order in orderList on prod.BARCODE equals order.BARCODE into prodGroup
            //                     select prodGroup;

            var groupJoinQuery = from order in orderList
                                 join prod in productList on order.BARCODE equals prod.BARCODE
                                 group order by order.BARCODE into g
                                 select new
                                 {
                                     Item = g.First().PRODUCT.PNAME,
                                     SaleQty = g.Sum(x => x.QTY)
                                 };

            //////////////////////////////////////////////////////////
            this.DataContext = groupJoinQuery;
            lvSaleProduct.ItemsSource = groupJoinQuery.ToList();

        }

        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            
            List<PRODUCT> SaleItems = new List<PRODUCT>();
            List<ORDER> SaleQty = new List<ORDER>();

            List<PRODUCT> productList = db.PRODUCTs.ToList();
            List<ORDER> orderList = db.ORDERs.ToList();

            PRODUCT Item = new PRODUCT();
            DateTime dateTime, begin, end;
            int year;

            lblChooseTypeErr.Visibility = Visibility.Visible;
            if (cbOption.SelectedItem!=null)
            {
                string option = ((ComboBoxItem)cbOption.SelectedItem).Content.ToString();
                lblChooseTypeErr.Visibility = Visibility.Hidden;
                if (dpDate.SelectedDate != null)
                {
                    dateTime = (DateTime)dpDate.SelectedDate;
                    orderList = db.ORDERs.Where(x => x.DATE == dateTime).ToList();

                    if (option == "Products")
                    {
                        ProductType_Report(productList, orderList);
                    }
                    else
                    {
                        SaleType_Report(productList, orderList);
                    }
                }

                if (dpMonthYear.SelectedDate != null)
                {
                    dateTime = (DateTime)dpMonthYear.SelectedDate;
                    begin = new DateTime(dateTime.Year, dateTime.Month, 1, 0, 0, 0, 0);
                    end = new DateTime(dateTime.Year, dateTime.Month + 1, 1, 0, 0, 0, 0);
                    orderList = db.ORDERs.Where(x => x.DATE >= begin && x.DATE < end).ToList();

                    if (option == "Products")
                    {
                        ProductType_Report(productList, orderList);
                    }
                    else
                    {
                        SaleType_Report(productList, orderList);
                    }
                }

                if (dpBeginDate.SelectedDate != null && dpEndDate.SelectedDate != null)
                {
                    begin = (DateTime)dpBeginDate.SelectedDate;
                    end = (DateTime)dpEndDate.SelectedDate;
                    orderList = db.ORDERs.Where(x => x.DATE >= begin && x.DATE < end).ToList();

                    if (option == "Products")
                    {
                        ProductType_Report(productList, orderList);
                    }
                    else
                    {
                        SaleType_Report(productList, orderList);
                    }
                }

                if (txtYear.Text != "")
                {
                    year = int.Parse(txtYear.Text);
                    begin = new DateTime(year, 1, 1, 0, 0, 0, 0);
                    end = new DateTime(year, 12, 31, 23, 55, 55, 0);
                    orderList = db.ORDERs.Where(x => x.DATE >= begin && x.DATE < end).ToList();
                    if (option == "Products")
                    {
                        ProductType_Report(productList, orderList);
                    }
                    else
                    {
                        SaleType_Report(productList, orderList);
                    }
                }

                
                
            }

            
        }

        private void dateChange(object sender, SelectionChangedEventArgs e)
        {
            if (dpMonthYear != null)
                dpMonthYear.SelectedDate = null;
            if (txtYear != null)
                txtYear.Clear();
            if (dpBeginDate != null)
                dpBeginDate.SelectedDate = null;
            if (dpEndDate != null)
                dpEndDate.SelectedDate = null;
        }

        private void monthChange(object sender, SelectionChangedEventArgs e)
        {

            if (dpDate != null)
                dpDate.SelectedDate = null;
            if (txtYear != null)
                txtYear.Clear();
            if (dpBeginDate != null)
                dpBeginDate.SelectedDate = null;
            if (dpEndDate != null)
                dpEndDate.SelectedDate = null;
        }

        private void yearChange(object sender, TextChangedEventArgs e)
        {
            if (dpMonthYear != null)
                dpMonthYear.SelectedDate = null;
            if (dpDate != null)
                dpDate.SelectedDate = null;
            if (dpBeginDate != null)
                dpBeginDate.SelectedDate = null;
            if (dpEndDate != null)
                dpEndDate.SelectedDate = null;
        }

        private void beginDateChange(object sender, SelectionChangedEventArgs e)
        {
            if (dpMonthYear != null)
                dpMonthYear.SelectedDate = null;
            if (txtYear != null)
                txtYear.Clear();
            if (dpDate != null)
                dpDate.SelectedDate = null;

        }

        private void endDateChange(object sender, SelectionChangedEventArgs e)
        {
            if (dpMonthYear != null)
                dpMonthYear.SelectedDate = null;
            if (txtYear != null)
                txtYear.Clear();
            if (dpDate != null)
                dpDate.SelectedDate = null;
        }

        private void CbOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblChooseTypeErr.Visibility = Visibility.Hidden;
        }

        void ProductType_Report(List<PRODUCT> productList, List<ORDER> orderList)
        {
            int sumQty = 0;
            var groupJoinQuery = from order in orderList
                                 join prod in productList 
                                 on order.BARCODE equals prod.BARCODE
                                 group order by order.BARCODE into g
                                 select new
                                 {
                                     Item = g.First().PRODUCT.PNAME,
                                     SaleQty = g.Sum(x => x.QTY)
                                 };
            this.DataContext = groupJoinQuery;
            lvSaleProduct.ItemsSource = groupJoinQuery.ToList();
            lblSum.Content = "Summary Items: ";
            //var quantity = from order in orderList
            //               select order.QTY;
            //foreach (var item in quantity)
            //{
            //    sumQty += (int)item;
            //}

            foreach(var item in groupJoinQuery.ToList())
            {
                sumQty += (int)item.SaleQty;
            }
            lblsumValue.Content = sumQty.ToString();
            lvSaleProduct.Visibility = Visibility.Visible;
            lblSum.Visibility = Visibility.Visible;
            lvSaleTotal.Visibility = Visibility.Hidden;
            lblsumValue.Visibility = Visibility.Visible;
        }

        void SaleType_Report(List<PRODUCT> productList, List<ORDER> orderList)
        {
            int sumQty = 0;
            var groupJoinQuery = from order in orderList
                                 join prod in productList
                                 on order.BARCODE equals prod.BARCODE
                                 group order by order.BARCODE into g
                                 select new
                                 {
                                     Item = g.First().PRODUCT.PNAME,
                                     SaleQty = g.Sum(x => x.QTY) * g.First().PRODUCT.PRICE
                                 };
            this.DataContext = groupJoinQuery;
            lvSaleTotal.ItemsSource = groupJoinQuery.ToList();
            lblSum.Content = "Summary Total: ";
            var quantity = from order in orderList
                           select order.QTY;
            foreach (var item in groupJoinQuery.ToList())
            {
                sumQty += (int)item.SaleQty;
            }
            lblsumValue.Content = sumQty.ToString();
            lvSaleProduct.Visibility = Visibility.Hidden;
            lblSum.Visibility = Visibility.Visible;
            lblsumValue.Visibility = Visibility.Visible;
            lvSaleTotal.Visibility = Visibility.Visible;
        }

    }
}
