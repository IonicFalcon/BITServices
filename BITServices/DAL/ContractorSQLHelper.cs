using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BITServices.Models;
using System.Collections.ObjectModel;
using BITServices.Control;

namespace BITServices.DAL
{
    class ContractorSQLHelper : SQLHelper
    {
        public static List<Contractor> GetAllContractors()
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allContractorCmd = new SqlCommand();
            allContractorCmd.Connection = BITConn;
            allContractorCmd.CommandType = CommandType.StoredProcedure;
            allContractorCmd.CommandText = "uspGetAllContractors";

            SqlDataAdapter allContractorAdapt = new SqlDataAdapter(allContractorCmd);
            allContractorCmd.Connection.Close();
            DataTable allContractorDT = new DataTable();
            allContractorAdapt.Fill(allContractorDT);

            List<Contractor> contractorList = new List<Contractor>();
            foreach (DataRow dr in allContractorDT.Rows)
            {
                Contractor contractor = new Contractor
                {
                    ContractorID = (int)dr["Contractor_ID"],
                    FirstName = (string)dr["FirstName"],
                    LastName = (string)dr["LastName"],
                    Street = (string)dr["Street"],
                    Suburb = (string)dr["Suburb"],
                    State = (string)dr["State"],
                    PostCode = (string)dr["PostCode"],
                    PhoneNumber = (string)dr["PhoneNumber"],
                    MobileNumber = (string)dr["MobilePhoneNumber"],
                    Email = (string)dr["Email"],
                    Username = (string)dr["Username"],
                    PasswordHash = (string)dr["PasswordHash"],
                    PasswordSalt = (string)dr["PasswordSalt"],
                    Rating = Convert.ToInt32(dr["Rating"])
                };

                try
                {
                    contractor.ProfilePicData = (byte[])dr["ContractorImage"];
                }
                catch
                {
                    contractor.ProfilePicData = null;
                }

                contractor.SkillList = GetSkillsForContractor(contractor.ContractorID);
                contractor.Roster = GetRosterForContractor(contractor.ContractorID);

                contractorList.Add(contractor);
            }

            return contractorList;
        }

        public static Contractor GetContractorFromID(int id)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand contractorIDCmd = new SqlCommand();
            contractorIDCmd.Connection = BITConn;
            contractorIDCmd.CommandType = CommandType.StoredProcedure;
            contractorIDCmd.CommandText = "uspGetContractorFromID";
            contractorIDCmd.Parameters.AddWithValue("@ID", id);

            SqlDataAdapter contractorIDAdapt = new SqlDataAdapter(contractorIDCmd);
            contractorIDCmd.Connection.Close();
            DataTable dt = new DataTable();
            contractorIDAdapt.Fill(dt);

            Contractor contractor;

