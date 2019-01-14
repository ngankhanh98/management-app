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
        private string newCate;
        private CATEGORY selectedCate = new CATEGORY();
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
            db = new managementdbEntities();
            db.Configuration.ProxyCreationEnabled = false;
            db.CATEGORies.ToList();

            var filteredData = db.CATEGORies.Local
                             .Where(x => x.CSTATUS == 1);
            lvCategory.ItemsSource = filteredData;
        }

        // Select item
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

    }
}
