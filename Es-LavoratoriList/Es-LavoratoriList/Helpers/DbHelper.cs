using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_LavoratoriList.Helpers
{
    public static class DbHelper
    {
        private static SqlConnection connection;

        private static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                string connectionString = ConfigurationManager.AppSettings.Get("connectionString");
                connection = new SqlConnection(connectionString);
            }
            return connection;
        }

        public static int DeleteLavoratore(Guid LavId)
        {
            int result = 0;

            string deleteQuery = "DELETE from Lavoratori " +
                " WHERE ID = @Lavoratore_ID";

            SqlCommand cmd = new SqlCommand
            {
                Connection = GetConnection(),
                CommandType = CommandType.Text,
                CommandText = deleteQuery
            };

            cmd.Parameters.AddWithValue("@Lavoratore_ID", LavId);

            cmd.Connection.Open();
            result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return result;
        }

        public static void SvuotaTabella(string tabella)
        {
            string deleteQuery = string.Format("DELETE from {0} ", tabella);

            SqlCommand cmd = new SqlCommand
            {
                Connection = GetConnection(),
                CommandType = CommandType.Text,
                CommandText = deleteQuery
            };


            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public static int UpdateLavoratore(Lavoratore l)
        {
            int result = 0;
            string updateQuery = "UPDATE Lavoratori SET " +
                "Nome = @Nome, " +
                "Cognome = @Cognome, " +
                "Età = @Età, " +
                "Ral = @Ral, " +
                "DataDiAssunzione = @DataDiAssunzione," +
                "Tipo = @Tipo" +
                " WHERE ID = @Lavoratore_ID";
            SqlCommand cmd = new SqlCommand
            {
                Connection = GetConnection(),
                CommandType = CommandType.Text,
                CommandText = updateQuery
            };

            cmd.Parameters.AddWithValue("@Lavoratore_ID", l.Lavoratore_ID);
            cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 50).Value = l.Nome;
            cmd.Parameters.Add("@Cognome", SqlDbType.NVarChar, 50).Value = l.Cognome;
            cmd.Parameters.Add("@Età", SqlDbType.Int).Value = l.Età;
            cmd.Parameters.Add("@Ral", SqlDbType.Int).Value = l.Ral;
            cmd.Parameters.Add("@DataDiAssunzione", SqlDbType.DateTime).Value = l.DataDiAssunzione;
            cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = l.Tipo;

            //apro la connessione al database (implica la chiusura)
            connection.Open();
            result = cmd.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine("{0} rows affected!", result);

            return result;
        }

        public static void InsertLavoratore(Lavoratore l)
        {
            SqlCommand cmd = new SqlCommand//creo un comando
            {

                Connection = GetConnection(),

                CommandType = CommandType.Text,//il comando andrà ad inserire la query

                CommandText = "INSERT INTO Lavoratori" +
                    "(ID, Nome, Cognome, Età, Ral, DataDiAssunzione, Tipo) " +
                    "VALUES" +
                    "(@ID, @Nome, @Cognome, @Età, @Ral, @DataDiAssunzione, @Tipo)"
            };

            cmd.Parameters.AddWithValue("@ID", l.Lavoratore_ID);
            cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 50).Value = l.Nome;
            cmd.Parameters.Add("@Cognome", SqlDbType.NVarChar, 50).Value = l.Cognome;
            cmd.Parameters.Add("@Età", SqlDbType.Int).Value = l.Età;
            cmd.Parameters.Add("@Ral", SqlDbType.Int).Value = l.Ral;
            cmd.Parameters.Add("@DataDiAssunzione", SqlDbType.DateTime).Value = l.DataDiAssunzione;
            cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = l.Tipo;

            //apro la connessione al database (implica la chiusura)
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine("{0} rows affected!", result);

        }

        public static DataSet GetLavoratore()
        {
            DataSet result = new DataSet();

            string selectQuery = "SELECT ID, Nome, Cognome, Età, Ral, " +
                "DataDiAssunzione, Tipo FROM Lavoratori";

            SqlCommand cmd = new SqlCommand(selectQuery, GetConnection());

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(result);

            return result;
        }
    }
}
