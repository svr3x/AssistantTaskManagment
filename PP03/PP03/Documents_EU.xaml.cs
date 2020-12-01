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
using Microsoft.Win32;
using Action = System.Action;

namespace PP03
{
    /// <summary>
    /// Логика взаимодействия для Documents_EU.xaml
    /// </summary>
    public partial class Documents_EU : System.Windows.Window
    {
        
        private SqlCommand command = new SqlCommand("", DBConnection.connection);
        

        public Documents_EU()
        {
            InitializeComponent();          
            cbDocument_Template_Fill();
            cbEU_CMK_RUP_Fill();
          
        }
        
        private string QR = "";
        DBProcedures procedures = new DBProcedures();



        //ComboBox "Шаблон документа"
        private void cbDocument_Template_Fill()
        {
            DBConnection connection = new DBConnection();
            connection.Document_Template_Fill();
            cbDocument_Template.ItemsSource = connection.dtDocument_Template.DefaultView;
            cbDocument_Template.SelectedValuePath = "ID_Document_Template";
            cbDocument_Template.DisplayMemberPath = "Document_Name";
            
        }

        //ComboBox "Префикс"
        private void cbEU_CMK_RUP_Fill()
        {
            DBConnection connection = new DBConnection();
            connection.EU_CMK_RUP_Fill();
            cbEU_CMK_RUP.ItemsSource = connection.dtEU_CMK_RUP.DefaultView;
            cbEU_CMK_RUP.SelectedValuePath = "ID_EU_CMK_RUP";
            cbEU_CMK_RUP.DisplayMemberPath = "Prefix";

        }

        //DataGrid
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
                dgDocuments_EU.Columns[1].MaxWidth = 180;
                dgDocuments_EU.Columns[2].MaxWidth = 135;
                dgDocuments_EU.Columns[3].MaxWidth = 140;

            };
            Dispatcher.Invoke(action);
        }

        private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                dgFill(QR);          
           
        }

        //Процедура добавления данных
        private void BtDocuments_EU_InsertType_Click(object sender, RoutedEventArgs e)
        {
            //Условие / Проверка на пустые поля
            if (tbDocument_Title.Text == "" | tbLink_To_The_Document.Text == "" | cbDocument_Template.SelectedIndex == -1 | cbEU_CMK_RUP.SelectedIndex == -1)
            {
                //Сообщение об ошибке
                MessageBox.Show("Поля пусты!" +
                "  Повторите попытку ввода!", "Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
            else
            {
                //Процедура добавления данных
                procedures.resDocuments_EU_insert(tbDocument_Title.Text.ToString(), tbLink_To_The_Document.Text.ToString(),
                Convert.ToInt32(cbDocument_Template.SelectedValue.ToString()), Convert.ToInt32(cbEU_CMK_RUP.SelectedValue.ToString()));
                dgFill(QR);
            }
        }

        //Процедура обновления данных
        private void BtDocuments_EU_UpdateType_Click(object sender, RoutedEventArgs e)
        {
            //Проверка на пустые поля
            if (tbDocument_Title.Text == "" | tbLink_To_The_Document.Text == "" |  cbDocument_Template.SelectedIndex == -1 | cbEU_CMK_RUP.SelectedIndex == -1)
            {
                //Сообщение об ошибке
                MessageBox.Show("Поля пусты!" +
                "  Выберите запись!", "Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                //Процедура обновления данных
                DataRowView ID = (DataRowView)dgDocuments_EU.SelectedItems[0];
                procedures.resDocuments_EU_updated(Convert.ToInt32(ID["ID_Documents_EU"]), tbDocument_Title.Text.ToString(), tbLink_To_The_Document.Text.ToString(),
                    Convert.ToInt32(cbDocument_Template.SelectedValue.ToString()), Convert.ToInt32(cbEU_CMK_RUP.SelectedValue.ToString()));
                dgFill(QR);             
            }
   
        }

        //Процедура удаления данных
        private void BtDocuments_EU_DeleteType_Click(object sender, RoutedEventArgs e)
        {
            //Проверка на пустые поля
            if (tbDocument_Title.Text == "" | tbLink_To_The_Document.Text == "" |  cbDocument_Template.SelectedIndex == -1 | cbEU_CMK_RUP.SelectedIndex == -1)
            {
                //Сообщение об ошибке
                MessageBox.Show("Поля пусты!" +
                "  Выберите запись!", "Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                //Процедура удаления данных
                DataRowView ID = (DataRowView)dgDocuments_EU.SelectedItems[0];
                procedures.resDocuments_EU_delete(Convert.ToInt32(ID["ID_Documents_EU"]));
                dgFill(QR);
            }
     
        }

        //Событие для закрытия окна
        private void BtClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            Visibility = Visibility.Collapsed;
        }


        //Поиск данных в таблице
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

       
        //Загрузка DataGrid
        private void DgDocuments_EU_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrDocuments_EU;
            dgFill(QR);
            cbDocument_Template_Fill();
            cbEU_CMK_RUP_Fill();

        }

        //Заполненение таблицы
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
                case ("Document_Name"):
                    e.Column.Header = "Название шаблона";
                    break;
                case ("Prefix"):
                    e.Column.Header = "Префикс";
                    break;
            }
        }

        private void Bt1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbDocument_Template_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        //OpenFileDialog для выбора нужного документа
        private void btOpen_Link_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "c:\\";
            open.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            open.FilterIndex = 2;
            open.RestoreDirectory = true;

            if (open.ShowDialog() == false)
            {
                tbDocument_Title.Text = "Файл отсутствует";
                tbLink_To_The_Document.Text = "Файл отсутствует";
                MessageBox.Show("Вы не выбрали файл!", "Внимание", MessageBoxButton.OK);
                return;
                      
            }
            else
            {
                tbLink_To_The_Document.Text = open.FileName;
                tbDocument_Title.Text = open.SafeFileName;

            }
         
        }

        //Фильтрация текста 
        private void chbFilter_Checked(object sender, RoutedEventArgs e)
        {
            string newQr = QR + " where [Document_Title] like '%" + tbSearch.Text + "%' or " +
                "[Link_To_The_Document] like '%" + tbSearch.Text + "%' or " +
                "[Document_Name] like '%" + tbSearch.Text + "%' or " +
                "[Prefix] like '%" + tbSearch.Text + "%'";
            dgFill(newQr);

            chbF.IsChecked = false;
        }

        //Фильтрация записей в таблице где "Файл отсутствует"
        private void chbF_Checked(object sender, RoutedEventArgs e)
        {
            if(chbF.IsChecked == true)
            {
                string newQr = QR + " where [Document_Title] = 'Файл отсутствует' or " +
                    " [Link_To_The_Document] = 'Файл отсутствует' ";
                dgFill(newQr);
             
            }

            chbFilter.IsChecked = false;
        }

        //Кнопка "сбросить"
        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            
            chbF.IsChecked = false;
            chbFilter.IsChecked = false;
            tbSearch.Text = null;
            dgFill(QR);
        }

    }
}
