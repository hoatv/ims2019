using System;
using System.Collections.Generic;
using System.Data;
using IMS_2019.ViewModel;
using IMS_2019.Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using IMS_2019.Util;

namespace IMS_2019.DAL
{
    public class IssueDAL
    {
        string connectionString = "Server=42.113.206.229;port=3306; Database=ims;User=vantt2;password=topica@123;";

        public List<IssueVM> GetAllIssue()
        {
            List<IssueVM> listIssueVM = new List<IssueVM>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("sp_GetAllIssue", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        IssueVM issue = new IssueVM();
                        issue.issModel = new IssueModel();
                        int tt = Convert.ToInt32(rdr["issue_ID"]);
                        issue.issModel.IssueID = Convert.ToInt32(rdr["issue_ID"]);
                        issue.issModel.IssueIDOld = String.IsNullOrEmpty(rdr["issue_ID_old"].ToString()) ? "" : rdr["issue_ID_old"].ToString();
                        //issue.issModel.IssueStatusID = Convert.ToInt32(String.IsNullOrEmpty(rdr["issue_status_ID"].ToString()) ? 0 : rdr["issue_status_ID"].ToString());
                        issue.IssueStatusName = String.IsNullOrEmpty(rdr["issue_status_name"].ToString()) ? "" : rdr["issue_status_name"].ToString();
                        issue.issModel.IssueContent = String.IsNullOrEmpty(rdr["issue_content"].ToString()) ? "" : rdr["issue_content"].ToString();
                        issue.issModel.EmailSender = String.IsNullOrEmpty(rdr["email_sender"].ToString()) ? "" : rdr["email_sender"].ToString();
                        issue.issModel.EmailProcessorer = String.IsNullOrEmpty(rdr["email_processorer"].ToString()) ? "" : rdr["email_processorer"].ToString();
                        issue.issModel.NextStep = String.IsNullOrEmpty(rdr["next_step"].ToString()) ? "" : rdr["next_step"].ToString();
                        issue.issModel.CreatedBy = (rdr["creator_ID"].ToString());
                        issue.CreatorName = String.IsNullOrEmpty(rdr["creator_name"].ToString()) ? "" : rdr["creator_name"].ToString();
                        issue.issModel.CreatedAt = String.IsNullOrEmpty(rdr["created_at"].ToString()) ? "" : rdr["created_at"].ToString();
                        issue.issModel.UpdatedAt = String.IsNullOrEmpty(rdr["updated_at"].ToString()) ? "" : rdr["updated_at"].ToString();
                        issue.issModel.UpdatedBy = (String.IsNullOrEmpty(rdr["updated_by"].ToString()) ? "" : rdr["updated_by"].ToString());
                        issue.UpdatedName = String.IsNullOrEmpty(rdr["updated_name"].ToString()) ? "" : rdr["updated_name"].ToString();
                        listIssueVM.Add(issue);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex:" + ex);
            }
            return listIssueVM;
        }

        public IssueModel GetIssueByID(string id)
        {
            IssueModel issModel = new IssueModel();
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("select * from issue where issue_ID = '" + id + "'", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        //IssueVM issue = new IssueVM();

                        int tt = Convert.ToInt32(rdr["issue_ID"]);
                        issModel.IssueID = Convert.ToInt32(rdr["issue_ID"]);
                        issModel.IssueIDOld = String.IsNullOrEmpty(rdr["issue_ID_old"].ToString()) ? "" : rdr["issue_ID_old"].ToString();
                        //issModel.IssueStatusID = Convert.ToInt32(String.IsNullOrEmpty(rdr["issue_status_ID"].ToString()) ? 0 : rdr["issue_status_ID"].ToString());
                        //IssueStatusName = String.IsNullOrEmpty(rdr["issue_status_name"].ToString()) ? "" : rdr["issue_status_name"].ToString();
                        issModel.IssueContent = String.IsNullOrEmpty(rdr["issue_content"].ToString()) ? "" : rdr["issue_content"].ToString();
                        issModel.EmailSender = String.IsNullOrEmpty(rdr["email_sender"].ToString()) ? "" : rdr["email_sender"].ToString();
                        issModel.EmailProcessorer = String.IsNullOrEmpty(rdr["email_processorer"].ToString()) ? "" : rdr["email_processorer"].ToString();
                        issModel.NextStep = String.IsNullOrEmpty(rdr["next_step"].ToString()) ? "" : rdr["next_step"].ToString();
                        issModel.CreatedName = String.IsNullOrEmpty(rdr["creator_name"].ToString()) ? "" : rdr["creator_name"].ToString();
                        issModel.CreatedAt = String.IsNullOrEmpty(rdr["created_at"].ToString()) ? "" : rdr["created_at"].ToString();
                        issModel.UpdatedAt = String.IsNullOrEmpty(rdr["updated_at"].ToString()) ? "" : rdr["updated_at"].ToString();
                        issModel.UpdatedBy = (String.IsNullOrEmpty(rdr["updated_by"].ToString()) ? "" : rdr["updated_by"].ToString());
                        issModel.UpdatedName = String.IsNullOrEmpty(rdr["updated_name"].ToString()) ? "" : rdr["updated_name"].ToString();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex:" + ex);
            }
            return issModel;
        }

