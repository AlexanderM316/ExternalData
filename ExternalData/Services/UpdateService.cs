using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ExternalData.Models;
using ExternalData.Repository;
using ExternalData.Repository.IRepository;

namespace ExternalData.Services
{
    public class UpdateService
    {

        public IOrgRatingRepository _orgRatingRepo;
        public IOrganizationRepository _organization;
        public UpdateService(IOrgRatingRepository orgRatingRepository, IOrganizationRepository organizationRepository )
        {
            _orgRatingRepo = orgRatingRepository;
            _organization = organizationRepository;
        }
        public async Task UpdateDB()
        {
            
            
            string url = "Http://example.csv";//"Http://example.csv";

            
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                if (!(resp == null))
                {
                    List<OrgRating> orgRatings = new List<OrgRating>();
                    List<Organization> organizations = new List<Organization>();
                    StreamReader sr = new StreamReader(resp.GetResponseStream());
                    using (var reader = new StreamReader(url))
                    {

                        while (!reader.EndOfStream)
                        {
                            Organization organization = new Organization();
                            OrgRating orgRating = new OrgRating();
                            var line = reader.ReadLine();
                            var values = line.Split(';');

                            organization.INN = double.Parse(values[0]);
                            orgRating.Rating = decimal.Parse(values[1]);
                            organizations.Add(organization);
                            orgRatings.Add(orgRating);
                        }
                        //foreach (Organization org in organizations)
                        //{
                        //    if (!(RepositoryOrganization. == null))
                        //    {

                        //    }
                        //}
                    }
                    string results = sr.ReadToEnd();
                    sr.Close();
                    foreach (Organization org in organizations)
                    {
                        if (_organization.OrganizationExists(org.INN))
                        {
                            var orgObj = _organization.GetOrganizationByINN(org.INN);
                            var orgRating = _orgRatingRepo.GetOrgRating(orgObj.OID);
                            _orgRatingRepo.UpdateOrgRating(orgRating);
                        }
                    }

                }
            }
            catch(Exception e) { throw new InvalidOperationException(e.ToString()); }
             
        }
        //public static List<string> SplitCSV()
        //{
        //    List<string> splitted = new List<string>();
        //    string file = GetCSV();
        //    if (!(file == null))
        //    {



        //            string[] tempStr;

        //            tempStr = file.Split(';');

        //            foreach (string item in tempStr)
        //            {
        //                if (!string.IsNullOrWhiteSpace(item))
        //                {
        //                    splitted.Add(item);
        //                }
        //            }
        //            return splitted;

        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        //public static void UpdateDB()
        //{

        //    UpdateService updateService = new UpdateService(orgRatingRepo, )
        //}
        //    List<OrgRating> orgRatings = new List<OrgRating>();
        //    List<Organization> organizations = new List<Organization>();

        //    List<string> data = SplitCSV();
        //    if (!(data == null))
        //    {
        //        foreach(string d in data)
        //        {
        //            Organization organization = new Organization();
        //            OrgRating orgRating = new OrgRating();
        //            firstSixColumns.AddRange(fileLineParts.Take(6));  // Add the first 6 entries
        //            restOfColumns.AddRange(fileLineParts.Skip(6));    // Add the rest of the entries

        //        }                  // This is still incomplete needs more work before enabling otherwise it will crash 
        //    }
        //}
    }
}
