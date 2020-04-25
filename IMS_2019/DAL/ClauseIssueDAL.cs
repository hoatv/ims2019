using System;
using System.Collections.Generic;
using System.Data;
using IMS_2019.Models;
using IMS_2019.Util;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace IMS_2019.DAL
{
    public class ClauseIssueDAL
    {
        string connectionString = "Server=42.113.206.229;port=3306; Database=ims;User=vantt2;password=topica@123;";

        public List<ClauseIssueModel> GetAllClauseIssue()
        {
            List<ClauseIssueModel> listClauseIsue = new List<ClauseIssueModel>();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_GetAllClauseIssue", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ClauseIssueModel clauseIssue = new ClauseIssueModel();
                    clauseIssue.ClauseIssueID = Convert.ToInt32(rdr["clause_issue_ID"]);
                    clauseIssue.ClauseIssueIDOld = rdr["clause_issue_ID_old"].ToString();
                    clauseIssue.ClauseID = Convert.ToInt32(rdr["clause_ID"]);
                    clauseIssue.IssueID = Convert.ToInt32(rdr["issue_ID"]);
                    clauseIssue.UrlScreenshot = rdr["url_screenshot"].ToString();
                    clauseIssue.EmailText = rdr["email_text"].ToString();
                    clauseIssue.URLAttachment = rdr["url_attachment"].ToString();
                    clauseIssue.EmailSender = rdr["email_sender"].ToString();
                    clauseIssue.CreatedBy = rdr["creator_ID"].ToString();
                    clauseIssue.CreatedAt = rdr["created_at"].ToString();
                    clauseIssue.UpdatedAt = rdr["updated_at"].ToString();
                    clauseIssue.UpdatedBy = rdr["updated_by"].ToString();
                    //employee.Gender = rdr["Gender"].ToString();
                    //employee.Department = rdr["Department"].ToString();
                    //employee.City = rdr["City"].ToString();
                    listClauseIsue.Add(clauseIssue);
                }
                con.Close();
            }
            return listClauseIsue;
        }
        public List<ClauseIssueModel> GetAllClauseIssue(out int totalCount)
        {
            List<ClauseIssueModel> listClauseIsue = new List<ClauseIssueModel>();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("ssp_GetAllClauseIssue", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ClauseIssueModel clauseIssue = new ClauseIssueModel();
                    clauseIssue.ClauseIssueID = Convert.ToInt32(rdr["clause_issue_ID"]);
                    clauseIssue.ClauseIssueIDOld = rdr["clause_issue_ID_old"].ToString();
                    clauseIssue.ClauseID = Convert.ToInt32(rdr["clause_ID"]);
                    clauseIssue.IssueID = Convert.ToInt32(rdr["issue_ID"]);
                    clauseIssue.UrlScreenshot = rdr["url_screenshot"].ToString();
                    clauseIssue.EmailText = rdr["email_text"].ToString();
                    clauseIssue.URLAttachment = rdr["url_attachment"].ToString();
                    clauseIssue.EmailSender = rdr["email_sender"].ToString();
                    clauseIssue.CreatedBy = rdr["creator_ID"].ToString();
                    clauseIssue.CreatedAt = rdr["created_at"].ToString();
                    clauseIssue.UpdatedAt = rdr["updated_at"].ToString();
                    clauseIssue.UpdatedBy = rdr["updated_by"].ToString();
                    //employee.Gender = rdr["Gender"].ToString();
                    //employee.Department = rdr["Department"].ToString();
                    //employee.City = rdr["City"].ToString();
                    listClauseIsue.Add(clauseIssue);
                }
                con.Close();
            }
            totalCount = listClauseIsue.Count;
            return listClauseIsue;
        }
        public ClauseIssueModel GeClauseIssueByID(string id)
        {
            ClauseIssueModel clauseIssue = new ClauseIssueModel();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from clause_issue where clause_issue_ID = " + id + ";", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    clauseIssue.ClauseIssueID = Convert.ToInt32(rdr["clause_issue_ID"]);
                    clauseIssue.ClauseIssueIDOld = rdr["clause_issue_ID_old"].ToString();
                    clauseIssue.ClauseID = Convert.ToInt32(rdr["clause_ID"]);
                    clauseIssue.IssueID = Convert.ToInt32(rdr["issue_ID"]);
                    clauseIssue.UrlScreenshot = rdr["url_screenshot"].ToString();
                    clauseIssue.EmailText = rdr["email_text"].ToString();
                    clauseIssue.URLAttachment = rdr["url_attachment"].ToString();
                    clauseIssue.EmailSender = rdr["email_sender"].ToString();
                    clauseIssue.CreatedBy = rdr["creator_ID"].ToString();
                    clauseIssue.CreatedAt = rdr["created_at"].ToString();
                    clauseIssue.UpdatedAt = rdr["updated_at"].ToString();
                    clauseIssue.UpdatedBy = rdr["updated_by"].ToString();
                }
                con.Close();
            }
            return clauseIssue;

        }

        public String InsertClauseIssue(ClauseIssueModel clauseModel, string userName)
        {
            string result = "success";
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string insert = "insert into clause_issue(clause_issue_ID_old,clause_ID,issue_ID,url_screenshot,email_text,url_attachment,email_sender,creator_ID,created_at,updated_at,updated_by)" +
                        "values (@clause_issue_ID_old,@clause_ID,@issue_ID,@url_screenshot,@email_text,@url_attachment,@email_sender,(select id from aspnetusers where username = '" + userName + "'),@created_at,@updated_at,(select id from aspnetusers where username = '" + userName + "'))";

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(insert, con);
                    cmd.Prepare();
                    //cmd.Parameters.AddWithValue("@clause_issue_ID", clauseModel.ClauseIssueID.ToString());
                    cmd.Parameters.AddWithValue("@clause_issue_ID_old", clauseModel.ClauseIssueIDOld.ToString());
                    cmd.Parameters.AddWithValue("@clause_ID", clauseModel.ClauseID.ToString());
                    cmd.Parameters.AddWithValue("@issue_ID", clauseModel.IssueID.ToString());
                    cmd.Parameters.AddWithValue("@url_screenshot", clauseModel.UrlScreenshot.ToString());
                    cmd.Parameters.AddWithValue("@email_text", clauseModel.EmailText.ToString());
                    cmd.Parameters.AddWithValue("@url_attachment", clauseModel.URLAttachment.ToString());
                    cmd.Parameters.AddWithValue("@email_sender", clauseModel.EmailSender.ToString());
                    cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                result = "fail";
            }
            finally
            {
                var json = JsonConvert.SerializeObject(clauseModel);
                ExceptionLogging.SendExcepToDB(json, "insert", userName);
            }



            return result;
        }

        public String UpdateClauseIssue(ClauseIssueModel clauseModel, string userName)
        {
            string result = "success";
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string insert = "update clause_issue set clause_issue_ID_old=@clause_issue_ID_old,clause_ID=@clause_ID,issue_ID=@issue_ID,url_screenshot=@url_screenshot,email_text=@email_text,url_attachment=@url_attachment,email_sender=@email_sender,updated_at=@updated_at,updated_by=(select id from aspnetusers where username = '" + userName + "')";

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(insert, con);
                    cmd.Prepare();
                    //cmd.Parameters.AddWithValue("@clause_issue_ID", clauseModel.ClauseIssueID.ToString());
                    cmd.Parameters.AddWithValue("@clause_issue_ID_old", clauseModel.ClauseIssueIDOld.ToString());
                    cmd.Parameters.AddWithValue("@clause_ID", clauseModel.ClauseID.ToString());
                    cmd.Parameters.AddWithValue("@issue_ID", clauseModel.IssueID.ToString());
                    cmd.Parameters.AddWithValue("@url_screenshot", clauseModel.UrlScreenshot.ToString());
                    cmd.Parameters.AddWithValue("@email_text", clauseModel.EmailText.ToString());
                    cmd.Parameters.AddWithValue("@url_attachment", clauseModel.URLAttachment.ToString());
                    cmd.Parameters.AddWithValue("@email_sender", clauseModel.EmailSender.ToString());
                    //cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                result = "fail";
            }
            finally
            {
                var json = JsonConvert.SerializeObject(clauseModel);
                ExceptionLogging.SendExcepToDB(json, "update", userName);
            }


            return result;
        }
    }
}
