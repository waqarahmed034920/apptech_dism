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
    public class SurveyQuestionRepository : ISurveyQuestion
    {
        public SqlCommand cmd;
        public SurveyQuestionRepository()
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
                cmd.CommandText = "delete from SurveyQuestions where id = " + Id.ToString();
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

        public List<SurveyQuestion> GetAll()
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "select * from SurveyQuestions";
                SqlDataReader myReader = cmd.ExecuteReader();
                List<SurveyQuestion> SurveyQuestion = new List<SurveyQuestion>();
                while (myReader.Read())
                {
                    SurveyQuestion objSurveyQuestion = new SurveyQuestion();
                    objSurveyQuestion.Id = Convert.ToInt32(myReader["id"]);
                    objSurveyQuestion.SurveyId = Convert.ToInt32( myReader["SurveyId"].ToString());
                    objSurveyQuestion.Question = myReader["Question"].ToString();
                    objSurveyQuestion.OptionTypeId = Convert.ToInt32(myReader["OptionTypeId"].ToString());
                    objSurveyQuestion.NoOfOptions = Convert.ToInt32(myReader["NoOfOptions"].ToString());
                    objSurveyQuestion.Options = (myReader["Options"].ToString());
                    SurveyQuestion.Add(objSurveyQuestion);
                }
                myReader.Close();
                return SurveyQuestion;

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

        public SurveyQuestion GetById(int Id)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "select * from SurveyQuestions where id = " + Id.ToString();
                SqlDataReader myReader = cmd.ExecuteReader();
                SurveyQuestion objsurveyquestion = null;
                while (myReader.Read())
                {
                    objsurveyquestion = new SurveyQuestion();
                    objsurveyquestion.Id = Convert.ToInt32(myReader["id"]);
                    objsurveyquestion.SurveyId = Convert.ToInt32(myReader["SurveyId"].ToString());
                    objsurveyquestion.Question = myReader["Question"].ToString();
                    objsurveyquestion.OptionTypeId = Convert.ToInt32(myReader["OptionTypeId"].ToString());
                    objsurveyquestion.NoOfOptions = Convert.ToInt32(myReader["NoOfOptions"].ToString());
                    objsurveyquestion.Options = (myReader["Options"].ToString());
                }
                myReader.Close();
                return objsurveyquestion;

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

        public List<SurveyQuestion> GetQuestionsBySurveyId(int SurveyId)
        {
            try
            {
                string query = "select SQ.Id, SQ.SurveyId, SQ.Question, SQ.OptionTypeId, ";
                query += "SQ.Options, SQ.NoOfOptions, OT.Name AS OptionTypeName from SurveyQuestions SQ ";
                query += "inner join OptionTypes OT ON SQ.OptionTypeId = OT.Id ";
                query += "where SQ.SurveyId = " + SurveyId.ToString();

                cmd.Connection.Open();
                cmd.CommandText = query;

                SqlDataReader myReader = cmd.ExecuteReader();
                List<SurveyQuestion> SurveyQuestion = new List<SurveyQuestion>();

                while (myReader.Read())
                {
                    SurveyQuestion objSurveyQuestion = new SurveyQuestion();
                    objSurveyQuestion.Id = Convert.ToInt32(myReader["id"]);
                    objSurveyQuestion.SurveyId = Convert.ToInt32(myReader["SurveyId"].ToString());
                    objSurveyQuestion.Question = myReader["Question"].ToString();
                    objSurveyQuestion.OptionTypeName = myReader["OptionTypeName"].ToString();
                    objSurveyQuestion.OptionTypeId = Convert.ToInt32(myReader["OptionTypeId"].ToString());
                    objSurveyQuestion.NoOfOptions = Convert.ToInt32(myReader["NoOfOptions"].ToString());
                    objSurveyQuestion.Options = (myReader["Options"].ToString());
                    SurveyQuestion.Add(objSurveyQuestion);
                }
                myReader.Close();
                return SurveyQuestion;
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

        public bool Insert(SurveyQuestion objT)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "insert into SurveyQuestions(SurveyId, Question, OptionTypeId, NoOfOptions, Options ) values('" + objT.SurveyId + "','" + objT.Question + "','" + objT.OptionTypeId + "', '" + objT.NoOfOptions+ "', '" + objT.Options+ "')";

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

        public bool Update(SurveyQuestion objT)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "update SurveyQuestions set SurveyId = '" + objT.SurveyId+
                    "', Question = '" + objT.Question +
                    "', OptionTypeId = '" + objT.OptionTypeId +
                    "', NoOfOptions= '" + objT.NoOfOptions +
                    "', Options= '" + objT.Options +
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