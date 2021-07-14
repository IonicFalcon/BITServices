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
    class EmployeeSQLHelper : SQLHelper
    {
        public static List<Employee> GetAllEmployees()
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allEmployeeCmd = new SqlCommand();
            allEmployeeCmd.Connection = BITConn;
            allEmployeeCmd.CommandType = CommandType.StoredProcedure;
            allEmployeeCmd.CommandText = "uspGetAllEmployees";

            SqlDataAdapter allEmployeesAdapt = new SqlDataAdapter(allEmployeeCmd);
            allEmployeeCmd.Connection.Close();
            DataTable allEmployeeDT = new DataTable();
            allEmployeesAdapt.Fill(allEmployeeDT);

            List<Employee> employeeList = new List<Employee>();
            foreach (DataRow dr in allEmployeeDT.Rows)
            {
                Employee employee = new Employee
                {
                    EmployeeID = (int)dr["EmployeeID"],
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
                    EmployeeType = (string)dr["TypeName"],
                };
                try
                {
                    employee.ProfilePicData = (byte[])dr["EmployeeImage"];
                }
                catch
                {
                    employee.ProfilePicData = null;
                }

                employeeList.Add(employee);
            }

            return employeeList;
        }

        public static Employee GetEmployeeFromID(int id)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allEmployeeCmd = new SqlCommand();
            allEmployeeCmd.Connection = BITConn;
            allEmployeeCmd.CommandType = CommandType.StoredProcedure;
            allEmployeeCmd.CommandText = "uspGetEmployeeFromID";
            allEmployeeCmd.Parameters.Add(new SqlParameter("@ID", id));

            SqlDataAdapter allEmployeesAdapt = new SqlDataAdapter(allEmployeeCmd);
            allEmployeeCmd.Connection.Close();
            DataTable allEmployeeDT = new DataTable();
            allEmployeesAdapt.Fill(allEmployeeDT);

            Employee employee;

            foreach (DataRow dr in allEmployeeDT.Rows)
            {
                employee = new Employee()
                {
                    EmployeeID = (int)dr["EmployeeID"],
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
                    EmployeeType = (string)dr["TypeName"],
                };

                try
                {
                    employee.ProfilePicData = (byte[])dr["EmployeeImage"];
                }
                catch
                {
                    employee.ProfilePicData = null;
                }

                return employee;
            }

            return null;
        }

        public static Employee GetEmployeeFromUsername(string userName)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allEmployeeCmd = new SqlCommand();
            allEmployeeCmd.Connection = BITConn;
            allEmployeeCmd.CommandType = CommandType.StoredProcedure;
            allEmployeeCmd.CommandText = "uspGetEmployeeFromUsername";
            allEmployeeCmd.Parameters.Add(new SqlParameter("@Username", userName));

            SqlDataAdapter allEmployeesAdapt = new SqlDataAdapter(allEmployeeCmd);
            allEmployeeCmd.Connection.Close();
            DataTable allEmployeeDT = new DataTable();
            allEmployeesAdapt.Fill(allEmployeeDT);

            Employee employee;

            foreach (DataRow dr in allEmployeeDT.Rows)
            {
                employee = new Employee()
                {
                    EmployeeID = (int)dr["EmployeeID"],
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
                    EmployeeType = (string)dr["TypeName"],
                };

                try
                {
                    employee.ProfilePicData = (byte[])dr["EmployeeImage"];
                }
                catch
                {
                    employee.ProfilePicData = null;
                }

                return employee;
            }

            return null;
        }
    }

    class CoordinatorSQLHelper : SQLHelper
    {
        public static List<Employee> GetAllCoordinators()
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allCoordinatorCmd = new SqlCommand();
            allCoordinatorCmd.Connection = BITConn;
            allCoordinatorCmd.CommandType = CommandType.StoredProcedure;
            allCoordinatorCmd.CommandText = "uspGetAllCoordinators";

            SqlDataAdapter allCoordinatorAdapt = new SqlDataAdapter(allCoordinatorCmd);
            allCoordinatorCmd.Connection.Close();
            DataTable allCoordinatorDT = new DataTable();
            allCoordinatorAdapt.Fill(allCoordinatorDT);

            List<Employee> employeeList = new List<Employee>();
            foreach (DataRow dr in allCoordinatorDT.Rows)
            {
                Employee employee = new Employee
                {
                    EmployeeID = (int)dr["EmployeeID"],
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
                    EmployeeType = (string)dr["TypeName"],
                };
                try
                {
                    employee.ProfilePicData = (byte[])dr["EmployeeImage"];
                }
                catch
                {
                    employee.ProfilePicData = null;
                }

                employeeList.Add(employee);
            }

            return employeeList;
        }

        public static int InsertCoordinator(Employee newCoordinator)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand addCoordinatorCmd = new SqlCommand();
            addCoordinatorCmd.Connection = BITConn;
            addCoordinatorCmd.CommandType = CommandType.Text;

            string sqlQuery = "INSERT INTO Employee(FirstName, LastName, Street, Suburb, State, PostCode, PhoneNumber, MobilePhoneNumber, Email, Username, PasswordHash, PasswordSalt, TypeName, EmployeeImage) VALUES(@FirstName, @LastName, @Street, @Suburb, @State, @PostCode, @PhoneNumber, @MobilePhoneNumber, @Email, @Username, @PasswordHash, @PasswordSalt, @TypeName, @EmployeeImage)";

            addCoordinatorCmd.CommandText = sqlQuery;

            try
            {
                addCoordinatorCmd.Parameters.Add(new SqlParameter("@FirstName", newCoordinator.FirstName));
                addCoordinatorCmd.Parameters.Add(new SqlParameter("@LastName", newCoordinator.LastName));
                addCoordinatorCmd.Parameters.Add(new SqlParameter("@Street", newCoordinator.Street));
                addCoordinatorCmd.Parameters.Add(new SqlParameter("@Suburb", newCoordinator.Suburb));
                addCoordinatorCmd.Parameters.Add(new SqlParameter("@State", newCoordinator.State));
                addCoordinatorCmd.Parameters.Add(new SqlParameter("@PostCode", newCoordinator.PostCode));
                addCoordinatorCmd.Parameters.Add(new SqlParameter("@PhoneNumber", newCoordinator.PhoneNumber));
                addCoordinatorCmd.Parameters.Add(new SqlParameter("@MobilePhoneNumber", newCoordinator.MobileNumber));
                addCoordinatorCmd.Parameters.Add(new SqlParameter("@Email", newCoordinator.Email));
                addCoordinatorCmd.Parameters.Add(new SqlParameter("@Username", newCoordinator.Username));
                addCoordinatorCmd.Parameters.Add(new SqlParameter("@PasswordHash", newCoordinator.PasswordHash));
                addCoordinatorCmd.Parameters.Add(new SqlParameter("@PasswordSalt", newCoordinator.PasswordSalt));
                addCoordinatorCmd.Parameters.Add(new SqlParameter("@TypeName", newCoordinator.EmployeeType));
                SqlParameter param = addCoordinatorCmd.Parameters.Add("@EmployeeImage", SqlDbType.VarBinary);
                param.Value = (object)newCoordinator.ProfilePicData ?? DBNull.Value;

                return addCoordinatorCmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                LogHelper.Log(LogTarget.File, ex.Message);
                LogHelper.Log(LogTarget.EventLog, ex.Message);
                return 0; //Signifies that no changes have been made, as an error occurred
            }
        }

        public static int UpdateCoordinator(Employee editedCoordinator)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand editCoordinatorCmd = new SqlCommand();
            editCoordinatorCmd.Connection = BITConn;
            editCoordinatorCmd.CommandType = CommandType.Text;

            string sqlQuery = "UPDATE Employee SET FirstName = @FirstName, LastName = @LastName, Street = @Street, Suburb = @Suburb, State = @State, PostCode = @PostCode, PhoneNumber = @PhoneNumber, MobilePhoneNumber = @MobilePhoneNumber, Email = @Email, Username = @Username, EmployeeImage = @EmployeeImage WHERE EmployeeID = @EmployeeID";

            editCoordinatorCmd.CommandText = sqlQuery;

            try
            {
                editCoordinatorCmd.Parameters.Add(new SqlParameter("@FirstName", editedCoordinator.FirstName));
                editCoordinatorCmd.Parameters.Add(new SqlParameter("@LastName", editedCoordinator.LastName));
                editCoordinatorCmd.Parameters.Add(new SqlParameter("@Street", editedCoordinator.Street));
                editCoordinatorCmd.Parameters.Add(new SqlParameter("@Suburb", editedCoordinator.Suburb));
                editCoordinatorCmd.Parameters.Add(new SqlParameter("@State", editedCoordinator.State));
                editCoordinatorCmd.Parameters.Add(new SqlParameter("@PostCode", editedCoordinator.PostCode));
                editCoordinatorCmd.Parameters.Add(new SqlParameter("@PhoneNumber", editedCoordinator.PhoneNumber));
                editCoordinatorCmd.Parameters.Add(new SqlParameter("@MobilePhoneNumber", editedCoordinator.MobileNumber));
                editCoordinatorCmd.Parameters.Add(new SqlParameter("@Email", editedCoordinator.Email));
                editCoordinatorCmd.Parameters.Add(new SqlParameter("@Username", editedCoordinator.Username));
                SqlParameter param = editCoordinatorCmd.Parameters.Add("@EmployeeImage", SqlDbType.VarBinary);
                param.Value = (object)editedCoordinator.ProfilePicData ?? DBNull.Value;
                editCoordinatorCmd.Parameters.Add(new SqlParameter("@EmployeeID", editedCoordinator.EmployeeID));

                return editCoordinatorCmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                LogHelper.Log(LogTarget.File, ex.Message);
                LogHelper.Log(LogTarget.EventLog, ex.Message);
                return 0;
            }
        }

        public static int DeleteCoordinator(Employee employee)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand deleteCoordinatorCmd = new SqlCommand();
            deleteCoordinatorCmd.Connection = BITConn;
            deleteCoordinatorCmd.CommandType = CommandType.Text;

            string sqlQuery = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";

            deleteCoordinatorCmd.CommandText = sqlQuery;

            try
            {
                deleteCoordinatorCmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);

                return deleteCoordinatorCmd.ExecuteNonQuery();
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
