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
        public MainWindow()
        {
            InitializeComponent();
        }

        // Add new category
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addform = new CAdd();
            addform.DatabaseChanged += addform_DatabaseChanged;
            addform.ShowDialog();

            db = new managementdbEntities();
            CATEGORY newCategory = new CATEGORY();

            newCategory.CNAME = newCate;
            newCategory.CSTATUS = 1;
            db.CATEGORies.Add(newCategory);
            db.SaveChangesAsync();

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

        private void getSelectedItem(object sender, MouseButtonEventArgs e)
        {
            CATEGORY selectedCate = (CATEGORY)lvCategory.SelectedItems[0];
            db = new managementdbEntities();

        }

    }
}
