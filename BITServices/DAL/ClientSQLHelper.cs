using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using BITServices.Models;
using BITServices.Control;

namespace BITServices.DAL
{
    class ClientSQLHelper : SQLHelper
    {
        public static List<Client> GetAllClients()
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allClientCmd = new SqlCommand();
            allClientCmd.Connection = BITConn;
            allClientCmd.CommandType = CommandType.StoredProcedure;
            allClientCmd.CommandText = "uspGetAllClients";

            SqlDataAdapter allClientsAdapt = new SqlDataAdapter(allClientCmd);
            allClientCmd.Connection.Close();
            DataTable allClientDT = new DataTable();
            allClientsAdapt.Fill(allClientDT);

            List<Client> clientList = new List<Client>();
            foreach(DataRow dr in allClientDT.Rows)
            {
                Client client = new Client
                {
                    ClientID = (int)dr["ClientID"],
                    Name = (string)dr["Name"],
                    Street = (string)dr["Street"],
                    Suburb = (string)dr["Suburb"],
                    State = (string)dr["State"],
                    PostCode = (string)dr["PostCode"],
                    PhoneNumber = (string)dr["PhoneNumber"],
                    MobileNumber = (string)dr["MobilePhoneNumber"],
                    Email = (string)dr["Email"],
                    Username = (string)dr["Username"],
                    PasswordHash = (string)dr["PasswordHash"],
                    PasswordSalt = (string)dr["PasswordSalt"]
                };
                try
                {
                    client.ProfilePicData = (byte[])dr["ClientImage"];
                }
                catch
                {
                    client.ProfilePicData = null;
                }

                clientList.Add(client);
            }

            return clientList;
        }

        public static Client GetClientFromID(int id)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand clientIDCmd = new SqlCommand();
            clientIDCmd.Connection = BITConn;
            clientIDCmd.CommandType = CommandType.StoredProcedure;
            clientIDCmd.CommandText = "uspGetClientFromID";
            clientIDCmd.Parameters.AddWithValue("@ID", id);

            SqlDataAdapter clientIDAdapt = new SqlDataAdapter(clientIDCmd);
            clientIDCmd.Connection.Close();
            DataTable clientIDDT = new DataTable();
            clientIDAdapt.Fill(clientIDDT);

            Client client;

            foreach (DataRow dr in clientIDDT.Rows)
            {
                client = new Client
                {
                    ClientID = (int)dr["ClientID"],
                    Name = (string)dr["Name"],
                    Street = (string)dr["Street"],
                    Suburb = (string)dr["Suburb"],
                    State = (string)dr["State"],
                    PostCode = (string)dr["PostCode"],
                    PhoneNumber = (string)dr["PhoneNumber"],
                    MobileNumber = (string)dr["MobilePhoneNumber"],
                    Email = (string)dr["Email"],
                    Username = (string)dr["Username"],
                    PasswordHash = (string)dr["PasswordHash"],
                    PasswordSalt = (string)dr["PasswordSalt"]
                };
                try
                {
                    client.ProfilePicData = (byte[])dr["ClientImage"];
                }
                catch
                {
                    client.ProfilePicData = null;
                }

                return client;
            }