            foreach(DataRow dr in dt.Rows)
            {
                contractor = new Contractor
                {
                    ContractorID = (int)dr["Contractor_ID"],
                    FirstName = (string)dr["FirstName"],
                    LastName = (string)dr["LastName"],
                    Street = (string)dr["Street"],
                    Suburb = (string)dr["Suburb"],
                    State = (string)dr["State"],
                    PostCode = (string)dr["PostCode"],
                    PhoneNumber = (string)dr["PhoneNumber"],
                    MobileNumber = (string)dr["MobilePhoneNumber"],
                    Email = (string)dr["Email"],
                    Username = (string)dr["Username"],
                    PasswordHash = (string)dr["PasswordHash"],
                    PasswordSalt = (string)dr["PasswordSalt"],
                    Rating = Convert.ToInt32(dr["Rating"])
                };
                try
                {
                    contractor.ProfilePicData = (byte[])dr["ContractorImage"];
                }
                catch
                {
                    contractor.ProfilePicData = null;
                }

                contractor.SkillList = GetSkillsForContractor(contractor.ContractorID);
                contractor.Roster = GetRosterForContractor(contractor.ContractorID);

                return contractor;
            }
            return null;
        }
        public static int InsertContractor(Contractor newContractor)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand addContractorCmd = new SqlCommand();
            addContractorCmd.Connection = BITConn;
            addContractorCmd.CommandType = CommandType.Text;

            string sqlQuery = "INSERT INTO Contractor(FirstName, LastName, Street, Suburb, State, PostCode, PhoneNumber, MobilePhoneNumber, Email, Username, PasswordHash, PasswordSalt, ContractorImage) VALUES(@FirstName, @LastName, @Street, @Suburb, @State, @PostCode, @PhoneNumber, @MobilePhoneNumber, @Email, @Username, @PasswordHash, @PasswordSalt, @ContractorImage); SELECT @@IDENTITY";

            addContractorCmd.CommandText = sqlQuery;

            try
            {
                addContractorCmd.Parameters.AddWithValue("@FirstName", newContractor.FirstName);
                addContractorCmd.Parameters.AddWithValue("@LastName", newContractor.LastName);
                addContractorCmd.Parameters.AddWithValue("@Street", newContractor.Street);
                addContractorCmd.Parameters.AddWithValue("@Suburb", newContractor.Suburb);
                addContractorCmd.Parameters.AddWithValue("@State", newContractor.State);
                addContractorCmd.Parameters.AddWithValue("@PostCode", newContractor.PostCode);
                addContractorCmd.Parameters.AddWithValue("@PhoneNumber", newContractor.PhoneNumber);
                addContractorCmd.Parameters.AddWithValue("@MobilePhoneNumber", newContractor.MobileNumber);
                addContractorCmd.Parameters.AddWithValue("@Email", newContractor.Email);
                addContractorCmd.Parameters.AddWithValue("@Username", newContractor.Username);
                addContractorCmd.Parameters.AddWithValue("@PasswordHash", newContractor.PasswordHash);
                addContractorCmd.Parameters.AddWithValue("@PasswordSalt", newContractor.PasswordSalt);
                SqlParameter param = addContractorCmd.Parameters.Add("@ContractorImage", SqlDbType.VarBinary);
                param.Value = (object)newContractor.ProfilePicData ?? DBNull.Value;

                int contractorID = int.Parse(addContractorCmd.ExecuteScalar().ToString());

                if (newContractor.SkillList.Count > 0)
                {
                    foreach (string skill in newContractor.SkillList)
                    {
                        InsertContractorSkills(skill, contractorID);
                    }
                }

                if (newContractor.Roster.Rows.Count > 0) {
                    foreach (DataRow dr in newContractor.Roster.Rows)
                    {
                        InsertContractorRoster(dr.ItemArray, contractorID);
                    }
                }

                return 1;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ex.Message);
                LogHelper.Log(LogTarget.EventLog, ex.Message);
                return 0;
            }
        }

        public static int UpdateContractor(Contractor editedContractor)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand editContractorCmd = new SqlCommand();
            editContractorCmd.Connection = BITConn;
            editContractorCmd.CommandType = CommandType.Text;

            string sqlQuery = "UPDATE Contractor SET FirstName = @FirstName, LastName = @LastName, Street = @Street, Suburb = @Suburb, State = @State, PostCode = @PostCode, PhoneNumber = @PhoneNumber, MobilePhoneNumber = @MobilePhoneNumber, Email = @Email, Username = @Username, ContractorImage = @ContractorImage WHERE Contractor_ID = @ContractorID";

            editContractorCmd.CommandText = sqlQuery;

            try
            {
                editContractorCmd.Parameters.AddWithValue("@FirstName", editedContractor.FirstName);
                editContractorCmd.Parameters.AddWithValue("@LastName", editedContractor.LastName);
                editContractorCmd.Parameters.AddWithValue("@Street", editedContractor.Street);
                editContractorCmd.Parameters.AddWithValue("@Suburb", editedContractor.Suburb);
                editContractorCmd.Parameters.AddWithValue("@State", editedContractor.State);
                editContractorCmd.Parameters.AddWithValue("@PostCode", editedContractor.PostCode);
                editContractorCmd.Parameters.AddWithValue("@PhoneNumber", editedContractor.PhoneNumber);
                editContractorCmd.Parameters.AddWithValue("@MobilePhoneNumber", editedContractor.MobileNumber);
                editContractorCmd.Parameters.AddWithValue("@Email", editedContractor.Email);
                editContractorCmd.Parameters.AddWithValue("@Username", editedContractor.Username);
                SqlParameter param = editContractorCmd.Parameters.Add("@ContractorImage", SqlDbType.VarBinary);
                param.Value = (object)editedContractor.ProfilePicData ?? DBNull.Value;
                editContractorCmd.Parameters.AddWithValue("@ContractorID", editedContractor.ContractorID);

                ClearContractorSkills(editedContractor.ContractorID);
                foreach (string skill in editedContractor.SkillList)
                {
                    InsertContractorSkills(skill, editedContractor.ContractorID);
                }

                ClearContractorRoster(editedContractor.ContractorID);
                foreach(DataRow dr in editedContractor.Roster.Rows)
                {
                    InsertContractorRoster(dr.ItemArray, editedContractor.ContractorID);
                }

                return editContractorCmd.ExecuteNonQuery();
                
            }
            catch(Exception ex)
            {
                LogHelper.Log(LogTarget.File, ex.Message);
                LogHelper.Log(LogTarget.EventLog, ex.Message);
                return 0;
            }
        }

        public static int DeleteContractor(Contractor contractor)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand deleteContractorCmd = new SqlCommand();
            deleteContractorCmd.Connection = BITConn;
            deleteContractorCmd.CommandType = CommandType.Text;

            string sqlQuery = "DELETE FROM Contractor WHERE Contractor_ID = @ContractorID";

            deleteContractorCmd.CommandText = sqlQuery;

            try
            {
                deleteContractorCmd.Parameters.AddWithValue("@ContractorID", contractor.ContractorID);

                ClearContractorSkills(contractor.ContractorID);
                ClearContractorRoster(contractor.ContractorID);

                return deleteContractorCmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                LogHelper.Log(LogTarget.File, ex.Message);
                LogHelper.Log(LogTarget.EventLog, ex.Message);
                return 0;
            }
        }

        private static ObservableCollection<string> GetSkillsForContractor(int id)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand contractorSkillsCmd = new SqlCommand();
            contractorSkillsCmd.Connection = BITConn;
            contractorSkillsCmd.CommandType = CommandType.StoredProcedure;
            contractorSkillsCmd.CommandText = "uspGetSkillsForContractor";
            contractorSkillsCmd.Parameters.AddWithValue("@ContractorID", id);

            SqlDataAdapter contractorSkillsAdapt = new SqlDataAdapter(contractorSkillsCmd);
            contractorSkillsCmd.Connection.Close();
            DataTable contractorSkillDT = new DataTable();
            contractorSkillsAdapt.Fill(contractorSkillDT);

            ObservableCollection<string> contractorSkills = new ObservableCollection<string>();
            foreach(DataRow dr in contractorSkillDT.Rows)
            {
                contractorSkills.Add((string)dr["SkillName"]);
            }

            return contractorSkills;
        }

        private static DataTable GetRosterForContractor(int id)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand contractorRosterCmd = new SqlCommand();
            contractorRosterCmd.Connection = BITConn;
            contractorRosterCmd.CommandType = CommandType.StoredProcedure;
            contractorRosterCmd.CommandText = "uspGetRosterForContractor";
            contractorRosterCmd.Parameters.AddWithValue("@ContractorID", id);

            SqlDataAdapter contractorRosterAdapt = new SqlDataAdapter(contractorRosterCmd);
            contractorRosterCmd.Connection.Close();
            DataTable contractorRosterDT = new DataTable();
            contractorRosterAdapt.Fill(contractorRosterDT);

            return contractorRosterDT;
        }

        private static void ClearContractorSkills(int id)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand clearContractorSkillCommand = new SqlCommand();
            clearContractorSkillCommand.Connection = BITConn;
            clearContractorSkillCommand.CommandType = CommandType.Text;

            string sqlQuery = "DELETE FROM ContractorSkill WHERE Contractor_ID = @ContractorID";

            clearContractorSkillCommand.CommandText = sqlQuery;

            clearContractorSkillCommand.Parameters.AddWithValue("@ContractorID", id);
            clearContractorSkillCommand.ExecuteNonQuery();
        }

        private static void ClearContractorRoster(int id)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand clearContractorRosterCommand = new SqlCommand();
            clearContractorRosterCommand.Connection = BITConn;
            clearContractorRosterCommand.CommandType = CommandType.Text;

            string sqlQuery = "DELETE FROM Availiability WHERE Contractor_ID = @ContractorID";

            clearContractorRosterCommand.CommandText = sqlQuery;

            clearContractorRosterCommand.Parameters.AddWithValue("ContractorID", id);
            clearContractorRosterCommand.ExecuteNonQuery();
        }

        private static int InsertContractorSkills(string skill, int id)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand addContractorSkillsCmd = new SqlCommand();
            addContractorSkillsCmd.Connection = BITConn;
            addContractorSkillsCmd.CommandType = CommandType.Text;

            string sqlQuery = "INSERT INTO ContractorSkill(SkillName, Contractor_ID) VALUES (@SkillName, @ContractorID)";

            addContractorSkillsCmd.CommandText = sqlQuery;

            try
            {
                addContractorSkillsCmd.Parameters.AddWithValue("@SkillName", skill);
                addContractorSkillsCmd.Parameters.AddWithValue("@ContractorID", id);

                return addContractorSkillsCmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                LogHelper.Log(LogTarget.File, ex.Message);
                LogHelper.Log(LogTarget.EventLog, ex.Message);
                return 0;
            }
        }

        private static int InsertContractorRoster(object[] itemArray, int id)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand addContractorRosterCmd = new SqlCommand();
            addContractorRosterCmd.Connection = BITConn;
            addContractorRosterCmd.CommandType = CommandType.Text;

            string sqlQuery = "INSERT INTO Availiability(Contractor_ID, DayOfWeek, StartTime, EndTime) VALUES (@ContractorID, @DayOfWeek, @StartTime, @EndTime)";

            addContractorRosterCmd.CommandText = sqlQuery;

            try
            {
                addContractorRosterCmd.Parameters.AddWithValue("@ContractorID", id);
                addContractorRosterCmd.Parameters.AddWithValue("@DayOfWeek", itemArray[0]);
                addContractorRosterCmd.Parameters.AddWithValue("@StartTime", itemArray[1]);
                addContractorRosterCmd.Parameters.AddWithValue("@EndTime", itemArray[2]);

                return addContractorRosterCmd.ExecuteNonQuery();
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
