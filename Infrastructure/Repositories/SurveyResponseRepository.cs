using SurveyPortal.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SurveyPortal.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SurveyPortal.Infrastructure.Repositories
{
    public class SurveyResponseRepository : IRepository<SurveyResponse>
    {
        public SqlCommand cmd;
        public SurveyResponseRepository()
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
                cmd.CommandText = "delete from surveyResponse where id = " + Id.ToString();
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

        public List<SurveyResponse> GetAll()
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "select * from Tasks";
                SqlDataReader myReader = cmd.ExecuteReader();
                List<SurveyResponse> lstSurveyResponse = new List<SurveyResponse>();
                while (myReader.Read())
                {
                    SurveyResponse objSurveyResponse = new SurveyResponse();
                    objSurveyResponse.Id = Convert.ToInt32(myReader["id"]);
                    objSurveyResponse.UserId = myReader["UserId"].ToString();
                    objSurveyResponse.ResponseDate = Convert.ToDateTime(myReader["description"]);
                    objSurveyResponse.Response = myReader["Response"].ToString();
                    lstSurveyResponse.Add(objSurveyResponse);
                }
                myReader.Close();
                return lstSurveyResponse;
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

        public SurveyResponse GetById(int Id)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "select * from SurveyResponse where id = " + Id.ToString();
                SqlDataReader myReader = cmd.ExecuteReader();
                SurveyResponse objSurveyResponse = null;
                while (myReader.Read())
                {
                    objSurveyResponse = new SurveyResponse();
                    objSurveyResponse.Id = Convert.ToInt32(myReader["id"]);
                    objSurveyResponse.UserId = myReader["UserId"].ToString();
                    objSurveyResponse.ResponseDate = Convert.ToDateTime(myReader["description"]);
                    objSurveyResponse.Response = myReader["Response"].ToString();
                }
                myReader.Close();
                return objSurveyResponse;
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

        public bool Insert(SurveyResponse objT)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "insert into SurveyResponse(userid,ResponseDate,Response) values('" + objT.UserId + "','" + objT.ResponseDate + "','" + objT.Response + "')";

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

        public bool Update(SurveyResponse objT)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "update SurveyResponse set userid = '" + objT.UserId + "', ResponseDate = '" + objT.ResponseDate + "', Response = '" + objT.Response + "' where id =  '" + objT.Id + "'";
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