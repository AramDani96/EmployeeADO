using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenegmentSystemEmploye
{
    internal class DeveloperRepository : IRepository<Developer>
    {
        private const string CONNECTION_STRING = "Data Source=.;Initial Catalog=EmployeeDB;Integrated Security=True;Encrypt=False";

        public void Add(Developer developer)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            { 
             connection.Open();

                using (SqlCommand command = new SqlCommand(CONNECTION_STRING))
                { 
                command.Connection = connection;
                    command.CommandText = "INSERT INTO Developer VALUES(@DeveloperName,@DeveloperRole)";
                    command.Parameters.Add(new SqlParameter("@DeveloperName", developer.Name));
                    command.Parameters.Add(new SqlParameter("@DeveloperRole", developer.Role));
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Developer> GetAll()
        {
            List<Developer> developers = new List<Developer>();

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Developer";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Developer developer = new Developer();
                            developer.Id = int.Parse(reader["DeveloperId"].ToString());
                            developer.Name = reader["DeveloperName"].ToString();
                            developer.Role = reader["DeveloperRole"].ToString();
                            developers.Add(developer);
                        }
                    }
                }
            }
            return developers;
        }

        public Developer GetBy(int id)
        {
            Developer developer = new Developer();

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Developer WHERE id = @DeveloperId";
                    command.Parameters.Add(new SqlParameter("@DeveloperId", id));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            developer.Id = int.Parse(reader["DeveloperId"].ToString());
                            developer.Name = reader["DeveloperName"].ToString();
                            developer.Role = reader["DeveloperRole"].ToString();
                        }
                    }
                }
            }
            return developer;
        }

        public void Remove(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM Developer WHERE id = @DeveloperId";
                    command.Parameters.Add(new SqlParameter("id", id));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Developer developer)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE Developer SET Name = @DeveloperName, Role = @DeveloperRole WHERE Id = @DeveloperId";
                    command.Parameters.Add(new SqlParameter("@DeveloperId", developer.Id));
                    command.Parameters.Add(new SqlParameter("@DeveloperName", developer.Name));
                    command.Parameters.Add(new SqlParameter("@DeveloperRole", developer.Role));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
