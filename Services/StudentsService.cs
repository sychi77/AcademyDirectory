using Academy.Models.Domain;
using Academy.Models.Requests;
using Academy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Services
{
    public class StudentsService : IStudentsService
    {
        public int Insert(StudentAddRequest model)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Students_Insert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleName", model.MiddleInitial);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@DOB", model.DateOfBirth);
                    cmd.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);

                    SqlParameter parm = new SqlParameter("@Id", SqlDbType.Int);
                    parm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);

                    cmd.ExecuteNonQuery();

                    id = (int)cmd.Parameters["@Id"].Value;
                }
                conn.Close();
            }
            return id;
        }
        public List<Students> SelectAll()
        {
            List<Students> studentsList = new List<Students>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("dbo.Students_SelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
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
        public Students SelectById(int id)
        {
            Students model = new Students();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Students_SelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                        model = Mapper(reader);
                }
                conn.Close();
            }
            return model;
        }
        public void Update(StudentUpdateRequest model)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Students_Update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", model.Id);
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleInitial", model.MiddleInitial);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@DOB", model.DateOfBirth);
                    cmd.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Students_Delete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
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
