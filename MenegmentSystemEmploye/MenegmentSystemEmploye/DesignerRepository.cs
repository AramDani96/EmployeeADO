using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenegmentSystemEmploye
{
    internal class DesignerRepository : IRepository<Designer>
    {
        private const string CONNECTION_STRING = "Data Source=.;Initial Catalog=EmployeeDB;Integrated Security=True;Encrypt=False";

        public void Add(Designer designer)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            { 
            connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Designer VALUES(@DesignerName,@DesignerRole)";
                    command.Parameters.Add(new SqlParameter("@DesignerName", designer.Name));
                    command.Parameters.Add(new SqlParameter("@DesignerRole", designer.Role));
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Designer> GetAll()
        {
            List<Designer> designers = new List<Designer>();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Designer";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Designer designer = new Designer();
                            designer.Id = int.Parse(reader["DesignerId"].ToString());
                            designer.Name = reader["DesignerName"].ToString();
                            designer.Role = reader["DesignerRole"].ToString();
                            designers.Add(designer);
                        }
                    }
                }
            }
            return designers;
        }

        public Designer GetBy(int id)
        {
            Designer designer = new Designer();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Designer WHERE id = @DesignerId";
                    command.Parameters.Add(new SqlParameter("@DesignerId", id));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            designer.Id = int.Parse(reader["@DesignerId"].ToString());
                            designer.Name = reader["@DesignerName"].ToString();
                            designer.Role = reader["@DesignerRole"].ToString();
                        }
                    }
                }
            }
            return designer;
        }

        public void Remove(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM Designer WHERE id = @DesignerId";
                    command.Parameters.Add(new SqlParameter("@DesignerId", id));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Designer designer)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE Designer SET Name=@DesignerName,Role=@DesignerRole WHERE Id = @DesignerId";
                    command.Parameters.Add(new SqlParameter("@DesignerId", designer.Id));
                    command.Parameters.Add(new SqlParameter("@DesignerName", designer.Name));
                    command.Parameters.Add(new SqlParameter("@DesignerRole", designer.Role));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
