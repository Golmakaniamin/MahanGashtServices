using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MahanGashtService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IRESTService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetTypes")]
        List<ServiceType> GetTypes();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Agencies/{ServiceTypeIds}")]
        List<Agencies> GetAgencies(string ServiceTypeIds);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "AgenciesGroup/{ServiceTypeGroupId}")]
        List<Agencies> GetAgenciesGroup(string ServiceTypeGroupId);

        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateAgencies/{AgencyId} ,{ALatitude} ,{ALongitude}")]
        bool UpdateAgenciesTude(string AgencyId, string ALatitude, string ALongitude);
    }
}
