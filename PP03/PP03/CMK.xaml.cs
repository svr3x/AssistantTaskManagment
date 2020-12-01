using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;



namespace PP03
{
    /// <summary>
    /// Логика взаимодействия для CMK.xaml
    /// </summary>
    public partial class CMK : Window
    {
        DBProcedures procedures = new DBProcedures();
        private string QR = "";

        public CMK()
        {
            InitializeComponent();
        }

        private void dgFill(string qr)
        {
            Action action = () =>
            {
                DBConnection connection = new DBConnection();
                DBConnection.qrCMK = qr;
                connection. CMK_Fill();
                connection.Dependency.OnChange += Dependency_OnChange;
                dgCMK.ItemsSource = connection.dtCMK.DefaultView;
                dgCMK.Columns[0].Visibility = Visibility.Collapsed;
            };
            Dispatcher.Invoke(action);
        }

        private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                dgFill(QR);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrCMK;
            dgFill(QR);
        }
    

        private void DgCMK_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Name_CMK"):
                    e.Column.Header = "Название";
                    break;
                
            }         
        }

        private void BtCMK_InsertType_Click(object sender, RoutedEventArgs e)
        {

        }

        

        private void BtCMK_Import_Click(object sender, RoutedEventArgs e)
        {
            Action action = () =>
            {
                DataGrid dg = dgCMK;
                dg.SelectAllCells();
                dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, dg);
                dg.UnselectAllCells();
                DBProcedures export = new DBProcedures();

                Thread thread = new Thread(export.Export_Word);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();

            };
            Dispatcher.Invoke(action);



            //Excel.Application exApp = new Excel.Application();
            //exApp.Workbooks.Add();
            //Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;
            //int i, j;
            //for (i = 0; i <= dgCMK.Columns.Count - 2; i++)
            //{
            //    for (j = 0; j <= dgCMK.Columns.Count - 1; j++)
            //    {
            //        wsh.Cells[i + 1, j + 1] = dgCMK[j, i].Value.ToString();
            //    }
            //}
            //exApp.Visible = true;


        }

        private void BtClose_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            Visibility = Visibility.Collapsed;
        }
    }
}