            return null;
        }

        public static int InsertClient(Client newClient)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand addClientCmd = new SqlCommand();
            addClientCmd.Connection = BITConn;
            addClientCmd.CommandType = CommandType.Text;

            string sqlQuery = "INSERT INTO Client(Name, Street, Suburb, State, PostCode, PhoneNumber, MobilePhoneNumber, Email, Username, PasswordHash, PasswordSalt, ClientImage) VALUES (@Name, @Street, @Suburb, @State, @PostCode, @PhoneNumber, @MobilePhoneNumber, @Email, @Username, @PasswordHash, @PasswordSalt, @ClientImage)";

            addClientCmd.CommandText = sqlQuery;

            try
            {
                addClientCmd.Parameters.AddWithValue("@Name", newClient.Name); addClientCmd.Parameters.AddWithValue("@Street", newClient.Street);
                addClientCmd.Parameters.AddWithValue("@Suburb", newClient.Suburb);
                addClientCmd.Parameters.AddWithValue("@State", newClient.State); addClientCmd.Parameters.AddWithValue("@PostCode", newClient.PostCode); addClientCmd.Parameters.AddWithValue("@PhoneNumber", newClient.PhoneNumber);
                addClientCmd.Parameters.AddWithValue("@MobilePhoneNumber", newClient.MobileNumber); 
                addClientCmd.Parameters.AddWithValue("@Email", newClient.Email); addClientCmd.Parameters.AddWithValue("@Username", newClient.Username); addClientCmd.Parameters.AddWithValue("@PasswordHash", newClient.PasswordHash);
                  addClientCmd.Parameters.AddWithValue("@PasswordSalt", newClient.PasswordSalt);
                SqlParameter param = addClientCmd.Parameters.Add("@ClientImage", SqlDbType.VarBinary);
                param.Value = (object)newClient.ProfilePicData ?? DBNull.Value;

                return addClientCmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                LogHelper.Log(LogTarget.File, ex.Message);
                LogHelper.Log(LogTarget.EventLog, ex.Message);
                return 0;
            }
        }

        public static int UpdateClient(Client editedClient)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand editClientCmd = new SqlCommand();
            editClientCmd.Connection = BITConn;
            editClientCmd.CommandType = CommandType.Text;

            string sqlQuery = "UPDATE Client SET Name = @Name, Street = @Street, Suburb = @Suburb, State = @State, PostCode = @PostCode, PhoneNumber = @PhoneNumber, MobilePhoneNumber = @MobilePhoneNumber, Email = @Email, Username = @Username, ClientImage = @ClientImage WHERE ClientID = @ClientID";

            editClientCmd.CommandText = sqlQuery;

            try
            {
                editClientCmd.Parameters.AddWithValue("@Name", editedClient.Name);
                editClientCmd.Parameters.AddWithValue("@Street", editedClient.Street);
                editClientCmd.Parameters.AddWithValue("@Suburb", editedClient.Suburb);
                editClientCmd.Parameters.AddWithValue("@State", editedClient.State);
                editClientCmd.Parameters.AddWithValue("@PostCode", editedClient.PostCode);
                editClientCmd.Parameters.AddWithValue("@PhoneNumber", editedClient.PhoneNumber);
                editClientCmd.Parameters.AddWithValue("@MobilePhoneNumber", editedClient.MobileNumber);
                editClientCmd.Parameters.AddWithValue("@Email", editedClient.Email);
                editClientCmd.Parameters.AddWithValue("@Username", editedClient.Username);
                SqlParameter param = editClientCmd.Parameters.Add("@ClientImage", SqlDbType.VarBinary);
                param.Value = (object)editedClient.ProfilePicData ?? DBNull.Value;
                editClientCmd.Parameters.AddWithValue("@ClientID", editedClient.ClientID);

                return editClientCmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                LogHelper.Log(LogTarget.File, ex.Message);
                LogHelper.Log(LogTarget.EventLog, ex.Message);
                return 0;
            }
        }

        public static int DeleteClient(Client client)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand deleteClientCmd = new SqlCommand();
            deleteClientCmd.Connection = BITConn;
            deleteClientCmd.CommandType = CommandType.Text;

            string sqlQuery = "DELETE FROM Client WHERE ClientID = @ClientID";

            deleteClientCmd.CommandText = sqlQuery;

            try
            {
                deleteClientCmd.Parameters.AddWithValue("@ClientID", client.ClientID);

                return deleteClientCmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                LogHelper.Log(LogTarget.File, ex.Message);
                LogHelper.Log(LogTarget.EventLog, ex.Message);
                return 0;
            }
        }
    }
}
