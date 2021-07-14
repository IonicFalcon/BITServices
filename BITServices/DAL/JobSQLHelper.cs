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
    class JobSQLHelper : SQLHelper
    {
        public static List<Job> GetAllJobs()
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allJobsCmd = new SqlCommand();
            allJobsCmd.Connection = BITConn;
            allJobsCmd.CommandType = CommandType.StoredProcedure;
            allJobsCmd.CommandText = "uspGetJobsForManagement";

            SqlDataAdapter allJobsAdapt = new SqlDataAdapter(allJobsCmd);
            allJobsCmd.Connection.Close();
            DataTable allJobsDT = new DataTable();
            allJobsAdapt.Fill(allJobsDT);

            List<Job> jobList = new List<Job>();
            foreach (DataRow dr in allJobsDT.Rows)
            {
                Job job = new Job
                {
                    Date = DateTime.Parse(dr["JobDate"].ToString()),
                    StartTime = dr["JobStartTime"].ToString(),
                    JobClient = ClientSQLHelper.GetClientFromID((int)dr["ClientID"]),
                    Street = (string)dr["JobStreet"],
                    Suburb = (string)dr["JobSuburb"],
                    State = (string)dr["JobState"],
                    PostCode = (string)dr["JobPostCode"],
                    Urgency = (string)dr["JobUrgency"],
                    SkillType = (string)dr["SkillName"],
                    JobDetails = (string)dr["JobDetails"],
                    JobStatus = (string)dr["JobStatus"]
                };
                try
                {
                    job.EndDateTime = dr["EndTime"].ToString();
                }
                catch
                {
                    job.EndDateTime = null;
                }
                try
                {
                    job.AssignedContractor = ContractorSQLHelper.GetContractorFromID((int)dr["ContractorID"]);
                }
                catch
                {
                    job.AssignedContractor = null;
                }
                try
                {
                    job.AssignedEmployee = EmployeeSQLHelper.GetEmployeeFromID((int)dr["AssignedEmployee"]);
                }
                catch
                {
                    job.AssignedEmployee = null;
                }
                try
                {
                    job.DistanceTravelled = Convert.ToInt16(dr["DistanceTravelled"].ToString());
                }
                catch
                {
                    job.DistanceTravelled = 0;
                }



                jobList.Add(job);
            }

            return jobList;
        }

        public static int CreateJob(Job newJob, int id)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allJobCmd = new SqlCommand();
            allJobCmd.Connection = BITConn;
            allJobCmd.CommandType = CommandType.Text;

            string sqlQuery = "";
            if(newJob.AssignedContractor != null)
            {
                sqlQuery = "INSERT INTO JOB(JobDate, JobStartTime, ClientID, ContractorID, JobStreet, JobSuburb, JobState, JobPostCode, JobUrgency, AssignedEmployee, SkillName, JobDetails, JobStatus) VALUES(@JobDate, @JobStartTime, @ClientID, @ContractorID, @JobStreet, @JobSuburb, @JobState, @JobPostCode, @JobUrgency, @EmployeeID, @SkillName, @JobDetails, 'Active')";
            }
            else
            {
                sqlQuery = "INSERT INTO JOB(JobDate, JobStartTime, ClientID, JobStreet, JobSuburb, JobState, JobPostCode, JobUrgency, AssignedEmployee, SkillName, JobDetails, JobStatus) VALUES(@JobDate, @JobStartTime, @ClientID, @JobStreet, @JobSuburb, @JobState, @JobPostCode, @JobUrgency, @EmployeeID, @SkillName, @JobDetails, 'Active')";
            }

            allJobCmd.CommandText = sqlQuery;

            try
            {
                allJobCmd.Parameters.AddWithValue("@JobDate", newJob.Date);
                allJobCmd.Parameters.AddWithValue("@JobStartTime", newJob.StartTime);
                allJobCmd.Parameters.AddWithValue("@ClientID", newJob.JobClient.ClientID);
                allJobCmd.Parameters.AddWithValue("@JobStreet", newJob.Street);
                allJobCmd.Parameters.AddWithValue("@JobSuburb", newJob.Suburb);
                allJobCmd.Parameters.AddWithValue("@JobState", newJob.State);
                allJobCmd.Parameters.AddWithValue("@JobPostCode", newJob.PostCode);
                allJobCmd.Parameters.AddWithValue("@JobUrgency", newJob.Urgency);
                allJobCmd.Parameters.AddWithValue("@EmployeeID", id);
                allJobCmd.Parameters.AddWithValue("@SkillName", newJob.SkillType);
                allJobCmd.Parameters.AddWithValue("@JobDetails", newJob.JobDetails);

                if(newJob.AssignedContractor != null)
                {
                    allJobCmd.Parameters.AddWithValue("@ContractorID", newJob.AssignedContractor.ContractorID);
                }

                return allJobCmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                LogHelper.Log(LogTarget.File, ex.Message);
                LogHelper.Log(LogTarget.EventLog, ex.Message);
                return 0;
            }
        }

        public static int EditJob(Job editJob)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand editJobCmd = new SqlCommand();
            editJobCmd.Connection = BITConn;
            editJobCmd.CommandType = CommandType.Text;

            string sqlQuery = "UPDATE Job SET ContractorID = @ID WHERE JobDate = @Date AND JobStartTime = @StartTime AND ClientID = @ClientID";

            editJobCmd.CommandText = sqlQuery;

            try
            {
                editJobCmd.Parameters.AddWithValue("@ID", editJob.AssignedContractor.ContractorID);
                editJobCmd.Parameters.AddWithValue("@Date", editJob.Date);
                editJobCmd.Parameters.AddWithValue("@StartTime", editJob.StartTime);
                editJobCmd.Parameters.AddWithValue("@ClientID", editJob.JobClient.ClientID);

                return editJobCmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                LogHelper.Log(LogTarget.File, ex.Message);
                LogHelper.Log(LogTarget.EventLog, ex.Message);
                return 0;
            }
        }

        public static int DeleteJob(Job job)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand deleteJobCmd = new SqlCommand();
            deleteJobCmd.Connection = BITConn;
            deleteJobCmd.CommandType = CommandType.Text;

            string sqlQuery = "DELETE FROM Job WHERE JobDate = @Date AND JobStartTime = @StartTime AND ClientID = @ClientID";

            deleteJobCmd.CommandText = sqlQuery;

            try
            {
                deleteJobCmd.Parameters.AddWithValue("@Date", job.Date);
                deleteJobCmd.Parameters.AddWithValue("@StartTime", job.StartTime);
                deleteJobCmd.Parameters.AddWithValue("@ClientID", job.JobClient.ClientID);

                return deleteJobCmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                LogHelper.Log(LogTarget.File, ex.Message);
                LogHelper.Log(LogTarget.EventLog, ex.Message);
                return 0;
            }
        }

        public static int VerifyJob(Job job)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand verifyJobCmd = new SqlCommand();
            verifyJobCmd.Connection = BITConn;
            verifyJobCmd.CommandType = CommandType.Text;

            string sqlQuery = "UPDATE Job SET JobStatus = 'Verify' WHERE JobDate = @Date AND JobStartTime = @StartTime AND ClientID = @ClientID";

            verifyJobCmd.CommandText = sqlQuery;

            try
            {
                verifyJobCmd.Parameters.AddWithValue("@Date", job.Date);
                verifyJobCmd.Parameters.AddWithValue("@StartTime", job.StartTime);
                verifyJobCmd.Parameters.AddWithValue("@ClientID", job.JobClient.ClientID);

                return verifyJobCmd.ExecuteNonQuery();
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
