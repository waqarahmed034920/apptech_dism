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
    public class CompetitionRepository : ICompetition
    {
        public SqlCommand cmd;
        public CompetitionRepository()
        {
            var conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
        }

        public Competition GetCurrentCompetition()
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "SELECT c.*, s.Name, s.Description FROM Competitions AS C inner join Surveys AS S ON c.SurveyId = s.Id";
                SqlDataReader myReader = cmd.ExecuteReader();
                Competition objCompetition = new Competition();
                while (myReader.Read())
                {
                    objCompetition.Id = Convert.ToInt32(myReader["id"]);
                    objCompetition.Introduction = myReader["Introduction"].ToString();
                    objCompetition.Details = myReader["Details"].ToString();
                    objCompetition.StartDate = Convert.ToDateTime(myReader["StartDate"]);
                    objCompetition.EndDate = Convert.ToDateTime(myReader["EndDate"]);
                    objCompetition.RoleId = Convert.ToInt32(myReader["RoleId"].ToString());
                    objCompetition.SurveyId = Convert.ToInt32(myReader["SurveyId"]);
                    objCompetition.SurveyName = myReader["Name"].ToString();
                    objCompetition.SurveyDescription = myReader["Description"].ToString();
                }
                myReader.Close();
                return objCompetition;
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
        public bool Delete(int Id)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "delete from Competitions where id = " + Id.ToString();
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

        public List<Competition> GetAll()
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "SELECT c.*, s.Name, s.Description FROM Competitions AS C inner join Surveys AS S ON c.SurveyId = s.Id";
                SqlDataReader myReader = cmd.ExecuteReader();
                List<Competition> competition = new List<Competition>();
                while (myReader.Read())
                {
                    Competition objCompetition = new Competition();
                    objCompetition.Id = Convert.ToInt32(myReader["id"]);
                    objCompetition.Introduction = myReader["Introduction"].ToString();
                    objCompetition.Details = myReader["Details"].ToString();
                    objCompetition.SurveyId = Convert.ToInt32(myReader["SurveyId"]);
                    objCompetition.SurveyName  = myReader["Name"].ToString();
                    objCompetition.SurveyDescription = myReader["Description"].ToString();
                    objCompetition.StartDate = Convert.ToDateTime(myReader["StartDate"]);
                    objCompetition.EndDate = Convert.ToDateTime(myReader["EndDate"]);
                    objCompetition.RoleId = Convert.ToInt32(myReader["RoleId"].ToString());
                    competition.Add(objCompetition);
                }
                myReader.Close();
                return competition;
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

        public Competition GetById(int Id)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "SELECT c.*, s.Name, s.Description FROM Competitions AS C inner join Surveys AS S ON c.SurveyId = s.Id where c.id = " + Id.ToString();
                SqlDataReader myReader = cmd.ExecuteReader();
                Competition objCompetition = new Competition();
                while (myReader.Read())
                {
                    objCompetition.Id = Convert.ToInt32(myReader["id"]);
                    objCompetition.Introduction = myReader["Introduction"].ToString();
                    objCompetition.Details = myReader["Details"].ToString();
                    objCompetition.StartDate = Convert.ToDateTime(myReader["StartDate"]);
                    objCompetition.EndDate = Convert.ToDateTime(myReader["EndDate"]);
                    objCompetition.RoleId = Convert.ToInt32(myReader["RoleId"].ToString());
                    objCompetition.SurveyId = Convert.ToInt32(myReader["SurveyId"]);
                    objCompetition.SurveyName = myReader["Name"].ToString();
                    objCompetition.SurveyDescription = myReader["Description"].ToString();
                }
                myReader.Close();
                return objCompetition;
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

        public bool Insert(Competition objT)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "Insert into Competitions(SurveyId, introduction, details, startdate, enddate, roleid) values('" + objT.SurveyId + "', '" + objT.Introduction + "','" + objT.Details + "','" + objT.StartDate + "','" + objT.EndDate + "', '"+ objT.RoleId +"')";

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

        public bool Update(Competition objT)
        {
            try
            {
                string query = "update Competitions set introduction = '"+ objT.Introduction +"', ";
                query += "details = '" + objT.Details + "',";
                query += "StartDate = '" + objT.StartDate + "',";
                query += "EndDate = '" + objT.EndDate + "',";
                query += "RoleId = '" + objT.RoleId + "', ";
                query += "SurveyId = '" + objT.SurveyId + "' ";
                query += "Where Id = '" + objT.Id + "'";
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