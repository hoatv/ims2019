using System;
using System.Collections.Generic;
using System.Data;
using IMS_2019.ViewModel;
using IMS_2019.Models;
using MySql.Data.MySqlClient;

namespace IMS_2019.Util
{
    public class ExceptionLogging
    {
        static string connectionString = "Server=42.113.206.229;port=3306; Database=ims;User=vantt2;password=topica@123;";


        public static void SendExcepToDB(String message, String type, String actionBy)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("sp_InsertLogTransaction", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@message", message.ToString());
                    cmd.Parameters.AddWithValue("@type", type.ToString());
                    cmd.Parameters.AddWithValue("@created_by", actionBy.ToString());
                    cmd.Parameters.AddWithValue("@updated_by", actionBy.ToString());
                    int insertedID = int.Parse(cmd.ExecuteScalar().ToString());
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex:" + ex);
            }



        }
    }
}
