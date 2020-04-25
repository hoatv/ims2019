using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using IMS_2019.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Diagnostics;

namespace IMS_2019.Models
{
    public class DocumentDAL
    {
        string connectionString = "Server=42.113.206.229;port=3306; Database=ims;User=vantt2;password=topica@123;";

        public List<DocumentModel> GetAllDocuments(out int totalCount)
        {
            List<DocumentModel> listDocument = new List<DocumentModel>();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_GetAllDocument", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DocumentModel document = new DocumentModel();
                    document.DocumentID = Convert.ToInt32(rdr["document_ID"]);
                    document.DocumentTypeID = Convert.ToInt32(rdr["doc_type_ID"]);
                    document.DocumentName = rdr["document_name"].ToString();
                    document.VersionID = Convert.ToInt32(rdr["version_ID"]);
                    document.URL = rdr["url"].ToString();
                    document.Description = rdr["description"].ToString();
                    document.DocStatusID = Convert.ToInt32(rdr["doc_status_ID"]);
                    document.CreatorID = rdr["creator_ID"].ToString();
                    document.CreatedAt = String.IsNullOrEmpty(rdr["created_at"].ToString()) ? "" : rdr["created_at"].ToString();
                    document.UpdatedAt = String.IsNullOrEmpty(rdr["updated_at"].ToString()) ? "" : rdr["updated_at"].ToString();
                    document.UpdatedBy = String.IsNullOrEmpty(rdr["updated_by"].ToString()) ? "" : rdr["updated_by"].ToString();
                    document.DocTypeName = String.IsNullOrEmpty(rdr["doc_type_name"].ToString()) ? "" : rdr["doc_type_name"].ToString();
                    document.VersionName = String.IsNullOrEmpty(rdr["version_name"].ToString()) ? "" : rdr["version_name"].ToString();
                    document.DocStatusName = String.IsNullOrEmpty(rdr["doc_status_name"].ToString()) ? "" : rdr["doc_status_name"].ToString();
                    document.CreatorName = String.IsNullOrEmpty(rdr["creator_name"].ToString()) ? "" : rdr["creator_name"].ToString();
                    document.UpdatedName = String.IsNullOrEmpty(rdr["updated_name"].ToString()) ? "" : rdr["updated_name"].ToString();
                    listDocument.Add(document);
                }
                con.Close();
            }
            totalCount = listDocument.Count;
            return listDocument;
        }

        public List<DocumentModel> GetAllDocuments()
        {
            List<DocumentModel> listDocument = new List<DocumentModel>();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_GetAllDocument", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DocumentModel document = new DocumentModel();
                    document.DocumentID = Convert.ToInt32(rdr["document_ID"]);
                    document.DocumentTypeID = Convert.ToInt32(rdr["doc_type_ID"]);
                    document.DocumentName = rdr["document_name"].ToString();
                    document.VersionID = Convert.ToInt32(rdr["version_ID"]);
                    document.URL = rdr["url"].ToString();
                    document.Description = rdr["description"].ToString();
                    document.DocStatusID = Convert.ToInt32(rdr["doc_status_ID"]);
                    document.CreatorID = rdr["creator_ID"].ToString();
                    document.CreatedAt = String.IsNullOrEmpty(rdr["created_at"].ToString()) ? "" : rdr["created_at"].ToString();
                    document.UpdatedAt = String.IsNullOrEmpty(rdr["updated_at"].ToString()) ? "" : rdr["updated_at"].ToString();
                    document.UpdatedBy = String.IsNullOrEmpty(rdr["updated_by"].ToString()) ? "" : rdr["updated_by"].ToString();
                    document.DocTypeName = String.IsNullOrEmpty(rdr["doc_type_name"].ToString()) ? "" : rdr["doc_type_name"].ToString();
                    document.VersionName = String.IsNullOrEmpty(rdr["version_name"].ToString()) ? "" : rdr["version_name"].ToString();
                    document.DocStatusName = String.IsNullOrEmpty(rdr["doc_status_name"].ToString()) ? "" : rdr["doc_status_name"].ToString();
                    document.CreatorName = String.IsNullOrEmpty(rdr["creator_name"].ToString()) ? "" : rdr["creator_name"].ToString();
                    document.UpdatedName = String.IsNullOrEmpty(rdr["updated_name"].ToString()) ? "" : rdr["updated_name"].ToString();
                    listDocument.Add(document);
                }
                con.Close();
            }
            return listDocument;
        }

        public int InsertDocument(DocumentModel document, string userName)
        {
            int result = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string insert = "insert into document(document_old_ID,doc_type_ID,document_name,version_ID,url,description,doc_status_ID,creator_ID,created_at,updated_at,updated_by)" +
                        "values (@document_old_ID,@doc_type_ID,@document_name,@version_ID,@url,@description,@doc_status_ID,(select id from aspnetusers where username = '" + userName + "'),@created_at,@updated_at,(select id from aspnetusers where username = '" + userName + "'));select last_insert_id();";

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(insert, con);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@document_old_ID", document.DocumentOldID.ToString());
                    cmd.Parameters.AddWithValue("@doc_type_ID", document.DocumentTypeID.ToString());
                    cmd.Parameters.AddWithValue("@document_name", document.DocumentName.ToString());
                    cmd.Parameters.AddWithValue("@version_ID", document.VersionID.ToString());
                    cmd.Parameters.AddWithValue("@url", document.URL.ToString());
                    cmd.Parameters.AddWithValue("@description", document.Description.ToString());
                    cmd.Parameters.AddWithValue("@doc_status_ID", document.DocStatusID.ToString());
                    cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    result = int.Parse(cmd.ExecuteScalar().ToString());
                    //cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                result = 0;
            }
            finally
            {
                var json = JsonConvert.SerializeObject(document);
                ExceptionLogging.SendExcepToDB(json, "insert", userName);
            }


            return result;
        }

        public String UpdateDocument(DocumentModel document, string userName)
        {
            string result = "success";
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string insert = "update document set document_old_ID = @document_old_ID,doc_type_ID=@doc_type_ID,document_name=@document_name,version_ID=@version_ID,url=@url,description=@description,doc_status_ID=@doc_status_ID,updated_at=@updated_at,updated_by=(select id from aspnetusers where username = '" + userName + "') where document_ID = @document_id";

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(insert, con);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@document_ID", document.DocumentID.ToString());
                    cmd.Parameters.AddWithValue("@document_old_ID", document.DocumentOldID.ToString());
                    cmd.Parameters.AddWithValue("@doc_type_ID", document.DocumentTypeID.ToString());
                    cmd.Parameters.AddWithValue("@document_name", document.DocumentName.ToString());
                    cmd.Parameters.AddWithValue("@version_ID", document.VersionID.ToString());
                    cmd.Parameters.AddWithValue("@url", document.URL.ToString());
                    cmd.Parameters.AddWithValue("@description", document.Description.ToString());
                    cmd.Parameters.AddWithValue("@doc_status_ID", document.DocStatusID.ToString());
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
                StackTrace stackTrace = new StackTrace();
                var routeValues = System.Reflection.MethodBase.GetCurrentMethod().Name;
                String caller = stackTrace.GetFrame(1).GetMethod().Name.ToString();
                var json = JsonConvert.SerializeObject(document);
                ExceptionLogging.SendExcepToDB(json, "update", userName);
            }


            return result;
        }

        public DocumentModel GetDocumentByID(string documentID)
        {
            DocumentModel document = new DocumentModel();
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string query = "select \n\tdoc.document_ID,\n\tdoc.document_old_ID,\n\tdoc.doc_type_ID,\n\t(\n\t\tselect `name`\n\t\tfrom doc_type\n\t\twhere doc.doc_type_ID = doc_type_ID\n\t)  doc_type_name,\n\tdoc.document_name,\n\tdoc.version_ID,\n\t(\n\t\tselect version_name\n\t\tfrom version\n\t\twhere doc.version_ID = version_ID\n\t)  version_name,\n\tdoc.url,\n\tdoc.description,\n\tdoc.doc_status_ID,\n\t(\n\t\tselect doc_status_name\n\t\tfrom doc_status\n\t\twhere doc.doc_status_ID = doc_status_ID\n\t)  doc_status_name,\n\tdoc.creator_ID,\n\t(\n\t\tselect user_name\n\t\tfrom `user`\n\t\twhere doc.creator_ID = user_ID\n\t)  creator_name,\n\t\n\tdoc.created_at,\n\tdoc.updated_at,\n\tdoc.updated_by,\n\t(\n\t\tselect user_name\n\t\tfrom `user`\n\t\twhere doc.updated_by= user_ID\n\t) updated_name\nfrom  document doc where doc.document_id = '" + documentID + "'";

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        document.DocumentID = Convert.ToInt32(rdr["document_ID"]);
                        document.DocumentOldID = String.IsNullOrEmpty(rdr["document_old_ID"].ToString()) ? "" : rdr["document_old_ID"].ToString();
                        document.DocumentTypeID = Convert.ToInt32(rdr["doc_type_ID"]);
                        document.DocumentName = rdr["document_name"].ToString();
                        document.VersionID = Convert.ToInt32(rdr["version_ID"]);
                        document.URL = rdr["url"].ToString();
                        document.Description = rdr["description"].ToString();
                        document.DocStatusID = Convert.ToInt32(rdr["doc_status_ID"]);
                        document.CreatorID = rdr["creator_ID"].ToString();
                        document.CreatedAt = String.IsNullOrEmpty(rdr["created_at"].ToString()) ? "" : rdr["created_at"].ToString();
                        document.UpdatedAt = String.IsNullOrEmpty(rdr["updated_at"].ToString()) ? "" : rdr["updated_at"].ToString();
                        document.UpdatedBy = String.IsNullOrEmpty(rdr["updated_by"].ToString()) ? "" : rdr["updated_by"].ToString();
                        document.DocTypeName = String.IsNullOrEmpty(rdr["doc_type_name"].ToString()) ? "" : rdr["doc_type_name"].ToString();
                        document.VersionName = String.IsNullOrEmpty(rdr["version_name"].ToString()) ? "" : rdr["version_name"].ToString();
                        document.DocStatusName = String.IsNullOrEmpty(rdr["doc_status_name"].ToString()) ? "" : rdr["doc_status_name"].ToString();
                        document.CreatorName = String.IsNullOrEmpty(rdr["creator_name"].ToString()) ? "" : rdr["creator_name"].ToString();
                        document.UpdatedName = String.IsNullOrEmpty(rdr["updated_name"].ToString()) ? "" : rdr["updated_name"].ToString();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }


            return document;
        }
    }
}
