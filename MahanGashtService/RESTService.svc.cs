using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using MGModel;

namespace MahanGashtService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]

    public class RESTService : IRESTService
    {
        public List<ServiceType> GetTypes()
        {
            MahanGashtEntities Mge = new MahanGashtEntities();

            List<ServiceType> Result = (from m in Mge.ServiceTypes
                                      select new ServiceType()
                                      {
                                          ServiceTypeId = m.ServiceTypeId.ToString(),
                                          STName = m.Type,
                                          STItems = m.Items
                                      }).ToList();

            return Result;
        }

        public List<Agencies> GetAgencies(string ServiceTypeIds)
        {
            MahanGashtEntities Mge = new MahanGashtEntities();

            string[] ls = ServiceTypeIds.Split(',');

            var listOfServiceTypeId = new List<int>();
            foreach (string sTI in ls)
            {
                if (sTI != "")
                    listOfServiceTypeId.Add(Convert.ToInt32(sTI));
            }

            List<Agencies> Result = Mge.Agencies
                                    .Where(m => listOfServiceTypeId.Contains(m.ServiceTypeId))
                                    .OrderBy(m => m.ServiceTypeId)
                                    .OrderBy(m => m.Address)
                                    .Take(50)
                                    .Select(m => new Agencies()
                                            {
                                                AgencyId = m.AgencyId.ToString(),
                                                AName = m.Name,
                                                APhones = m.Phones,
                                                AManager = m.Manager,
                                                AMobile = m.Mobile,
                                                AAddress = m.Address
                                            })
                                    .ToList();

            return Result;
        }

        public List<Agencies> GetAgenciesGroup(string ServiceTypeGroupId)
        {
            MahanGashtEntities Mge = new MahanGashtEntities();

            string[] ls = ServiceTypeGroupId.Split(',');

            var listOfAgenciesId = new List<int?>();
            for (int q = 0; q < ls.Length - 2; q++)
            {
                string val = ls[q].ToString();
                if (val != "")
                    listOfAgenciesId.Add(Convert.ToInt32(val));
            }


            var listOfServiceTypeId = Mge.ServiceTypes
                                                    .Where(m => listOfAgenciesId.Contains(m.A1))
                                                    .Select(m => m.ServiceTypeId )
                                                    .ToList();

            List<Agencies> Result = Mge.Agencies
                                    .Where(m => listOfServiceTypeId.Contains(m.ServiceTypeId))
                                    .OrderBy(m => m.ServiceTypeId)
                                    .OrderBy(m => m.Address)
                                    .Take(50)
                                    .Select(m => new Agencies()
                                    {
                                        AgencyId = m.AgencyId.ToString(),
                                        AName = m.Name,
                                        APhones = m.Phones,
                                        AManager = m.Manager,
                                        AMobile = m.Mobile,
                                        AAddress = m.Address
                                    }).ToList();
            return Result;
        }

        public bool UpdateAgenciesTude(string AgencyId, string ALatitude, string ALongitude)
        {
            var aaa = "You said " + AgencyId;
            return true;
        }
    }
}
