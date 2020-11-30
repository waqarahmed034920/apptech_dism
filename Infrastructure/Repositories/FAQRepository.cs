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
    public class FAQRepository : IRepository<FAQ>
    {
        public SqlCommand cmd;
        //Constroctor
        public FAQRepository()
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
                cmd.CommandText = "delete from FAQ where id = " + Id.ToString();
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

        public List<FAQ> GetAll()
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "select * from FAQ";
                SqlDataReader myReader = cmd.ExecuteReader();
                List<FAQ> faq = new List<FAQ>();
                while (myReader.Read())
                {
                    FAQ objfaq = new FAQ();
                    objfaq.Id = Convert.ToInt32(myReader["id"]);
                    objfaq.Question = myReader["Question"].ToString();
                    objfaq.Answer = myReader["Answer"].ToString();
                    objfaq.UpdateOn = Convert.ToDateTime(myReader["UpdateOn"]);
                    objfaq.UpdateBy = myReader["UpdateBy"].ToString();
                    faq.Add(objfaq);
                }
                myReader.Close();
                return faq;
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

        public FAQ GetById(int Id)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "select * from FAQ where id = " + Id.ToString(); ;
                SqlDataReader myReader = cmd.ExecuteReader();
                FAQ objfaq = null;
                while (myReader.Read())

                {
                    objfaq = new FAQ();
                    objfaq.Id = Convert.ToInt32(myReader["id"]);
                    objfaq.Question = myReader["Question"].ToString();
                    objfaq.Answer = myReader["Answer"].ToString();
                    objfaq.UpdateOn = Convert.ToDateTime(myReader["UpdateOn"]);
                    objfaq.UpdateBy = myReader["UpdateBy"].ToString();
                }
                myReader.Close();
                return objfaq;
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

        public bool Insert(FAQ objT)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "insert into FAQ(Question, Answer,UpdateOn,UpdateBy ) values('" + objT.Question + "','" + objT.Answer + "','" + objT.UpdateOn + "','" + objT.UpdateBy + "')";

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

        public bool Update(FAQ objT)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "update FAQ set Question = '" + objT.Question + "', Answer = '" + objT.Answer + "' ,UpdateOn = '" + objT.UpdateOn + "' ,UpdateBy = '" + objT.UpdateBy + "' where id =  '" + objT.Id + "'";
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