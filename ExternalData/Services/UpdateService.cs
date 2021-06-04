using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ExternalData.Models;
using ExternalData.Repository;

namespace ExternalData.Services
{
    public class UpdateService
    {
        public static string GetCSV()
        {
            string url = "CSVfile.csv";//"Http://example.csv";


            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            //HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            //StreamReader sr = new StreamReader(resp.GetResponseStream());
            //using (var reader = new StreamReader(url))
            //{
            //    List<OrgRating> orgRatings = new List<OrgRating>();
            //    List<OrganizationDto> organizations = new List<OrganizationDto>();
            //    while (!reader.EndOfStream)
            //    {
            //        OrganizationDto organization = new OrganizationDto();
            //        OrgRating orgRating = new OrgRating();
            //        var line = reader.ReadLine();
            //        var values = line.Split(';');

            //        organization.INN = double.Parse(values[0]);
            //        orgRating.Rating = decimal.Parse(values[1]);
            //        organizations.Add(organization);
            //        orgRatings.Add(orgRating);
            //    }
                //foreach(Organization org in organizations)
                //{
                //    if(!(RepositoryOrganization.GetOrganizationByINN == null))
                //    {

                //    }
                //}
            //}
            //string results = sr.ReadToEnd();
                //sr.Close();

                return null;
           
        }
        public static List<string> SplitCSV()
        {
            List<string> splitted = new List<string>();
            string file = GetCSV();
            string[] tempStr;

            tempStr = file.Split(';');

            foreach (string item in tempStr)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    splitted.Add(item);
                }
            }
            return splitted;
        }
        public static void UpdateDB()
        {
            List<OrgRating> orgRatings = new List<OrgRating>();
            List<Organization> organizations = new List<Organization>();

            List<string> data = SplitCSV();
            foreach(string d in data)
            {
                Organization organization = new Organization();
                OrgRating orgRating = new OrgRating();
                
            }
        }
    }
}
