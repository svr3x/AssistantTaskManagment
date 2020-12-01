using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP03
{
    class DBConnection
    {
        public static SqlConnection connection = new SqlConnection(
        "Server = 89.179.240.226,63388; " +
        " Initial Catalog = Educational_institution; Persist Security Info = true; multipleactiveresultsets=True;" +
        " User ID = UliyanovSM; Password = \"!gh%ErT\"");

        public SqlDependency Dependency = new SqlDependency();

        public DataTable dtDocument_Template = new DataTable("Document_Template");
        public DataTable dtDocuments_EU = new DataTable("Documents_EU");
        public DataTable dtEducational_Unit = new DataTable("Documents_EU");
        public DataTable dtType_Of_Educational_Unit = new DataTable("Type_Of_Educational_Unit");
        public DataTable dtForm_Of_Control = new DataTable("Form_Of_Control");
        public DataTable dtForm_Of_Control_EU = new DataTable("Form_Of_Control_EU");
        public DataTable dtEU_CMK_RUP = new DataTable("EU_CMK_RUP");
        public DataTable dtCMK = new DataTable("CMK");


        public static string

        ///
        qrDocument_Template = "SELECT [ID_Document_Template], [Path_To_File], [Document_Name] FROM [dbo].[Document_Template]",

        qrDocuments_EU = "SELECT [ID_Documents_EU], [Document_Title], [Link_To_The_Document], [Document_Name] as \"Название шаблона\", [Prefix] as \"Префикс\" " +
         " FROM [dbo].[Documents_EU] INNER JOIN [dbo].[Document_Template] ON [dbo].[Documents_EU].[Document_Template_ID] = " +
         " [dbo].[Document_Template].[ID_Document_Template] INNER JOIN [dbo].[EU_CMK_RUP] ON " +
         " [dbo].[Documents_EU].[EU_CMK_RUP_ID] = [dbo].[EU_CMK_RUP].[ID_EU_CMK_RUP]",

        qrEducational_Unit = "SELECT [ID_Educational_Unit], [Name_Of_The_EU] FROM [dbo].[Educational_Unit]",

        qrType_Of_Educational_Unit = "SELECT [ID_Type_Of_Educational_Unit], [Number_Of_Type] FROM [dbo].[Type_Of_Educational_Unit]",

        qrForm_Of_Control = "SELECT [ID_Form_Of_Control], [Name_Of_The_Form] FROM [dbo].[Form_Of_Control]",

        qrForm_Of_Control_EU = "SELECT [ID_Form_Of_Control_EU], [Number_Of_Semester] FROM [dbo].[Form_Of_Control_EU] INNER JOIN [dbo].[Form_Of_Control] ON " +
            " [dbo].[Form_Of_Control_EU].[Form_Of_Control] = [dbo].[Form_Of_Control].[ID_Form_Of_Control]",

        qrEU_CMK_RUP = "SELECT [ID_EU_CMK_RUP], [Prefix], [Total_Number_Of_Hours], [Theoretical_Hours], [Lab_Prac_Hours], [Individual_Work], [Consultations], " +
            " [Coursework_Project], [Interim_Certification], [Name_Of_The_EU], [Number_Of_Type], [Number_Of_Semester], [RUP_ID], [EU_CMK_RUP_ID] FROM [dbo].[EU_CMK_RUP] " +
            " INNER JOIN [dbo].[Educational_Unit] ON [dbo].[EU_CMK_RUP].[Educational_Unit_ID] = [dbo].[Educational_Unit].[ID_Educational_Unit] " +
            " INNER JOIN [dbo].[Type_Of_Educational_Unit] ON [dbo].[EU_CMK_RUP].[Type_Of_Educational_Unit_ID] = [dbo].[Type_Of_Educational_Unit].[ID_Type_Of_Educational_Unit] " +
            " INNER JOIN [dbo].[Form_Of_Control_EU] ON [dbo].[EU_CMK_RUP].[Form_Of_Control_EU_ID] = [dbo].[Form_Of_Control_EU].[ID_Form_Of_Control_EU] " +
            " INNER JOIN [dbo].[CMK_RUP] ON [dbo].[EU_CMK_RUP].[CMK_RUP_ID] = [dbo].[CMK_RUP].[ID_CMK_RUP]", 
           // " INNER JOIN [dbo].[EU_CMK_RUP] ON [dbo].[EU_CMK_RUP].[EU_CMK_RUP_ID] = [dbo].[EU_CMK_RUP].[ID_EU_CMK_RUP] ",



        qrCMK = " SELECT [ID_CMK], [Name_CMK] FROM [dbo].[CMK]";


        private static SqlCommand command = new SqlCommand("", connection);


        public static Int32 IDRecord, IDUser;
        //создание зависимости
        public SqlDependency dependency = new SqlDependency();
        //заполнние через зависимость
        private void dtFill(DataTable table, string query)
        {
            command.CommandText = query;
            command.Notification = null;
            dependency.AddCommandDependency(command);
            SqlDependency.Start(connection.ConnectionString);
            command.CommandText = query;
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();
        }

        public void Document_Template_Fill()
        {
            dtFill(dtDocument_Template, qrDocument_Template);
        }
   

        public void Documents_EU_Fill()
        {
            dtFill(dtDocuments_EU, qrDocuments_EU);
        }

        public void Educational_Unit_Fill()
        {
            dtFill(dtEducational_Unit, qrEducational_Unit);
        }
      
        public void Type_Of_Educational_Unit_Fill()
        {
            dtFill(dtType_Of_Educational_Unit, qrType_Of_Educational_Unit);
        }

        public void Form_Of_Control_Fill()
        {
            dtFill(dtForm_Of_Control, qrForm_Of_Control);
        }

        public void Form_Of_Control_EU_Fill()
        {
            dtFill(dtForm_Of_Control_EU, qrForm_Of_Control_EU);
        }

        public void EU_CMK_RUP_Fill()
        {
            dtFill(dtEU_CMK_RUP, qrEU_CMK_RUP);
        }

        public void CMK_Fill()
        {
            dtFill(dtCMK, qrCMK);
        }
    }
}
