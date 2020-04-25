using System;
using System.Collections.Generic;
using System.Data;
using IMS_2019.Models;
using IMS_2019.Util;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace IMS_2019.DAL
{
    public class MenuDAL
    {
        string connectionString = "Server=42.113.206.229;port=3306; Database=ims;User=vantt2;password=topica@123;";
        public List<DocStatusModel> GetAllDocStatus()
        {
            List<DocStatusModel> listDocument = new List<DocStatusModel>();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from doc_status;", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DocStatusModel document = new DocStatusModel();
                    document.DocStatusID = Convert.ToInt32(rdr["doc_status_ID"]);
                    document.DocStatusName = String.IsNullOrEmpty(rdr["doc_status_name"].ToString()) ? "" : rdr["doc_status_name"].ToString();
                    document.DocStatusDescription = String.IsNullOrEmpty(rdr["doc_status_description"].ToString()) ? "" : rdr["doc_status_description"].ToString();
                    document.CreatedBy = Convert.ToInt32(String.IsNullOrEmpty(rdr["created_by"].ToString()) ? "0" : rdr["created_by"].ToString());
                    document.UpdatedBy = Convert.ToInt32(String.IsNullOrEmpty(rdr["updated_by"].ToString()) ? "0" : rdr["updated_by"].ToString());
                    document.CreatedAt = String.IsNullOrEmpty(rdr["created_at"].ToString()) ? "" : rdr["created_at"].ToString();
                    document.UpdatedAt = String.IsNullOrEmpty(rdr["updated_at"].ToString()) ? "" : rdr["updated_at"].ToString();

                    listDocument.Add(document);
                }
                con.Close();
            }
            return listDocument;
        }


        public List<DocTypeModel> GetAllDocType()
        {
            List<DocTypeModel> listDocument = new List<DocTypeModel>();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from doc_type", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DocTypeModel document = new DocTypeModel();
                    document.DocTypeID = Convert.ToInt32(rdr["doc_type_ID"]);
                    document.Name = String.IsNullOrEmpty(rdr["name"].ToString()) ? "" : rdr["name"].ToString();
                    document.Description = String.IsNullOrEmpty(rdr["description"].ToString()) ? "" : rdr["description"].ToString();
                    document.CreatedBy = Convert.ToInt32(String.IsNullOrEmpty(rdr["created_by"].ToString()) ? "0" : rdr["created_by"].ToString());
                    document.UpdatedBy = Convert.ToInt32(String.IsNullOrEmpty(rdr["updated_by"].ToString()) ? "0" : rdr["updated_by"].ToString());
                    document.CreatedAt = String.IsNullOrEmpty(rdr["created_at"].ToString()) ? "" : rdr["created_at"].ToString();
                    document.UpdatedAt = String.IsNullOrEmpty(rdr["updated_at"].ToString()) ? "" : rdr["updated_at"].ToString();

                    listDocument.Add(document);
                }
                con.Close();
            }
            return listDocument;
        }

        public IEnumerable<IssStatusModel> GetAllIssStatusTest()
        {
            List<IssStatusModel> listDocument = new List<IssStatusModel>();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from iss_status", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    IssStatusModel document = new IssStatusModel();
                    document.IssStatusID = Convert.ToInt32(rdr["iss_status_ID"]);
                    document.IssStatusName = String.IsNullOrEmpty(rdr["iss_status_name"].ToString()) ? "" : rdr["iss_status_name"].ToString();
                    document.IssStatusDescription = String.IsNullOrEmpty(rdr["iss_status_description"].ToString()) ? "" : rdr["iss_status_description"].ToString();
                    document.CreatedBy = Convert.ToInt32(String.IsNullOrEmpty(rdr["created_by"].ToString()) ? "0" : rdr["created_by"].ToString());
                    document.UpdatedBy = Convert.ToInt32(String.IsNullOrEmpty(rdr["updated_by"].ToString()) ? "0" : rdr["updated_by"].ToString());
                    document.CreatedAt = String.IsNullOrEmpty(rdr["created_at"].ToString()) ? "" : rdr["created_at"].ToString();
                    document.UpdatedAt = String.IsNullOrEmpty(rdr["updated_at"].ToString()) ? "" : rdr["updated_at"].ToString();

                    listDocument.Add(document);
                    yield return document;
                }
                con.Close();
            }
            //return listDocument;
        }

        public List<IssStatusModel> GetAllIssStatus()
        {
            List<IssStatusModel> listDocument = new List<IssStatusModel>();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from iss_status", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    IssStatusModel document = new IssStatusModel();
                    document.IssStatusID = Convert.ToInt32(rdr["iss_status_ID"]);
                    document.IssStatusName = String.IsNullOrEmpty(rdr["iss_status_name"].ToString()) ? "" : rdr["iss_status_name"].ToString();
                    document.IssStatusDescription = String.IsNullOrEmpty(rdr["iss_status_description"].ToString()) ? "" : rdr["iss_status_description"].ToString();
                    document.CreatedBy = Convert.ToInt32(String.IsNullOrEmpty(rdr["created_by"].ToString()) ? "0" : rdr["created_by"].ToString());
                    document.UpdatedBy = Convert.ToInt32(String.IsNullOrEmpty(rdr["updated_by"].ToString()) ? "0" : rdr["updated_by"].ToString());
                    document.CreatedAt = String.IsNullOrEmpty(rdr["created_at"].ToString()) ? "" : rdr["created_at"].ToString();
                    document.UpdatedAt = String.IsNullOrEmpty(rdr["updated_at"].ToString()) ? "" : rdr["updated_at"].ToString();

                    listDocument.Add(document);
                }
                con.Close();
            }
            return listDocument;
        }

        public List<GroupModel> GetAllGroup()
        {
            List<GroupModel> listDocument = new List<GroupModel>();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from `group`;", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    GroupModel document = new GroupModel();
                    document.GroupID = Convert.ToInt32(rdr["group_ID"]);
                    document.UserGroupID = String.IsNullOrEmpty(rdr["user_group_ID"].ToString()) ? "" : rdr["user_group_ID"].ToString();
                    document.GroupName = String.IsNullOrEmpty(rdr["group_name"].ToString()) ? "" : rdr["group_name"].ToString();
                    document.GroupDescription = String.IsNullOrEmpty(rdr["group_description"].ToString()) ? "" : rdr["group_description"].ToString();
                    document.CreatedBy = Convert.ToInt32(String.IsNullOrEmpty(rdr["created_by"].ToString()) ? "0" : rdr["created_by"].ToString());
                    document.UpdatedBy = Convert.ToInt32(String.IsNullOrEmpty(rdr["updated_by"].ToString()) ? "0" : rdr["updated_by"].ToString());
                    document.CreatedAt = String.IsNullOrEmpty(rdr["created_at"].ToString()) ? "" : rdr["created_at"].ToString();
                    document.UpdatedAt = String.IsNullOrEmpty(rdr["updated_at"].ToString()) ? "" : rdr["updated_at"].ToString();

                    listDocument.Add(document);
                }
                con.Close();
            }
            return listDocument;
        }

        public List<VersionModel> GetAllVersion()
        {
            List<VersionModel> listDocument = new List<VersionModel>();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from version;", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    VersionModel document = new VersionModel();
                    document.VersionID = Convert.ToInt32(rdr["version_ID"]);
                    document.VersionName = String.IsNullOrEmpty(rdr["version_name"].ToString()) ? "" : rdr["version_name"].ToString();
                    document.VersionDescription = String.IsNullOrEmpty(rdr["version_description"].ToString()) ? "" : rdr["version_description"].ToString();
                    document.CreatedBy = String.IsNullOrEmpty(rdr["created_by"].ToString()) ? "0" : rdr["created_by"].ToString();
                    document.UpdatedBy = String.IsNullOrEmpty(rdr["updated_by"].ToString()) ? "0" : rdr["updated_by"].ToString();
                    document.CreatedAt = String.IsNullOrEmpty(rdr["created_at"].ToString()) ? "" : rdr["created_at"].ToString();
                    document.UpdatedAt = String.IsNullOrEmpty(rdr["updated_at"].ToString()) ? "" : rdr["updated_at"].ToString();

                    listDocument.Add(document);
                }
                con.Close();
            }
            return listDocument;
        }

        public List<UserModel> GetAllUser()
        {
            List<UserModel> listDocument = new List<UserModel>();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from `user`;", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    UserModel document = new UserModel();
                    document.UserID = Convert.ToInt32(rdr["user_ID"]);
                    document.UserGroupID = Convert.ToInt32(String.IsNullOrEmpty(rdr["user_group_ID"].ToString()) ? "0" : rdr["user_group_ID"].ToString());
                    document.UserName = String.IsNullOrEmpty(rdr["user_name"].ToString()) ? "" : rdr["user_name"].ToString();
                    document.UserEmail = String.IsNullOrEmpty(rdr["user_email"].ToString()) ? "" : rdr["user_email"].ToString();
                    document.UserPhone = String.IsNullOrEmpty(rdr["user_phone"].ToString()) ? "" : rdr["user_phone"].ToString();
                    document.CreatedBy = Convert.ToInt32(String.IsNullOrEmpty(rdr["created_by"].ToString()) ? "0" : rdr["created_by"].ToString());
                    document.UpdatedBy = Convert.ToInt32(String.IsNullOrEmpty(rdr["updated_by"].ToString()) ? "0" : rdr["updated_by"].ToString());
                    document.CreatedAt = String.IsNullOrEmpty(rdr["created_at"].ToString()) ? "" : rdr["created_at"].ToString();
                    document.UpdatedAt = String.IsNullOrEmpty(rdr["updated_at"].ToString()) ? "" : rdr["updated_at"].ToString();

                    listDocument.Add(document);
                }
                con.Close();
            }
            return listDocument;
        }

        // Check version exists
        public int ExistsOrInsertVersion(DocumentModel document, string actionUser)
        {
            DocumentDAL documentDAL = new DocumentDAL();
            MenuDAL menuDAL = new MenuDAL();
            int count = 0;
            int countVersion = 0;
            List<VersionModel> listDocument = new List<VersionModel>();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_GetVersionByName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Add("@version_name", MySqlDbType.VarChar).Value = document.VersionName;
                countVersion = int.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
            }
            if (countVersion <= 0)
            {
                // Insert to new version
                VersionModel versionModel = new VersionModel();
                versionModel.VersionName = document.VersionName;
                versionModel.VersionDescription = "Auto insert version";
                versionModel.CreatedBy = actionUser;
                versionModel.UpdatedBy = actionUser;

                int versionID = this.InsertVersion(versionModel);

                if (versionID >= 0)
                {
                    // insert document here
                    document.VersionID = versionID;
                    return documentDAL.InsertDocument(document, actionUser);
                }
                else
                {
                    return count;
                }
            }
            else
            {
                return documentDAL.InsertDocument(document, actionUser);
            }
        }

        public int InsertVersion(VersionModel versionModel)
        {
            int insertedID = 0;
            List<VersionModel> listDocument = new List<VersionModel>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("sp_InsertVerion", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.Add("@version_name", MySqlDbType.VarChar).Value = versionModel.VersionName;
                    cmd.Parameters.Add("@version_description", MySqlDbType.VarChar).Value = versionModel.VersionDescription;
                    cmd.Parameters.Add("@created_by", MySqlDbType.VarChar).Value = versionModel.CreatedBy;
                    cmd.Parameters.Add("@updated_by", MySqlDbType.VarChar).Value = versionModel.UpdatedBy;
                    insertedID = int.Parse(cmd.ExecuteScalar().ToString());
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                var json = JsonConvert.SerializeObject(versionModel);
                ExceptionLogging.SendExcepToDB(json, "insert", versionModel.CreatedBy);
            }
           
            return insertedID;
        }
    }
}
