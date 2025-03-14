using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenegmentSystemEmploye
{
    class ManagerRepository : IRepository<Manager>
    {
        private const string CONNECTION_STRING = "Data Source=.;Initial Catalog=EmployeeDB;Integrated Security=True;Encrypt=False";

        public void Add(Manager t)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                { 
                command.Connection = connection;
                    command.CommandText = "INSERT INTO Manager VALUES(@ManagerName,@ManagerRole)";
                    command.Parameters.Add(new SqlParameter("@ManagerName", t.Name));
                    command.Parameters.Add(new SqlParameter("@ManagerRole", t.Role));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Manager t)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE Manager SET Name = @ManagerName, Role = @ManagerRole WHERE Id=@Id";
                    command.Parameters.Add(new SqlParameter("@ManagerId", t.Id));
                    command.Parameters.Add(new SqlParameter("@ManagerName", t.Name));
                    command.Parameters.Add(new SqlParameter("@ManagerRole", t.Role));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Remove(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM MANAGER WHERE Id = @ManagerId";
                    command.Parameters.Add(new SqlParameter("@ManagerId", id));
                    command.ExecuteNonQuery();
                }
            }
        }

        public Manager GetBy(int id)
        {
            Manager manager = new Manager();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT FROM Manager WHERE id = @ManagerId";
                    command.Parameters.Add(new SqlParameter("@ManagerId", id));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            manager.Id = int.Parse(reader["ManagerId"].ToString());
                            manager.Name = reader["ManagerName"].ToString();
                            manager.Role = reader["ManagerRole"].ToString();
                        }

                    }
                }
            }
            return manager;
        }

        public IEnumerable<Manager> GetAll()
        {
            List<Manager> managers = new List<Manager>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Manager";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Manager manager = new Manager();
                            manager.Id = int.Parse(reader["ManagerId"].ToString());
                            manager.Name = reader["ManagerName"].ToString();
                            manager.Role = reader["ManagerRole"].ToString();
                            managers.Add(manager);
                        }
                    }
                }
            }
            return managers;
        }
    }
}
