using System;

using EmpPayRollDB;

public class Program
{
    public static void Main(String[] args)
    {
        EmployeeRipo empservice = new EmployeeRipo();
        Console.WriteLine("Welcome in the Employee Pay Roll Service");
        EmployeeRipo payrollService = new EmployeeRipo();
        bool check = true;


        while (check)
        {
            Console.WriteLine("1. To Insert the Data in Database \n2. To Retrieve the Data in Database\n3. To Update the data in Database\n4. To Delete the data in Database");
            Console.WriteLine("Enter the Above Option");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    EmpModel empModel = new EmpModel();
                    //empModel.Id = 111;
                    empModel.Name = "Govind";
                    empModel.Salary = 20000;
                    empModel.StartDate = DateTime.Now;
                    empModel.Gender = "M";
                    empModel.ContactNumber = "9541750256";

                    empModel.Address = "Dhule";
                    empModel.Pay = 500;
                    empModel.Deduction = 500;
                    empModel.Texable = 500;
                    empModel.IncomeTax = 500;
                    empModel.NetPay = 2000;
                    payrollService.AddEmp(empModel);
                    break;
                case 2:
                    List<EmpModel> empList = empservice.GetAllEmployees();
                    foreach (EmpModel data in empList)
                    {
                        Console.WriteLine(data.Id + " " + data.Name + " " + data.Salary + " " + data.Gender + " " + data.StartDate + " " + data.Address + " " + data.ContactNumber + " " + data.Pay + " " + data.Texable + " " + data.Deduction + " " + data.IncomeTax + " " + data.NetPay);
                    }
                    break;
                case 3:
                    EmpModel emp = new EmpModel();
                    emp.Id = 1;
                    emp.Salary = 90000;
                    empservice.UpdateEmp(emp);
                    break;
                case 4:
                    List<EmpModel> eList = payrollService.GetAllEmployees();
                    Console.WriteLine("Enter the Employee Id to Delete the Record  From the Table");
                    int empId = Convert.ToInt32(Console.ReadLine());
                    foreach (EmpModel data in eList)
                    {
                        if (data.Id == empId)
                        {
                            payrollService.DeleteEmployee(empId);
                            Console.WriteLine("Record Successfully Deleted");
                        }
                        else
                        {
                            Console.WriteLine(empId + "is Not present int he Data base");
                        }
                    }
                    break;
                case 5:
                    empservice.DataBasedOnDateRange();
                    break;
                case 0:
                    check = false;
                    break;
                default:
                    Console.WriteLine("Please Enter the Correct option");
                    break;
            }
        }

    }
}