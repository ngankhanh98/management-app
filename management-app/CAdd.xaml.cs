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
        public event DatabaseChangeHandler DatabaseChanged;
        public delegate void DatabaseChangeHandler(string newDatabaseName);

        public CAdd()
        {
            InitializeComponent();
        }

        public void BtnNewCategory_Click(object sender, RoutedEventArgs e)
        {
            if (txtNewCate.Text == "")
                lblNewCateError.Content = "Please enter a category";

            if (this.DatabaseChanged != null && txtNewCate.Text!="")
            {
                lblNewCateError.Content = "";
                this.DatabaseChanged(txtNewCate.Text);
                this.Close();
            }
        }

    }
}
