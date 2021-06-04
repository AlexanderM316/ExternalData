using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using ExternalData.Models;
using Dapper;
namespace ExternalData.Repository
{
    public class RepositoryOrganization
    {
        //public static OrganizationDto GetOrganizationByINN(double INN)
        //{
        //    OrganizationDto organization = new OrganizationDto();
        //    string sql = $"Select * from Organization WHERE INN = '{INN}'";
        //    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OrgDB"].ConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand(sql, connection);
        //        command.Connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        organization.INN = INN;
        //        while (reader.Read())
        //        {
        //            organization.OID = reader.GetInt32(reader.GetOrdinal("ID"));
                    
        //        }
                
        //    }
        //    return organization;
            
        //}
        //public void Insert(OrganizationDto organization)
        //{

        //}
        

        
    }
}
