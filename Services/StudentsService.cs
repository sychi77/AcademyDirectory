using Academy.Models.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Services
{
    public class StudentsService
    {
        public List<Students> SelectAll()
        {
            List<Students> studentsList = new List<Students>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("dbo.Students_SelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Students model = Mapper(reader);
                        studentsList.Add(model);
                    }
                }
                conn.Close();
            }
            return studentsList;
        }

        private Students Mapper(SqlDataReader reader)
        {
            Students model = new Students();
            int index = 0;

            model.Id = reader.GetInt32(index++);
            model.FirstName = reader.GetString(index++);
            if (!reader.IsDBNull(index)) { model.MiddleInitial = reader.GetString(index++); }
            else { index++; }
            model.LastName = reader.GetString(index++);
            model.DateOfBirth = reader.GetDateTime(index++);
            model.CreatedDate = reader.GetDateTime(index++);
            model.ModifiedDate = reader.GetDateTime(index++);
            model.ModifiedBy = reader.GetString(index++);

            return model;
        }
    }
}
