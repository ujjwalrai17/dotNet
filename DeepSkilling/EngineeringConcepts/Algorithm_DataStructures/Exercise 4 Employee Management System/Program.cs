using System;

namespace EmployeeManagementSystem
{
    class Employee
    {
        public int EmployeeId;
        public string Name;
        public string Position;
        public double Salary;

        public Employee(int id, string name, string position, double salary)
        {
            EmployeeId = id;
            Name = name;
            Position = position;
            Salary = salary;
        }
    }

    class Program
    {
        static Employee[] employees = new Employee[10];
        static int count = 0;

        
        static void AddEmployee(Employee emp)
        {
            if (count < employees.Length)
            {
                employees[count] = emp;
                count++;
                Console.WriteLine("Added.");
            }
            else
            {
                Console.WriteLine("Array is Full.");
            }
        }


        static void SearchEmployee(int id)
        {
            for (int i = 0; i < count; i++)
            {
                if (employees[i].EmployeeId == id)
                {
                    Console.WriteLine("\nFound");
                    Console.WriteLine("ID: " + employees[i].EmployeeId);
                    Console.WriteLine("Name: " + employees[i].Name);
                    Console.WriteLine("Position: " + employees[i].Position);
                    Console.WriteLine("Salary: " + employees[i].Salary);
                    return;
                }
            }

            Console.WriteLine("Not Found.");
        }

        static void TraverseEmployees()
        {
            Console.WriteLine("\nRecords");

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(
                    employees[i].EmployeeId + " " +
                    employees[i].Name + " " +
                    employees[i].Position + " " +
                    employees[i].Salary);
            }
        }

        
        static void DeleteEmployee(int id)
        {
            int index = -1;

            for (int i = 0; i < count; i++)
            {
                if (employees[i].EmployeeId == id)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Console.WriteLine("Not Found.");
                return;
            }

            for (int i = index; i < count - 1; i++)
            {
                employees[i] = employees[i + 1];
            }

            employees[count - 1] = null;
            count--;

            Console.WriteLine("Employee Deleted.");
        }

        static void Main(string[] args)
        {
            AddEmployee(new Employee(101, "Alice", "Manager", 60000));
            AddEmployee(new Employee(102, "Bob", "Developer", 50000));
            AddEmployee(new Employee(103, "Charlie", "Tester", 45000));

            TraverseEmployees();

            Console.WriteLine("\nSearching Employee with ID 102");
            SearchEmployee(102);

            Console.WriteLine("\nDeleting Employee with ID 102");
            DeleteEmployee(102);

            TraverseEmployees();

            Console.ReadKey();
        }
    }
}