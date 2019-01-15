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
    /// Interaction logic for PAdd.xaml
    /// </summary>
    public partial class PAdd : Window
    {
        public event DatabaseChangeHandler DatabaseChanged;
        public delegate void DatabaseChangeHandler(string newDatabaseName);
        private managementdbEntities db;

        public PAdd()
        {
            InitializeComponent();
            db = new managementdbEntities();
            cbCatagory.ItemsSource = db.CATEGORies.Where(x => x.CSTATUS == 1).ToList();
        }

        public void BtnNewPro_Click(object sender, RoutedEventArgs e)
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
