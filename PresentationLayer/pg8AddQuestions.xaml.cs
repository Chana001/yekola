using DataObjects;
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

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for pg8AddQuestions.xaml
    /// </summary>
    public partial class pg8AddQuestions : Page
    {
        User _user;
        public pg8AddQuestions(User user)
        {
            _user = user;
            InitializeComponent();
            MessageBox.Show("Feature not currently complete");
            SetupWindow();
        }

        private void SetupWindow()
        {
            cmbCategory.IsEnabled = false;
            cmbLevels.IsEnabled = false;
            dtgAddQuestions.IsEnabled = false;
            btnAdd.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnClose.IsEnabled = false;
        }
    }
}
