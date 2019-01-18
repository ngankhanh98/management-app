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
    /// Interaction logic for CAdd.xaml
    /// </summary>
    public partial class CAdd : Window
    {
        managementdbEntities db;
        public event DatabaseChangeHandler DatabaseChanged;
        public delegate void DatabaseChangeHandler(string newDatabaseName);

        public CAdd()
        {
            InitializeComponent();
            db = new managementdbEntities();
        }

        public void BtnNewCategory_Click(object sender, RoutedEventArgs e)
        {
            if (txtNewCate.Text == "")
                lblNewCateError.Content = "Please enter a category";

            bool categoryExisted = db.CATEGORies.Where(x => x.CNAME == txtNewCate.Text && x.CSTATUS==1).Any();

            if (categoryExisted == true)
                lblNewCateError.Content = "This category already existed";

            if (this.DatabaseChanged != null && txtNewCate.Text!="" && categoryExisted==false)
            {
                lblNewCateError.Content = "";
                this.DatabaseChanged(txtNewCate.Text);
                this.Close();
            }
        }

    }
}
