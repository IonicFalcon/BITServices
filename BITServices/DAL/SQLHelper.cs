using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Data;

namespace BITServices.DAL
{
    abstract class SQLHelper
    {
        protected static SqlConnection BITConn;

        protected static void ConnectDB()
        {
            BITConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BITServices.Properties.Settings.BITServices"].ConnectionString);
        }

        public static List<string> GetAllSkills()
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allSkillCmd = new SqlCommand();
            allSkillCmd.Connection = BITConn;
            allSkillCmd.CommandType = CommandType.StoredProcedure;
            allSkillCmd.CommandText = "uspGetAllSkills";

            SqlDataAdapter allSkillAdapt = new SqlDataAdapter(allSkillCmd);
            allSkillCmd.Connection.Close();
            DataTable allSkillDT = new DataTable();
            allSkillAdapt.Fill(allSkillDT);

            List<string> skillList = new List<string>();

            foreach (DataRow dataRow in allSkillDT.Rows)
            {
                skillList.Add((string)dataRow["SkillName"]);
            }

            return skillList;
        }
    }
}
