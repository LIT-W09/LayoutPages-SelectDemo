using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14.Models
{

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Region { get; set; }
        public DateTime? BirthDate { get; set; }
    }
    public class NorthwindDb
    {
        private string _connectionString;

        public NorthwindDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Employee> GetEmployees()
        {
            
            DateTime? foo = null;
            
            //if(foo != null)
            //{

            //}
            //if (foo.HasValue)
            //{

            //}
            //SqlConnection connection = new(_connectionString);
            var connection = new SqlConnection(_connectionString);
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Employees";
            var result = new List<Employee>();
            connection.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Employee
                {
                    Id = (int)reader["EmployeeId"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Region = reader.GetOrNull<string>("Region"),
                    BirthDate = reader.GetOrNull<DateTime?>("BirthDate")
                });
            }

            return result;
        }
    }
}
