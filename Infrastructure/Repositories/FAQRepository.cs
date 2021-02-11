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
    public class FAQRepository : IFAQRepository
    {
        public SqlCommand cmd;
        //Constroctor
        public FAQRepository()
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
                cmd.CommandText = "delete from FAQs where id = " + Id.ToString();
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
                cmd.CommandText = "select * from FAQs";
                SqlDataReader myReader = cmd.ExecuteReader();
                List<FAQ> faq = new List<FAQ>();
                while (myReader.Read())
                {
                    FAQ objfaq = new FAQ();
                    objfaq.Id = Convert.ToInt32(myReader["id"]);
                    objfaq.Question = myReader["Question"].ToString();
                    objfaq.Answer = myReader["Answer"].ToString();
                    objfaq.UpdatedOn = Convert.ToDateTime(myReader["UpdatedOn"]);
                    objfaq.UpdatedBy = myReader["UpdatedBy"].ToString();
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
                cmd.CommandText = "select * from FAQs where id = " + Id.ToString();
                SqlDataReader myReader = cmd.ExecuteReader();
                FAQ objfaq = null;
                while (myReader.Read())
                {
                    objfaq = new FAQ();
                    objfaq.Id = Convert.ToInt32(myReader["id"]);
                    objfaq.Question = myReader["Question"].ToString();
                    objfaq.Answer = myReader["Answer"].ToString();
                    objfaq.UpdatedOn = Convert.ToDateTime(myReader["UpdatedOn"]);
                    objfaq.UpdatedBy = myReader["UpdatedBy"].ToString();
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
                cmd.CommandText = "insert into FAQs(Question, Answer,UpdatedOn,UpdatedBy ) values('" + objT.Question + "','" + objT.Answer + "','" + objT.UpdatedOn + "','" + objT.UpdatedBy + "')";

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
                cmd.CommandText = "update FAQs set Question = '" + objT.Question + "', Answer = '" + objT.Answer + "' ,UpdatedOn = '" + objT.UpdatedOn + "' ,UpdatedBy = '" + objT.UpdatedBy + "' where id =  '" + objT.Id + "'";
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