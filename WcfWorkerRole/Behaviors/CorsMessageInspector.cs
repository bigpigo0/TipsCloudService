using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace WcfWorkerRole.Behaviors
{
    public class CorsMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            HttpResponseMessageProperty responseProperty = null;

            if (reply.Properties.ContainsKey(HttpResponseMessageProperty.Name))
            {
                responseProperty = reply.Properties[HttpResponseMessageProperty.Name] as HttpResponseMessageProperty;
            }

            if (responseProperty == null)
            {
                responseProperty = new HttpResponseMessageProperty();
                reply.Properties.Add(HttpRequestMessageProperty.Name, responseProperty);
            }

            responseProperty.Headers.Set("Access-Control-Allow-Origin", "*");

        }
    }
}
