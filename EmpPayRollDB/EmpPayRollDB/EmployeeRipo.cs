using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpPayRollDB
{
    public class EmployeeRipo
    {
        public SqlConnection con;
        public void connection()
        {
            string connectingString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmpPayRoll;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            con = new SqlConnection(connectingString);
        }
        public string AddEmp(EmpModel obj)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("spAddNewEmpPersons", con);
                com.CommandType = CommandType.StoredProcedure;
               
                com.Parameters.AddWithValue("@Name", obj.Name);
                com.Parameters.AddWithValue("@Salary", obj.Salary);
                com.Parameters.AddWithValue("@StartDate", obj.StartDate);
                com.Parameters.AddWithValue("@Gender", obj.Gender);
                com.Parameters.AddWithValue("@ContactNumber", obj.ContactNumber);
                com.Parameters.AddWithValue("@Address", obj.Address);
                com.Parameters.AddWithValue("@Pay", obj.Pay);
                com.Parameters.AddWithValue("@Deduction", obj.Deduction);
                com.Parameters.AddWithValue("@Texable", obj.Texable);

                com.Parameters.AddWithValue("@IncomeTax", obj.IncomeTax);
                com.Parameters.AddWithValue("@NetPay", obj.NetPay);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return "data Added";
                }
                else
                {
                    return "data not added";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.con.Close();
            }
        }
       public List<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            SqlCommand command = new SqlCommand("spViewEmployeeData", connection);
            command.CommandType = CommandType.StoredProcedure;
           
            connection.Open();
            SqlDataReader row = command.ExecuteReader();
            

            EmployeeModel model = new EmployeeModel();
            if (row.HasRows)
            {
                while (row.Read())
                {

                    model.EmployeeId = row.GetInt32(0);
                    model.EmployeeName = row.GetString(1);
                    model.PhoneNumber = row.GetString(2);
                    model.Address = row.GetString(3);
                    model.Department = row.GetString(4);
                    model.Gender = row.GetString(5);
                    model.BasicPay = row.GetInt32(6);
                    model.Deductions = row.GetInt32(7);
                    model.TaxablePay = row.GetInt32(8);
                    model.Tax = row.GetInt32(9);
                    model.NetPay = row.GetInt32(10);
                    model.StartDate = row.GetDateTime(11);
                    model.City = row.GetString(12);
                    model.Country = row.GetString(13);

                    employees.Add(model);
                    Console.WriteLine(model.EmployeeId +" "+model.EmployeeName+ " " + model.PhoneNumber + " " + model.Address + " " + model.Department + " " + model.StartDate + " " + model.Address + " " + model.Gender + " " + model.BasicPay + " " + model.Deductions + " " + model.TaxablePay + " " + model.Tax + " " + model.NetPay + " " + model.StartDate + " " + model.City + " " + model.Country);

                }
            }
            connection.Close();
            return employees;
        }

    }
}