        public List<IssueModel> GetAllIssue(out int totalCount)
        {
            List<IssueModel> listIssue = new List<IssueModel>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("sp_GetAllIssue", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        //IssueVM issue = new IssueVM();
                        IssueModel issModel = new IssueModel();
                        int tt = Convert.ToInt32(rdr["issue_ID"]);
                        issModel.IssueID = Convert.ToInt32(rdr["issue_ID"]);
                        issModel.IssueIDOld = String.IsNullOrEmpty(rdr["issue_ID_old"].ToString()) ? "" : rdr["issue_ID_old"].ToString();
                        //issModel.IssueStatusID = Convert.ToInt32(String.IsNullOrEmpty(rdr["issue_status_ID"].ToString()) ? 0 : rdr["issue_status_ID"].ToString());
                        //IssueStatusName = String.IsNullOrEmpty(rdr["issue_status_name"].ToString()) ? "" : rdr["issue_status_name"].ToString();
                        issModel.IssueContent = String.IsNullOrEmpty(rdr["issue_content"].ToString()) ? "" : rdr["issue_content"].ToString();
                        issModel.EmailSender = String.IsNullOrEmpty(rdr["email_sender"].ToString()) ? "" : rdr["email_sender"].ToString();
                        issModel.EmailProcessorer = String.IsNullOrEmpty(rdr["email_processorer"].ToString()) ? "" : rdr["email_processorer"].ToString();
                        issModel.NextStep = String.IsNullOrEmpty(rdr["next_step"].ToString()) ? "" : rdr["next_step"].ToString();
                        issModel.CreatedName  = String.IsNullOrEmpty(rdr["creator_name"].ToString()) ? "" : rdr["creator_name"].ToString();
                        issModel.CreatedAt = String.IsNullOrEmpty(rdr["created_at"].ToString()) ? "" : rdr["created_at"].ToString();
                        issModel.UpdatedAt = String.IsNullOrEmpty(rdr["updated_at"].ToString()) ? "" : rdr["updated_at"].ToString();
                        issModel.UpdatedBy = (String.IsNullOrEmpty(rdr["updated_by"].ToString()) ? "" : rdr["updated_by"].ToString());
                        issModel.UpdatedName = String.IsNullOrEmpty(rdr["updated_name"].ToString()) ? "" : rdr["updated_name"].ToString();
                        listIssue.Add(issModel);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex:" + ex);
            }
            totalCount = listIssue.Count;
            return listIssue;
        }

