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
    public class OptionTypeRepository : IRepository<OptionType>
    {
        public SqlCommand cmd;
        public OptionTypeRepository()
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
                cmd.CommandText = "delete from OptionType where id = " + Id.ToString();
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

        public List<OptionType> GetAll()
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "select * from OptionType";
                SqlDataReader myReader = cmd.ExecuteReader();
                List<OptionType> lstOptionType = new List<OptionType>();
                while (myReader.Read())
                {
                    OptionType objOptionType = new OptionType();
                    objOptionType.Id = Convert.ToInt32(myReader["id"]);
                    objOptionType.Name = myReader["Name"].ToString();
                    objOptionType.Description = myReader["Description"].ToString();
                    lstOptionType.Add(objOptionType);
                }
                myReader.Close();
                return lstOptionType;
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

        public OptionType GetById(int Id)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "select * from OptionType where id = " + Id.ToString();
                SqlDataReader myReader = cmd.ExecuteReader();
                OptionType objOptionType = null;
                while (myReader.Read())
                {
                     objOptionType = new OptionType();
                    objOptionType.Id = Convert.ToInt32(myReader["id"]);
                    objOptionType.Name = myReader["Name"].ToString();
                    objOptionType.Description = myReader["Description"].ToString();
                }
                myReader.Close();
                return objOptionType;
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

        public bool Insert(OptionType objT)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "insert into OptionType(Name, Description ) values('" + objT.Name + "','" + objT.Description +  "')";

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

        public bool Update(OptionType objT)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "update OptionType set name = '" + objT.Name +"', Description = '" + objT. Description + "' where id =  '" + objT.Id + "'";
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