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
using Application = Microsoft.Office.Interop.Excel.Application;
using Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using Action = System.Action;
using System.IO;
using Microsoft.Win32;

namespace PP03
{
    /// <summary>
    /// Логика взаимодействия для CMK.xaml
    /// </summary>
    public partial class CMK : System.Windows.Window
    {
        //Word._Application application;
        //Word._Document document;

        //Object missingObj = System.Reflection.Missing.Value;
        //Object trueObj = true;
        //Object falseObj = false;




        DBProcedures procedures = new DBProcedures();
        private string QR = "";
        public string CMK_ID = "";
        public string Name_CMK = "1";

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

        private void queryOfTables_CMK(string query)
        {
            SqlConnection connection = new SqlConnection(
            "Server = 89.179.240.226, 63388; " +
            " Initial Catalog = Educational_institution; Persist Security Info = true; multipleactiveresultsets=True;" +
            " User ID = UliyanovSM; Password = \"!gh%ErT\"");
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            CMK_ID = command.ExecuteScalar().ToString();
            connection.Close();
        }

        private void queryOfTables(string query)
        {
            SqlConnection connection = new SqlConnection(
            " Server = 89.179.240.226, 63388; " +
            " Initial Catalog = Educational_institution; Persist Security Info = true; multipleactiveresultsets=True;" +
            " User ID = UliyanovSM; Password = \"!gh%ErT\"");
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteScalar();
            connection.Close();

        }

        private void BtCMK_Import_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.DefaultExt = "*.xls;*.xlsx";
            ofd.Filter = "Microsoft Excel (*.xls*)|*.xls*";
            ofd.Title = "Выберите документ Excel";
            if (ofd.ShowDialog() == true)
            {
                Application xlApp = new Application();
               Workbook xlWorkbook = xlApp.Workbooks.Open(ofd.FileName, Type.Missing, true);

                _Worksheet list_1 = (_Worksheet)xlWorkbook.Sheets[1];//Получаем последний лист
                Range xlRange_1 = list_1.UsedRange;//Получаем используемый сектор ячеек в листе

                int Row_CMK = 1;
                int Cell_CMK = 1;
                while (Name_CMK != "")
                {
                    Name_CMK = xlRange_1.Cells[Row_CMK, Cell_CMK].Text; // Таблица ЦМК
                    queryOfTables("INSERT INTO CMK values('" + Name_CMK + "')");
                    Row_CMK++;
                }

            }
            else
            {
                MessageBox.Show("Вы не выбрали файл для открытия", "Внимание", MessageBoxButton.OK);
               return;
            }

            string xlFileName = ofd.FileName;


            //string TestExcel = @"C:\Users\User\Desktop\Импорт.xlsx";
            
           // xlWorkbook.Close();


            ////создаем обьект приложения word
            //application = new Word.Application();
            //// создаем путь к файлу
            //Object templatePathObj = @"C:\Users\CVR3X\Desktop\Импорт для РР03.docx"; ;

            //try
            //{
            //    document = application.Documents.Add(ref templatePathObj, ref missingObj, ref missingObj, ref missingObj);
            //}
            //catch (Exception error)
            //{
            //    document.Close(ref falseObj, ref missingObj, ref missingObj);
            //    application.Quit(ref missingObj, ref missingObj, ref missingObj);
            //    document = null;
            //    application = null;
            //    throw error;
            //}
            //application.Visible = true;



        }

        private void BtClose_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            Visibility = Visibility.Collapsed;
        }


        private void BtCMK_InsertType_Click(object sender, RoutedEventArgs e)
        {
            if (tbCMK.Text == "")
            {
                MessageBox.Show("Поля пусты!" +
                "  Повторите попытку ввода!", "Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                procedures.resCMK_insert(tbCMK.Text.ToString());
                dgFill(QR);
            }
   
        }

        private void btCMK_UpdateType_Click(object sender, RoutedEventArgs e)
        {
           
            if (tbCMK.Text == "")
            {
                MessageBox.Show("Поля пусты!" +
                "  Выберите запись!", "Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                DataRowView ID = (DataRowView)dgCMK.SelectedItems[0];
                procedures.resCMK_update(Convert.ToInt32(ID["ID_CMK"]), tbCMK.Text.ToString());
                dgFill(QR);
            }

        }

        private void btCMK_DeleteType_Click(object sender, RoutedEventArgs e)
        {
            if (tbCMK.Text == "")
            {
                MessageBox.Show("Поля пусты!" +
                "  Выберите запись!", "Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                DataRowView ID = (DataRowView)dgCMK.SelectedItems[0];
                procedures.resCMK_delete(Convert.ToInt32(ID["ID_CMK"]));
                dgFill(QR);
            }

            
        }
    }
}