        public List<IssueModel> GetAllIssues()
        {
            List<IssueModel> listIssue = new List<IssueModel>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("sp_GetAllIssue", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        //IssueVM issue = new IssueVM();
                        IssueModel issModel = new IssueModel();
                        int tt = Convert.ToInt32(rdr["issue_ID"]);
                        issModel.IssueID = Convert.ToInt32(rdr["issue_ID"]);
                        issModel.IssueIDOld = String.IsNullOrEmpty(rdr["issue_ID_old"].ToString()) ? "" : rdr["issue_ID_old"].ToString();
                        //issModel.IssueStatusID = Convert.ToInt32(String.IsNullOrEmpty(rdr["issue_status_ID"].ToString()) ? 0 : rdr["issue_status_ID"].ToString());
                        //IssueStatusName = String.IsNullOrEmpty(rdr["issue_status_name"].ToString()) ? "" : rdr["issue_status_name"].ToString();
                        issModel.IssueContent = String.IsNullOrEmpty(rdr["issue_content"].ToString()) ? "" : rdr["issue_content"].ToString();
                        issModel.EmailSender = String.IsNullOrEmpty(rdr["email_sender"].ToString()) ? "" : rdr["email_sender"].ToString();
                        issModel.EmailProcessorer = String.IsNullOrEmpty(rdr["email_processorer"].ToString()) ? "" : rdr["email_processorer"].ToString();
                        issModel.NextStep = String.IsNullOrEmpty(rdr["next_step"].ToString()) ? "" : rdr["next_step"].ToString();
                        issModel.CreatedName = String.IsNullOrEmpty(rdr["creator_name"].ToString()) ? "" : rdr["creator_name"].ToString();
                        issModel.CreatedAt = String.IsNullOrEmpty(rdr["created_at"].ToString()) ? "" : rdr["created_at"].ToString();
                        issModel.UpdatedAt = String.IsNullOrEmpty(rdr["updated_at"].ToString()) ? "" : rdr["updated_at"].ToString();
                        issModel.UpdatedBy = (String.IsNullOrEmpty(rdr["updated_by"].ToString()) ? "" : rdr["updated_by"].ToString());
                        issModel.UpdatedName = String.IsNullOrEmpty(rdr["updated_name"].ToString()) ? "" : rdr["updated_name"].ToString();
                        listIssue.Add(issModel);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex:" + ex);
            }
            return listIssue;
        }
        public String Insert(IssueModel issueModel, string userName)
        {
            string result = "success";
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string insert = "INSERT INTO issue(issue_ID_old,clause_issue_ID,clause_ID,issue_content,clause_no,clause_page,email_sender,issue_status_ID,email_processorer,next_step,creator_ID,created_at,updated_at,updated_by) VALUES (@issue_ID_old, @clause_issue_ID, @clause_ID, @issue_content, @clause_no, @clause_page, @email_sender,@issue_status_ID, @email_processorer, @next_step,(select id from aspnetusers where username = '" + userName + "'), @created_at, @updated_at, (select id from aspnetusers where username = '" + userName + "')); ";

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(insert, con);
                    cmd.Prepare();
                    //cmd.Parameters.AddWithValue("@clause_issue_ID", clauseModel.ClauseIssueID.ToString());
                    cmd.Parameters.AddWithValue("@issue_ID_old", issueModel.IssueIDOld.ToString());
                    cmd.Parameters.AddWithValue("@clause_issue_ID", issueModel.ClauseIssueID.ToString());
                    cmd.Parameters.AddWithValue("@clause_ID", issueModel.ClauseID.ToString());
                    cmd.Parameters.AddWithValue("@issue_content", issueModel.IssueContent.ToString());
                    cmd.Parameters.AddWithValue("@clause_no", issueModel.ClauseNo.ToString());
                    cmd.Parameters.AddWithValue("@clause_page", issueModel.Clausepage.ToString());
                    cmd.Parameters.AddWithValue("@email_sender", issueModel.EmailSender.ToString());
                    cmd.Parameters.AddWithValue("@issue_status_ID", issueModel.IssueStatus_ID.ToString());
                    cmd.Parameters.AddWithValue("@email_processorer", issueModel.EmailProcessorer.ToString());
                    cmd.Parameters.AddWithValue("@next_step", issueModel.NextStep.ToString());
                    //cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    //cmd.Parameters.AddWithValue("@issue_ID", issueModel.IssueID.ToString());
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
                var json = JsonConvert.SerializeObject(issueModel);
                ExceptionLogging.SendExcepToDB(json, "insert", userName);
            }


            return result;
        }
        public String Update(IssueModel issueModel, string userName)
        {
            string result = "success";
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string insert = "update issue set  issue_ID_old=@issue_ID_old,clause_issue_ID=@clause_issue_ID,issue_content=@issue_content,clause_no=@clause_no,clause_page=@clause_page,email_sender=@email_sender,issue_status_ID=@issue_status_ID,email_processorer=@email_processorer,next_step=@next_step,updated_at=@updated_at,updated_by=(select id from aspnetusers where username = '" + userName + "') where issue_ID =@issue_ID ";

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(insert, con);
                    cmd.Prepare();
                    //cmd.Parameters.AddWithValue("@clause_issue_ID", clauseModel.ClauseIssueID.ToString());
                    cmd.Parameters.AddWithValue("@issue_ID_old", issueModel.IssueIDOld.ToString());
                    cmd.Parameters.AddWithValue("@clause_issue_ID", issueModel.ClauseIssueID.ToString());
                    cmd.Parameters.AddWithValue("@issue_content", issueModel.IssueContent.ToString());
                    cmd.Parameters.AddWithValue("@clause_no", issueModel.ClauseNo.ToString());
                    cmd.Parameters.AddWithValue("@clause_page", issueModel.Clausepage.ToString());
                    cmd.Parameters.AddWithValue("@email_sender", issueModel.EmailSender.ToString());
                    cmd.Parameters.AddWithValue("@issue_status_ID", issueModel.IssueStatus_ID.ToString());
                    cmd.Parameters.AddWithValue("@email_processorer", issueModel.EmailProcessorer.ToString());
                    cmd.Parameters.AddWithValue("@next_step", issueModel.NextStep.ToString());
                    //cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@issue_ID", issueModel.IssueID.ToString());
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
                var json = JsonConvert.SerializeObject(issueModel);
                ExceptionLogging.SendExcepToDB(json, "update", userName);
            }


            return result;
        }
    }
}
