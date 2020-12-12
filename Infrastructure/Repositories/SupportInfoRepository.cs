using SurveyPortal.Infrastructure.Interface;
using SurveyPortal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SurveyPortal.Infrastructure.Repositories
{
    public class SupportInfoRepository : IRepository<SupportInfo>
    {
        public SqlCommand cmd;

        public SupportInfoRepository()
        {
            var conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
        }
        public bool Delete(int Id)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "delete from SupportInfoes where id = " + Id.ToString();
                int noOfRowsAffected = cmd.ExecuteNonQuery();
                if (noOfRowsAffected >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }

        }

        public List<SupportInfo> GetAll()
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "select * from SupportInfoes";
                SqlDataReader myReader = cmd.ExecuteReader();
                List<SupportInfo> supportInfo = new List<SupportInfo>();
                while (myReader.Read())
                {
                    SupportInfo objSupport = new SupportInfo();
                    objSupport.Id = Convert.ToInt32(myReader["id"]);
                    objSupport.Contact = myReader["Contact"].ToString();
                    objSupport.ShortDesc = myReader["ShortDesc"].ToString();
                    objSupport.Description = myReader["Description"].ToString();
                    objSupport.Email = myReader["Email"].ToString();
                    objSupport.Phone = myReader["Phone"].ToString();
                    objSupport.WhatsApp = myReader["WhatsApp"].ToString();
                    objSupport.SkypeId = myReader["SkypeId"].ToString();
                    objSupport.WebAddress = myReader["WebAddress"].ToString();
                    supportInfo.Add(objSupport);
                }
                myReader.Close();
                return supportInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public SupportInfo GetById(int Id)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "select * from Supportinfoes where id = " + Id.ToString();
                SqlDataReader myReader = cmd.ExecuteReader();
                SupportInfo objSupport = null;
                while (myReader.Read())
                {
                    objSupport = new SupportInfo();
                    objSupport.Id = Convert.ToInt32(myReader["id"]);
                    objSupport.Contact = myReader["Contact"].ToString();
                    objSupport.ShortDesc = myReader["ShortDesc"].ToString();
                    objSupport.Description = myReader["Description"].ToString();
                    objSupport.Email = myReader["Email"].ToString();
                    objSupport.Phone = myReader["Phone"].ToString();
                    objSupport.WhatsApp = myReader["WhatsApp"].ToString();
                    objSupport.SkypeId = myReader["SkypeId"].ToString();
                    objSupport.WebAddress = myReader["WebAddress"].ToString();
                }
                myReader.Close();
                return objSupport;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public bool Insert(SupportInfo objT)
        {
            try
            {
                string query = "insert into supportinfoes(contact, shortDesc, Description, email, phone, whatsApp, skypeId, webAddress) values(";
                query += "'" + objT.Contact + "',";
                query += "'" + objT.ShortDesc + "',";
                query += "'" + objT.Description + "',";
                query += "'" + objT.Email + "',";
                query += "'" + objT.Phone + "',";
                query += "'" + objT.WhatsApp + "',";
                query += "'" + objT.SkypeId + "',";
                query += "'" + objT.WebAddress + "')";
                cmd.Connection.Open();
                cmd.CommandText = query;

                int noOfRowsAffected = cmd.ExecuteNonQuery();
                if (noOfRowsAffected >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public bool Update(SupportInfo objT)
        {
            try
            {
                string query = "update supportInfoes set ";
                query += "Contact = '" + objT.Contact + "',";
                query += "ShortDesc = '" + objT.ShortDesc + "',";
                query += "Description = '" + objT.Description + "',";
                query += "Email = '" + objT.Email + "',";
                query += "Phone = '" + objT.Phone + "',";
                query += "WhatsApp = '" + objT.WhatsApp + "',";
                query += "SkypeId = '" + objT.SkypeId + "',";
                query += "WebAddress = '" + objT.WebAddress + "' ";
                query += "where Id = " + objT.Id;
                cmd.Connection.Open();
                cmd.CommandText = query;
                int noOfRowsAffected = cmd.ExecuteNonQuery();
                if (noOfRowsAffected >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }
}