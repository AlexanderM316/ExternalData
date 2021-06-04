using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ExternalData.Models;

namespace ExternalData.Repository
{
    public class RepositoryOrgRating
    {
        public static OrgRating orgRating(int Org_ID)
        {
            OrgRating orgRating = new OrgRating();
            string sql = $"Select * from Organization WHERE Org_Rating = '{Org_ID}'";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OrgDB"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                orgRating.Org_ID = Org_ID;
                //while (reader.Read())
                //{
                //    orgRating.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                //    orgRating

                //}

            }
            return orgRating;
        }
        public void Insert(OrgRating orgRating)
        {

        }
        public void Update(OrgRating orgRating)
        {

        }
        
    }
}
