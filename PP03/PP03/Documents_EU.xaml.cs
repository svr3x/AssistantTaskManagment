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
using System.Diagnostics;

namespace PP03
{
    /// <summary>
    /// Логика взаимодействия для Documents_EU.xaml
    /// </summary>
    public partial class Documents_EU : Window
    {
        DBProcedures procedures = new DBProcedures();
        private string QR = "";

        public Documents_EU()
        {
            InitializeComponent();
            cbDocument_Template_Fill();
           //cbEU_CMK_RUP_Fill();
        }

        private void cbDocument_Template_Fill()
        {
            DBConnection connection = new DBConnection();
            connection.Document_Template_Fill();
            cbDocument_Template.ItemsSource = connection.dtDocument_Template.DefaultView;
            cbDocument_Template.SelectedValuePath = "ID_Document_Template";
            cbDocument_Template.DisplayMemberPath = "Document_Name";
            
        }

        //private void cbEU_CMK_RUP_Fill()
        //{
        //    DBConnection connection = new DBConnection();
        //    connection.EU_CMK_RUP_Fill();
        //    cbEU_CMK_RUP.ItemsSource = connection.dtEU_CMK_RUP.DefaultView;
        //    cbEU_CMK_RUP.SelectedValuePath = "ID_EU_CMK_RUP";
        //    cbEU_CMK_RUP.DisplayMemberPath = "Prefix";

        //}

        private void dgFill(string qr)
        {
            Action action = () =>
            {
                DBConnection connection = new DBConnection();
                DBConnection.qrDocuments_EU = qr;
                connection.Documents_EU_Fill();
                connection.Dependency.OnChange += Dependency_OnChange;
                dgDocuments_EU.ItemsSource = connection.dtDocuments_EU.DefaultView;
                dgDocuments_EU.Columns[0].Visibility = Visibility.Collapsed;
            };
            Dispatcher.Invoke(action);
        }

        private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                dgFill(QR);
        }

        private void BtDocuments_EU_InsertType_Click(object sender, RoutedEventArgs e)
        {
            procedures.resDocuments_EU_insert(tbDocument_Title.Text.ToString(), tbLink_To_The_Document.Text.ToString(),
                Convert.ToInt32(cbDocument_Template.SelectedValue.ToString()), Convert.ToInt32(cbEU_CMK_RUP.SelectedValue.ToString()));
            dgFill(QR);
        }

        private void BtDocuments_EU_UpdateType_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgDocuments_EU.SelectedItems[0];

            procedures.resDocuments_EU_update(Convert.ToInt32(ID["ID_Documents_EU"]), tbDocument_Title.Text.ToString(), tbLink_To_The_Document.Text.ToString(),
                Convert.ToInt32(cbDocument_Template.SelectedValue.ToString()), Convert.ToInt32(cbEU_CMK_RUP.SelectedValue.ToString()));
            dgFill(QR);
        }

        private void BtDocuments_EU_DeleteType_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgDocuments_EU.SelectedItems[0];
            procedures.resDocuments_EU_delete(Convert.ToInt32(ID["ID_Documents_EU"]));
            dgFill(QR);
        }

        private void BtClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgDocuments_EU.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[2].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[3].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[4].ToString() == tbSearch.Text)
                {
                    dgDocuments_EU.SelectedItem = dataRow;
                }
            }
        }

        

        private void DgDocuments_EU_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrDocuments_EU;
            dgFill(QR);
        }

        private void DgDocuments_EU_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Document_Title"):
                    e.Column.Header = "Название документа";
                    break;
                case ("Link_To_The_Document"):
                    e.Column.Header = "Ссылка на документ";
                    break;
                case ("Document_Temlate"):
                    e.Column.Header = "Шаблон";
                    break;
                case ("EU_CMK_RUP"):
                    e.Column.Header = "Префикс";
                    break;
            }
        }

        private void Bt1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
