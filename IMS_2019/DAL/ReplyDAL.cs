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
    public class ReplyDAL
    {
        string connectionString = "Server=42.113.206.229;port=3306; Database=ims;User=vantt2;password=topica@123;";

        public List<ReplyModel> GetAllReply()
        {
            List<ReplyModel> listReply = new List<ReplyModel>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("sp_GetAllReply", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ReplyModel reply = new ReplyModel();
                        reply.ReplyID = Convert.ToInt32(rdr["reply_ID"].ToString());
                        reply.IssueIDOld = String.IsNullOrEmpty(rdr["reply_ID_old"].ToString()) ? "" : rdr["reply_ID_old"].ToString();
                        reply.IssueID = Convert.ToInt32(rdr["issue_ID"]);
                        reply.ClauseIssueID = Convert.ToInt32(String.IsNullOrEmpty(rdr["clause_issue_ID"].ToString()) ? 0 : rdr["clause_issue_ID"]);
                        reply.ReplyContent = String.IsNullOrEmpty(rdr["reply_content"].ToString()) ? "" : rdr["reply_content"].ToString();
                        reply.EmailSender = String.IsNullOrEmpty(rdr["email_sender"].ToString()) ? "" : rdr["email_sender"].ToString();
                        reply.CreatedBy = Convert.ToInt32(rdr["creator_ID"]);
                        reply.CreatedName = String.IsNullOrEmpty(rdr["creator_name"].ToString()) ? "" : rdr["creator_name"].ToString();
                        reply.CreatedAt = String.IsNullOrEmpty(rdr["created_at"].ToString()) ? "" : rdr["created_at"].ToString();
                        reply.UpdatedAt = String.IsNullOrEmpty(rdr["updated_at"].ToString()) ? "" : rdr["updated_at"].ToString();
                        reply.UpdatedBy = Convert.ToInt32(String.IsNullOrEmpty(rdr["updated_by"].ToString()) ? 0 : rdr["updated_by"]);
                        reply.UpdatedName = String.IsNullOrEmpty(rdr["updated_name"].ToString()) ? "" : rdr["updated_name"].ToString();
                        listReply.Add(reply);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex:" + ex);
            }
            return listReply;
        }

        public List<ReplyModel> GetAllReply(out int totalCount)
        {
            List<ReplyModel> listReply = new List<ReplyModel>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("sp_GetAllReply", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ReplyModel reply = new ReplyModel();
                        reply.ReplyID = Convert.ToInt32(rdr["reply_ID"].ToString());
                        reply.IssueIDOld = String.IsNullOrEmpty(rdr["reply_ID_old"].ToString()) ? "" : rdr["reply_ID_old"].ToString();
                        reply.IssueID = Convert.ToInt32(rdr["issue_ID"]);
                        reply.ClauseIssueID = Convert.ToInt32(String.IsNullOrEmpty(rdr["clause_issue_ID"].ToString()) ? 0 : rdr["clause_issue_ID"]);
                        reply.ReplyContent = String.IsNullOrEmpty(rdr["reply_content"].ToString()) ? "" : rdr["reply_content"].ToString();
                        reply.EmailSender = String.IsNullOrEmpty(rdr["email_sender"].ToString()) ? "" : rdr["email_sender"].ToString();
                        reply.CreatedBy = Convert.ToInt32(rdr["creator_ID"]);
                        reply.CreatedName = String.IsNullOrEmpty(rdr["creator_name"].ToString()) ? "" : rdr["creator_name"].ToString();
                        reply.CreatedAt = String.IsNullOrEmpty(rdr["created_at"].ToString()) ? "" : rdr["created_at"].ToString();
                        reply.UpdatedAt = String.IsNullOrEmpty(rdr["updated_at"].ToString()) ? "" : rdr["updated_at"].ToString();
                        reply.UpdatedBy = Convert.ToInt32(String.IsNullOrEmpty(rdr["updated_by"].ToString()) ? 0 : rdr["updated_by"]);
                        reply.UpdatedName = String.IsNullOrEmpty(rdr["updated_name"].ToString()) ? "" : rdr["updated_name"].ToString();
                        listReply.Add(reply);
                    }
                    
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex:" + ex);
            }
            totalCount = listReply.Count;
            return listReply;
        }

        public ReplyModel GetReplyByID(string reply_ID)
        {
            ReplyModel reply = new ReplyModel();
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("select * from reply where rely_ID = "+reply_ID, con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        
                        reply.ReplyID = Convert.ToInt32(rdr["reply_ID"].ToString());
                        reply.IssueIDOld = String.IsNullOrEmpty(rdr["reply_ID_old"].ToString()) ? "" : rdr["reply_ID_old"].ToString();
                        reply.IssueID = Convert.ToInt32(rdr["issue_ID"]);
                        reply.ClauseIssueID = Convert.ToInt32(String.IsNullOrEmpty(rdr["clause_issue_ID"].ToString()) ? 0 : rdr["clause_issue_ID"]);
                        reply.ReplyContent = String.IsNullOrEmpty(rdr["reply_content"].ToString()) ? "" : rdr["reply_content"].ToString();
                        reply.EmailSender = String.IsNullOrEmpty(rdr["email_sender"].ToString()) ? "" : rdr["email_sender"].ToString();
                        reply.CreatedBy = Convert.ToInt32(rdr["creator_ID"]);
                        //reply.CreatedName = String.IsNullOrEmpty(rdr["creator_name"].ToString()) ? "" : rdr["creator_name"].ToString();
                        reply.CreatedAt = String.IsNullOrEmpty(rdr["created_at"].ToString()) ? "" : rdr["created_at"].ToString();
                        reply.UpdatedAt = String.IsNullOrEmpty(rdr["updated_at"].ToString()) ? "" : rdr["updated_at"].ToString();
                        reply.UpdatedBy = Convert.ToInt32(String.IsNullOrEmpty(rdr["updated_by"].ToString()) ? 0 : rdr["updated_by"]);
                        //reply.UpdatedName = String.IsNullOrEmpty(rdr["updated_name"].ToString()) ? "" : rdr["updated_name"].ToString();
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex:" + ex);
            }
            return reply;
        }

        public String Insert(ReplyModel replyModel, string userName)
        {
            string result = "success";
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string insert = "INSERT INTO reply(reply_ID_old,issue_ID,clause_issue_ID,reply_content,email_sender,creator_ID,created_at,updated_at,updated_by) VALUES (@reply_ID_old,@issue_ID,@clause_issue_ID,@reply_content,@email_sender,@creator_ID,(select id from aspnetusers where username = '" + userName + "'), @created_at, @updated_at, (select id from aspnetusers where username = '" + userName + "')); ";

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(insert, con);
                    cmd.Prepare();
                    //cmd.Parameters.AddWithValue("@clause_issue_ID", clauseModel.ClauseIssueID.ToString());
                    cmd.Parameters.AddWithValue("@reply_ID_old", replyModel.IssueIDOld.ToString());
                    cmd.Parameters.AddWithValue("@issue_ID", replyModel.IssueID.ToString());
                    cmd.Parameters.AddWithValue("@clause_issue_ID", replyModel.ClauseIssueID.ToString());
                    cmd.Parameters.AddWithValue("@reply_content", replyModel.ReplyContent.ToString());
                    cmd.Parameters.AddWithValue("@email_sender", replyModel.EmailSender.ToString());
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
                var json = JsonConvert.SerializeObject(replyModel);
                ExceptionLogging.SendExcepToDB(json, "insert", userName);
            }
            return result;
        }

        public String Update(ReplyModel replyModel, string userName)
        {
            string result = "success";
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string insert = "update reply set reply_ID_old=@reply_ID_old,issue_ID=@issue_ID,clause_issue_ID=@clause_issue_ID,reply_content=@reply_content,email_sender=@email_senderupdated_at=@updated_at,updated_by=(select id from aspnetusers where username = '" + userName + "') where reply_ID =@reply_ID ";

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(insert, con);
                    cmd.Prepare();
                    //cmd.Parameters.AddWithValue("@clause_issue_ID", clauseModel.ClauseIssueID.ToString());
                    cmd.Parameters.AddWithValue("@reply_ID_old", replyModel.IssueIDOld.ToString());
                    cmd.Parameters.AddWithValue("@issue_ID", replyModel.IssueID.ToString());
                    cmd.Parameters.AddWithValue("@clause_issue_ID", replyModel.ClauseIssueID.ToString());
                    cmd.Parameters.AddWithValue("@reply_content", replyModel.ReplyContent.ToString());
                    cmd.Parameters.AddWithValue("@email_sender", replyModel.EmailSender.ToString());
                    //cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@reply_ID", replyModel.ReplyID.ToString());
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
                var json = JsonConvert.SerializeObject(replyModel);
                ExceptionLogging.SendExcepToDB(json, "update", userName);
            }


            return result;
        }
    }


}
