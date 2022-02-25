﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Data_Layer
{
    public class PersonDA : Data_Object
    {
        public class PersonBO
        {
            public int PersonID;

            public string FirstName;

            public string LastName;

            public int Age;

            public string EmailID;

            public string Gender;

            public int AddressID;
        }

        public List<PersonBO> GetPersons()
        {
            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand("dbo.SP_get_all_persons", con);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter outPutParameter = new SqlParameter();
            outPutParameter.ParameterName = "@PersonCount";
            outPutParameter.SqlDbType = SqlDbType.Int;
            outPutParameter.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outPutParameter);

            con.Open();

            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //sda.Fill(ds);
            SqlDataReader rdr = cmd.ExecuteReader();

            List<PersonBO> persons = new List<PersonBO>();

            while (rdr.Read())
            {
                PersonBO person = new PersonBO();

                person.PersonID = Convert.ToInt32(rdr["PersonID"]);
                person.FirstName = Convert.ToString(rdr["FirstName"]);
                person.LastName = Convert.ToString(rdr["LastName"]);
                person.Age = Convert.ToInt32(rdr["Age"]);
                person.EmailID = Convert.ToString(rdr["EmailID"]);
                person.Gender = Convert.ToString(rdr["Gender"]);
                person.AddressID = Convert.ToInt32(rdr["AddressID"]);

                persons.Add(person);

            }

            return persons;

        }

        public PersonBO GetPerson(int id)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            //SqlCommand cmd = new SqlCommand("SP_get_person", conn);
            //cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@PersonID", id);

            //conn.Open();

            //SqlDataReader rdr = cmd.ExecuteReader();

            string sqlQuery = "SELECT * FROM Person WHERE PersonID= " + id;
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();


            PersonBO person = new PersonBO();

            while (rdr.Read())
            {
                person.PersonID = Convert.ToInt32(rdr["PersonID"]);
                person.FirstName = Convert.ToString(rdr["FirstName"]);
                person.LastName = Convert.ToString(rdr["LastName"]);
                person.Age = Convert.ToInt32(rdr["Age"]);
                person.EmailID = Convert.ToString(rdr["EmailID"]);
                person.Gender = Convert.ToString(rdr["Gender"]);
                person.AddressID = Convert.ToInt32(rdr["AddressID"]);
            }

            //PersonBO person = new PersonBO()
            //{
            //    PersonID = Convert.ToInt32(rdr["PersonID"]),
            //    FirstName = Convert.ToString(rdr["FirstName"]),
            //    LastName = Convert.ToString(rdr["LastName"]),
            //    Age = Convert.ToInt32(rdr["Age"]),
            //    EmailID = Convert.ToString(rdr["EmailID"]),
            //    Gender = Convert.ToString(rdr["Gender"]),
            //    AddressID = Convert.ToInt32(rdr["AddressID"])
            //};

            return person;
        }

        public void InsertPerson(PersonBO personBO)
        {

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("SP_insert_person", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FirstName", personBO.FirstName);
            cmd.Parameters.AddWithValue("@LastName", personBO.LastName);
            cmd.Parameters.AddWithValue("@Age", personBO.Age);
            cmd.Parameters.AddWithValue("@EmailID", personBO.EmailID);
            cmd.Parameters.AddWithValue("@Gender", personBO.Gender);
            cmd.Parameters.AddWithValue("@AddressID", personBO.AddressID);

            //SqlParameter outputParameter = new SqlParameter();
            //outputParameter.ParameterName = "@PersonID";
            //outputParameter.SqlDbType = SqlDbType.Int;
            //outputParameter.Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(outputParameter);

            //lblMessess.Text = "ID of a new person inserted is" + " " + outputParameter.Value.ToString() + ".";

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdatePerson(PersonBO personBO)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand("dbo.SP_update_person", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PersonID", personBO.PersonID);
            cmd.Parameters.AddWithValue("@FirstName", personBO.FirstName);
            cmd.Parameters.AddWithValue("@LastName", personBO.LastName);
            cmd.Parameters.AddWithValue("@Age", personBO.Age);
            cmd.Parameters.AddWithValue("@EmailID", personBO.EmailID);
            cmd.Parameters.AddWithValue("@Gender", personBO.Gender);
            cmd.Parameters.AddWithValue("@AddressID", personBO.AddressID);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}