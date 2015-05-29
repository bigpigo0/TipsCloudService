using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfWorkerRole
{
    [ServiceContract] 
    public interface ITipService
    {

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Meeting", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json)]
        Stream GetMeeting();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "PoolTot/{number}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json)]
        Stream GetPoolTot(string number);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Win/{number}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json)]
        Stream GetWin(string number);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Place/{number}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json)]
        Stream GetPlace(string number);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Race/{number}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json)]
        Stream GetRace(string number);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Speed/{number}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json)]
        Stream GetSpeed(string number);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Result/{number}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json)]
        Stream GetResult(string number);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "JockyFairValue", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json)]
        Stream GetJockyFairValue();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "BarDrawWinChance", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json)]
        Stream GetBarDrawWinChance();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Hello", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json)]
        Stream GetHelloMessage();

        //[OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "JockeyWinStat/{jockyCode}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
        //    ResponseFormat = WebMessageFormat.Json)]
        //Stream GetJockeyWinStat(string jockyCode);
    }
}
