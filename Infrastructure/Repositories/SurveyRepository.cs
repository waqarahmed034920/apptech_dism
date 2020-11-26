using SurveyPortal.Infrastructure.Interface;
using SurveyPortal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SurveyPortal.Infrastructure.Repositories
{
    public class SurveyRepository : IRepository<Survey>
    {
        public SqlCommand cmd;
        public SurveyRepository()
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectionstring);
            cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
        }
        public bool Delete(int Id)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "delete from survey where id = " + Id.ToString();
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

        public List<Survey> GetAll()
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "select * from Survey";
                SqlDataReader myReader = cmd.ExecuteReader();
                List<Survey> lstSurvey = new List<Survey>();
                while (myReader.Read())
                {
                    Survey objSurvey = new Survey();
                    objSurvey.Id = Convert.ToInt32(myReader["id"]);
                    objSurvey.Name = myReader["Name"].ToString();
                    objSurvey.StartDate = Convert.ToDateTime(myReader["StartDate"]);
                    objSurvey.EndDate = Convert.ToDateTime(myReader["EndDate"]);
                    objSurvey.BackButton = Convert.ToBoolean(myReader["BackButton"]);
                    objSurvey.Reviewable = Convert.ToBoolean(myReader["Reviewable"]);
                    objSurvey.InternalOnly = Convert.ToBoolean(myReader["InternalOnly"]);
                    lstSurvey.Add(objSurvey);
                }
                myReader.Close();
                return lstSurvey;

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

        public Survey GetById(int Id)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "select * from Survey where id = " + Id.ToString();
                SqlDataReader myReader = cmd.ExecuteReader();
                Survey objSurvey = null;
                while (myReader.Read())
                {
                    objSurvey = new Survey();
                    objSurvey.Id = Convert.ToInt32(myReader["id"]);
                    objSurvey.Name = myReader["Name"].ToString();
                    objSurvey.StartDate = Convert.ToDateTime(myReader["StartDate"]);
                    objSurvey.EndDate = Convert.ToDateTime(myReader["EndDate"]);
                    objSurvey.BackButton = Convert.ToBoolean(myReader["BackButton"]);
                    objSurvey.Reviewable = Convert.ToBoolean(myReader["Reviewable"]);
                    objSurvey.InternalOnly = Convert.ToBoolean(myReader["InternalOnly"]);
                }
                myReader.Close();
                return objSurvey;

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

        public bool Insert(Survey objT)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "insert into Survey(name, startdate, enddate, BackButton, Reviewable, InternalOnly ) values('" + objT.Name + "','" + objT.StartDate + "','" + objT.EndDate + "', '" + objT.BackButton + "', '" + objT.Reviewable + "', '" + objT.InternalOnly + "')";

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

        public bool Update(Survey objT)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "update Survey set name = '" + objT.Name + 
                    "', StartDate = '" + objT.StartDate + 
                    "', endDate = '" + objT.EndDate +
                    "', BackButton= '" + objT.BackButton +
                    "', Reviewable= '" + objT.Reviewable +
                    "', InternalOnly= '" + objT.InternalOnly +
                    "' where id =  '" + objT.Id + "'";
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