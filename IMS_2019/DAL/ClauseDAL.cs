using System;
using System.Collections.Generic;
using System.Diagnostics;
using IMS_2019.Models;
using IMS_2019.Util;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace IMS_2019.DAL
{
    public class ClauseDAL
    {

        string connectionString = "Server=42.113.206.229;port=3306; Database=ims;User=vantt2;password=topica@123;";

        public List<ClauseModel> GetAllClause()
        {
            List<ClauseModel> listClause = new List<ClauseModel>();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from clause;", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ClauseModel clause = new ClauseModel();
                    clause.ClauseID = Convert.ToInt32(rdr["clause_ID"]);
                    clause.DocumentID = Convert.ToInt32(rdr["document_ID"]);
                    clause.ClauseNo = rdr["clause_no"].ToString();
                    clause.ClausePage = rdr["clause_page"].ToString();
                    clause.ClauseContent = rdr["clause_content"].ToString();
                    clause.DocVersionID = Convert.ToInt32(rdr["doc_version_ID"]);
                    clause.CreatedBy = rdr["creator_ID"].ToString();
                    //document.UpdatedBy = Convert.ToInt32(rdr["creator_ID"]);
                    clause.CreatedAt = rdr["created_at"].ToString();
                    //document.UpdatedAt = rdr["updated_at"].ToString();
                    //document.UpdatedBy = Convert.ToInt32(rdr["updated_by"]);
                    //employee.Gender = rdr["Gender"].ToString();
                    //employee.Department = rdr["Department"].ToString();
                    //employee.City = rdr["City"].ToString();
                    listClause.Add(clause);
                }
                con.Close();
            }
            //totalCount = listClause.Count;
            return listClause;
        }
        public List<ClauseModel> GetAllClause(out int totalCount)
        {
            List<ClauseModel> listClause = new List<ClauseModel>();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from clause;", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ClauseModel clause = new ClauseModel();
                    clause.ClauseID = Convert.ToInt32(rdr["clause_ID"]);
                    clause.DocumentID = Convert.ToInt32(rdr["document_ID"]);
                    clause.ClauseNo = rdr["clause_no"].ToString();
                    clause.ClausePage = rdr["clause_page"].ToString();
                    clause.ClauseContent = rdr["clause_content"].ToString();
                    clause.DocVersionID = Convert.ToInt32(rdr["doc_version_ID"]);
                    clause.CreatedBy = rdr["creator_ID"].ToString();
                    //document.UpdatedBy = Convert.ToInt32(rdr["creator_ID"]);
                    clause.CreatedAt = rdr["created_at"].ToString();
                    //document.UpdatedAt = rdr["updated_at"].ToString();
                    //document.UpdatedBy = Convert.ToInt32(rdr["updated_by"]);
                    //employee.Gender = rdr["Gender"].ToString();
                    //employee.Department = rdr["Department"].ToString();
                    //employee.City = rdr["City"].ToString();
                    listClause.Add(clause);
                }
                con.Close();
            }
            totalCount = listClause.Count;
            return listClause;
        }

        public ClauseModel GetClauseById(string clauseId)
        {
            ClauseModel clauseModel = new ClauseModel();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from clause where clause_ID='"+clauseId+"' ; ", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    clauseModel.ClauseOldID = rdr["clause_ID_old"].ToString();
                    clauseModel.ClauseID = Convert.ToInt32(rdr["clause_ID"]);
                    clauseModel.DocumentID = Convert.ToInt32(rdr["document_ID"]);
                    clauseModel.ClauseNo = rdr["clause_no"].ToString();
                    clauseModel.ClausePage = rdr["clause_page"].ToString();
                    clauseModel.ClauseContent = rdr["clause_content"].ToString();
                    clauseModel.DocVersionID = Convert.ToInt32(rdr["doc_version_ID"]);
                    clauseModel.CreatedBy = rdr["creator_ID"].ToString();
                    //document.UpdatedBy = Convert.ToInt32(rdr["creator_ID"]);
                    clauseModel.CreatedAt = rdr["created_at"].ToString();
                    //document.UpdatedAt = rdr["updated_at"].ToString();
                    //document.UpdatedBy = Convert.ToInt32(rdr["updated_by"]);
                    //employee.Gender = rdr["Gender"].ToString();
                    //employee.Department = rdr["Department"].ToString();
                    //employee.City = rdr["City"].ToString();
                }
                con.Close();
            }
            return clauseModel;
        }

        public String InsertClause(ClauseModel clauseModel, string userName)
        {
            string result = "success";
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string insert = "insert into clause(clause_ID_old,document_ID,clause_no,clause_page,clause_content,doc_version_ID,creator_ID,created_at,updated_at,updated_by)" +
                        "values (@clause_ID_old,@document_ID,@clause_no,@clause_page,@clause_content,@doc_version_ID,(select id from aspnetusers where username = '" + userName + "'),@created_at,@updated_at,(select id from aspnetusers where username = '" + userName + "'))";

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(insert, con);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@clause_ID_old", clauseModel.ClauseOldID.ToString());
                    cmd.Parameters.AddWithValue("@document_ID", clauseModel.DocumentID.ToString());
                    cmd.Parameters.AddWithValue("@clause_no", clauseModel.ClauseNo.ToString());
                    cmd.Parameters.AddWithValue("@clause_page", clauseModel.ClausePage.ToString());
                    cmd.Parameters.AddWithValue("@clause_content", clauseModel.ClauseContent.ToString());
                    cmd.Parameters.AddWithValue("@doc_version_ID", clauseModel.DocVersionID.ToString());
                    cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                result = "fail";
            }finally
            {
                var json = JsonConvert.SerializeObject(clauseModel);
                ExceptionLogging.SendExcepToDB(json, "insert", userName);
            }


            return result;
        }

        public String UpdateClause(ClauseModel clauseModel, string userName)
        {
            string result = "success";
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string insert = "update clause set clause_ID_old=@clause_ID_old,document_ID=@document_ID,clause_no=@clause_no,clause_page=@clause_page,clause_content=@clause_content,doc_version_ID=@doc_version_ID" +
                        ",updated_at=@updated_at,updated_by = (select id from aspnetusers where username = '" + userName + "') where clause_ID=@clause_ID;";

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(insert, con);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@clause_ID", clauseModel.ClauseID.ToString());
                    cmd.Parameters.AddWithValue("@clause_ID_old", clauseModel.ClauseOldID.ToString());
                    cmd.Parameters.AddWithValue("@document_ID", clauseModel.DocumentID.ToString());
                    cmd.Parameters.AddWithValue("@clause_no", clauseModel.ClauseNo.ToString());
                    cmd.Parameters.AddWithValue("@clause_page", clauseModel.ClausePage.ToString());
                    cmd.Parameters.AddWithValue("@clause_content", clauseModel.ClauseContent.ToString());
                    cmd.Parameters.AddWithValue("@doc_version_ID", clauseModel.DocVersionID.ToString());
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
                StackTrace stackTrace = new StackTrace();
                var routeValues = System.Reflection.MethodBase.GetCurrentMethod().Name;
                String caller = stackTrace.GetFrame(1).GetMethod().Name.ToString();
                var json = JsonConvert.SerializeObject(clauseModel);
                ExceptionLogging.SendExcepToDB(json, "update", userName);
            }


            return result;
        }
    }

    

}
