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
using System.Diagnostics;

namespace PP03
{
    /// <summary>
    /// Логика взаимодействия для Document_Template.xaml
    /// </summary>
    public partial class Document_Template : System.Windows.Window
    {
        DBProcedures procedures = new DBProcedures();
        private string QR = "";

        public Document_Template()
        {
            InitializeComponent();
      
        }

        //DataGrid
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

        //Заполнение таблицы
        private void dgDocument_Template_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Path_To_File"):
                    e.Column.Header = "Путь к файлу";
                    break;
                case ("Document_Name"):
                    e.Column.Header = "Название шаблона";
                    break;
            }
        }

        //Процедура добавления данных
        private void BtDocument_Template_InsertType_Click(object sender, RoutedEventArgs e)
        {
            //Условие / Проверка на пустые поля
            if (tbPath_To_File.Text == "" | tbDocument_Name.Text == "")
            {
                //Предупреждение о пустых полях
                MessageBox.Show("Поля пусты!" +
                "  Повторите попытку ввода!", "Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                //Процедура добавления данных
                procedures.resDocument_Template_insert(tbPath_To_File.Text.ToString(), tbDocument_Name.Text.ToString());
                dgFill(QR);
            }
        }

        //Процедура обновления данных
        private void BtDocument_Template_UpdateType_Click(object sender, RoutedEventArgs e)
        {
            //Проверка на пустые поля
            if (tbPath_To_File.Text == "" | tbDocument_Name.Text == "")
            {
                //Предупреждение о пустых полях
                MessageBox.Show("Поля пусты!" +
                "  Выберите запись!", "Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                //Процедура обновления данных
                DataRowView ID = (DataRowView)dgDocument_Template.SelectedItems[0];
                procedures.resDocument_Template_update(Convert.ToInt32(ID["ID_Document_Template"]), tbPath_To_File.Text.ToString(), tbDocument_Name.Text.ToString());
                dgFill(QR);
            }      
        }

        //Процедура удаления данных
        private void BtDocument_Template_DeleteType_Click(object sender, RoutedEventArgs e)
        {
            //Проверка на пустые поля
            if (tbPath_To_File.Text == "" | tbDocument_Name.Text == "")
            {
                //Предупреждение о пустых полях
                MessageBox.Show("Поля пусты!" +
                "  Выберите запись!", "Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                //Процедура удаления данных
                DataRowView ID = (DataRowView)dgDocument_Template.SelectedItems[0];
                procedures.resDocument_Template_delete(Convert.ToInt32(ID["ID_Document_Template"]));
                dgFill(QR); 
            }
            
        }

        //Процедура закрытия окна
        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            Visibility = Visibility.Collapsed;
        }

        //Поиск в DataGrid
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

        //Загрузка таблицы
        private void Document_Template_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrDocument_Template;
            dgFill(QR);
        }

        //OpenFileDialog выбор файла
        private void btDocument_Template_Open_Click(object sender, RoutedEventArgs e)
        {
            //Открытие OpenFileDialog
            OpenFileDialog open = new OpenFileDialog();
            //Дериктория по умолчанию
            open.InitialDirectory = "c:\\";
            //Фильтр по расширению файла
            open.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            open.FilterIndex = 2;
            open.RestoreDirectory = true;
           
            //Условие, если результат положительный, тогда заполнить поля ввода названием документа и его расположение
            if (open.ShowDialog() == true)
            {
                tbPath_To_File.Text = open.FileName;
                tbDocument_Name.Text = open.SafeFileName;
            }

        }
        //Гиперссылка
        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
