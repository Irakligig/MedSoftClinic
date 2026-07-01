using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using MedsoftClinic.Models;

namespace MedsoftClinic.Data
{
    public class PatientRepository
    {
        public List<Patient> GetAll()
        {
            var result = new List<Patient>();

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand("dbo.Patients_GetAll", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(MapPatient(reader));
                    }
                }
            }

            return result;
        }

        public Patient GetById(int id)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand("dbo.Patients_GetById", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return MapPatient(reader);
                    }
                }
            }

            return null;
        }

        public int Insert(Patient patient)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand("dbo.Patients_Insert", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FullName", patient.FullName);
                cmd.Parameters.AddWithValue("@Dob", patient.Dob);
                cmd.Parameters.AddWithValue("@GenderID", patient.GenderID);
                cmd.Parameters.AddWithValue("@Phone", (object)patient.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", (object)patient.Address ?? DBNull.Value);

                var outputParam = new SqlParameter("@NewID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputParam);

                conn.Open();
                cmd.ExecuteNonQuery();

                return (int)outputParam.Value;
            }
        }

        public void Update(Patient patient)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand("dbo.Patients_Update", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", patient.ID);
                cmd.Parameters.AddWithValue("@FullName", patient.FullName);
                cmd.Parameters.AddWithValue("@Dob", patient.Dob);
                cmd.Parameters.AddWithValue("@GenderID", patient.GenderID);
                cmd.Parameters.AddWithValue("@Phone", (object)patient.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", (object)patient.Address ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand("dbo.Patients_Delete", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private static Patient MapPatient(IDataRecord reader)
        {
            return new Patient
            {
                ID = (int)reader["ID"],
                FullName = reader["FullName"].ToString(),
                Dob = (DateTime)reader["Dob"],
                GenderID = (int)reader["GenderID"],
                GenderName = reader["GenderName"].ToString(),
                Phone = reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString(),
                Address = reader["Address"] == DBNull.Value ? null : reader["Address"].ToString()
            };
        }
    }
}