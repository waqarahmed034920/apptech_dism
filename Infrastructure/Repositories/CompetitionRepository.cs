using SurveyPortal.Infrastructure.Interface;
using SurveyPortal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SurveyPortal.Infrastructure.Repositories
{
    public class CompetitionRepository : IRepository<Competition>
    {
        public SqlCommand cmd;
        public CompetitionRepository()
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
                cmd.CommandText = "delete from Competition where id = " + Id.ToString();
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
                cmd.CommandText = "select * from Competition";
                SqlDataReader myReader = cmd.ExecuteReader();
                List<Competition> competition = new List<Competition>();
                while (myReader.Read())
                {
                    Competition objCompetition = new Competition();
                    objCompetition.Id = Convert.ToInt32(myReader["id"]);
                    objCompetition.Introduction = myReader["Introduction"].ToString();
                    objCompetition.Details = myReader["Details"].ToString();
                    objCompetition.StartDate = Convert.ToDateTime(myReader["StartDate"]);
                    objCompetition.EndDate = Convert.ToDateTime(myReader["EndDate"]);
                    objCompetition.Role = Convert.ToInt32(myReader["Role"].ToString());
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
                cmd.CommandText = "select * from Competition";
                SqlDataReader myReader = cmd.ExecuteReader();
                Competition objCompetition = new Competition();
                while (myReader.Read())
                {
                    objCompetition.Id = Convert.ToInt32(myReader["id"]);
                    objCompetition.Introduction = myReader["Introduction"].ToString();
                    objCompetition.Details = myReader["Details"].ToString();
                    objCompetition.StartDate = Convert.ToDateTime(myReader["StartDate"]);
                    objCompetition.EndDate = Convert.ToDateTime(myReader["EndDate"]);
                    objCompetition.Role = Convert.ToInt32(myReader["Role"].ToString());
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
                cmd.CommandText = "insert into Competition(Introcution, details, startdate, enddate, role) values('" + objT.Introduction + "','" + objT.Details + "','" + objT.StartDate + "','" + objT.EndDate + "', '"+ objT.Role +"')";

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
                string query = "update Competition set introduction = '"+ objT.Introduction +"', ";
                query += "details = '" + objT.Details + "',";
                query += "StartDate = '" + objT.StartDate + "',";
                query += "EndDate = '" + objT.EndDate + "',";
                query += "Rolr = '" + objT.Role + "' ";
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