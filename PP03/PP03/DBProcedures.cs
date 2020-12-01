using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;

namespace PP03
{
    class DBProcedures
    {



        private SqlCommand command = new SqlCommand("", Configuration_Class.connection);
        

        private void commandConfig(string config)
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[" + config + "]";
            command.Parameters.Clear();
        }

        public void resDocument_Template_insert(string Path_To_File, string Document_Name)
        {
            commandConfig("Document_Template_insert");

            
            command.Parameters.AddWithValue("@Path_To_File", Path_To_File);
            command.Parameters.AddWithValue("@Document_Name", Document_Name);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void resDocument_Template_update(Int32 ID_Document_Template,  string Path_To_File, string Document_Name)
        {
            commandConfig("Document_Template_update");
            command.Parameters.AddWithValue("@ID_Document_Template", ID_Document_Template);           
            command.Parameters.AddWithValue("@Path_To_File", Path_To_File);
            command.Parameters.AddWithValue("@Document_Name", Document_Name);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void resDocument_Template_delete(Int32 ID_Document_Template)
        {
            commandConfig("Document_Template_delete");

            command.Parameters.AddWithValue("@ID_Document_Template", ID_Document_Template);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void resDocuments_EU_insert(string Document_Title, string Link_To_The_Document, Int32 Document_Template_ID, Int32 EU_CMK_RUP_ID)
        {
            commandConfig("Documents_EU_insert");

            command.Parameters.AddWithValue("@Document_Title", Document_Title);
            command.Parameters.AddWithValue("@Link_To_The_Document", Link_To_The_Document);
            command.Parameters.AddWithValue("@Document_Template_ID", Document_Template_ID);
            command.Parameters.AddWithValue("@EU_CMK_RUP_ID", EU_CMK_RUP_ID);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void resDocuments_EU_update(Int32 ID_Documents_EU, string Document_Title, string Link_To_The_Document, Int32 Document_Template_ID, Int32 EU_CMK_RUP_ID)
        {
            commandConfig("Documents_EU_update");

            command.Parameters.AddWithValue("@ID_Documents_EU", ID_Documents_EU);
            command.Parameters.AddWithValue("@Document_Title", Document_Title);
            command.Parameters.AddWithValue("@Link_To_The_Document", Link_To_The_Document);
            command.Parameters.AddWithValue("@Document_Template_ID", Document_Template_ID);
            command.Parameters.AddWithValue("@EU_CMK_RUP_ID", EU_CMK_RUP_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void resDocuments_EU_delete(Int32 ID_Documents_EU)
        {
            commandConfig("Documents_EU_delete");

            command.Parameters.AddWithValue("@ID_Documents_EU", ID_Documents_EU);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }


        public void resEducational_Unit_insert(string Name_Of_The_EU)
        {
            commandConfig("Educational_Unit_insert");

            command.Parameters.AddWithValue("@Name_Of_The_EU", Name_Of_The_EU);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void resEducational_Unit_update(Int32 ID_Educational_Unit, string Name_Of_The_EU)
        {
            commandConfig("Educational_Unit_update");

            command.Parameters.AddWithValue("@ID_Educational_Unit", ID_Educational_Unit);
            command.Parameters.AddWithValue("@Name_Of_The_EU", Name_Of_The_EU);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void resEducational_Unit_delete(Int32 ID_Educational_Unit)
        {
            commandConfig("Educational_Unit_delete");

            command.Parameters.AddWithValue("@ID_Educational_Unit", ID_Educational_Unit);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void resType_Of_Educational_Unit_insert(string Number_Of_Type)
        {
            commandConfig("Type_Of_Educational_Unit_insert");

            command.Parameters.AddWithValue("@Number_Of_Type", Number_Of_Type);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void resType_Of_Educational_Unit_update(Int32 ID_Type_Of_Educational_Unit, string Number_Of_Type)
        {
            commandConfig("Type_Of_Educational_Unit_update");

            command.Parameters.AddWithValue("@ID_Type_Of_Educational_Unit", ID_Type_Of_Educational_Unit);
            command.Parameters.AddWithValue("@Number_Of_Type", Number_Of_Type);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void resType_Of_Educational_Unit_delete(Int32 ID_Type_Of_Educational_Unit)
        {
            commandConfig("Type_Of_Educational_Unit_delete");

            command.Parameters.AddWithValue("@ID_Type_Of_Educational_Unit", ID_Type_Of_Educational_Unit);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Export_Word()
        {
            String result = (string)Clipboard.GetData(DataFormats.Text);
            string Q;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word Documents (*.doc|*.doc)";
            saveFileDialog.ShowDialog();
            File.WriteAllText(saveFileDialog.FileName, result);
        }



    }

}