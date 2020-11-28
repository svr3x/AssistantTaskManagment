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

namespace PP03
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtDocument_Template_Click(object sender, RoutedEventArgs e)
        {
            Document_Template document_Template = new Document_Template();
            document_Template.Show();
            Hide();

        }

        private void BtDocuments_EU_Click(object sender, RoutedEventArgs e)
        {
            Documents_EU documents_EU = new Documents_EU();
            documents_EU.Show();
            Hide();
        }

        private void BtCMK_Click(object sender, RoutedEventArgs e)
        {
            CMK cMK = new CMK();
            cMK.Show();
            Hide();
        }
    }
}
