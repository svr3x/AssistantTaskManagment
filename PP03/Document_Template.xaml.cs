using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace PP03
{
    /// <summary>
    /// Логика взаимодействия для Document_Template.xaml
    /// </summary>
    public partial class Document_Template : Window
    {
        DBProcedures procedures = new DBProcedures();
        private string QR = "";

        public Document_Template()
        {
            InitializeComponent();
        }

        private void dgFill(string qr)
        {
            Action action = () =>
            {
                DBConnection connection = new DBConnection();
                DBConnection.qrDocument_Template = qr;
                connection.Document_Template_Fill();
                connection.Dependency.OnChange += Dependency_OnChange;
                dgDocument_Template.ItemsSource = connection.dtDocument_Template.DefaultView;
                dgDocument_Template.Columns[0].Visibility = Visibility.Collapsed;
            };
            Dispatcher.Invoke(action);
        }

        private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                dgFill(QR);
        }

        private void dgDocument_Template_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Path_To_File"):
                    e.Column.Header = "Путь к файлу";
                    break;
                case ("Document_Name"):
                    e.Column.Header = "Название документа";
                    break;
            }
        }

        private void BtDocument_Template_InsertType_Click(object sender, RoutedEventArgs e)
        {
            procedures.resDocument_Template_insert(tbDocument_Name.Text.ToString(), tbPath_To_File.Text.ToString());
            dgFill(QR);
        }

        private void BtDocument_Template_UpdateType_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgDocument_Template.SelectedItems[0];
            procedures.resDocument_Template_update(Convert.ToInt32(ID["ID_Document_Template"]), tbDocument_Name.Text.ToString(), tbPath_To_File.Text.ToString());
            dgFill(QR);
        }

        private void BtDocument_Template_DeleteType_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgDocument_Template.SelectedItems[0];
            procedures.resDocument_Template_delete(Convert.ToInt32(ID["ID_Document_Template"]));
            dgFill(QR);
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            Visibility = Visibility.Collapsed;
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgDocument_Template.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[2].ToString() == tbSearch.Text)
                {
                    dgDocument_Template.SelectedItem = dataRow;
                }
            }
        }

        private void Document_Template_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrDocument_Template;
            dgFill(QR);
        }
    }
}
