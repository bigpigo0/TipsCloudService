using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using System.Configuration;
using NLog;

namespace WcfWorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);
        private WebServiceHost _serviceHost;

        public override void Run()
        {
            Trace.TraceInformation("WcfWorkerRole is running");

            try
            {
                this.RunAsync(this.cancellationTokenSource.Token).Wait();
            }
            finally
            {
                this.runCompleteEvent.Set();
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;
            LogTargetManager.SetLogTargetBaseDirectory("appLogFile", RoleEnvironment.GetLocalResource("CustomLogs").RootPath);
            //LogLevelManager.SetMinimimLogLevel(_workerRoleConfiguration.MinimumLogLevel);
            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.
            StartWCFService();
            bool result = base.OnStart();

            Trace.TraceInformation("WcfWorkerRole has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("WcfWorkerRole is stopping");

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            base.OnStop();

            Trace.TraceInformation("WcfWorkerRole has stopped");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following with your own logic.
            while (!cancellationToken.IsCancellationRequested)
            {
                Trace.TraceInformation("Working");
                await Task.Delay(1000);
            }
        }

        private void StartWCFService()
        {
            Trace.TraceInformation("Starting WCF service host...");
            IPEndPoint endpoint = GetInstanceEndpoint("httpIn");
            var address = new Uri(string.Format("http://{0}/", endpoint));

            _serviceHost = new WebServiceHost(typeof(TipService), address);

            try
            {
                _serviceHost.Open();
                Trace.TraceInformation("WCF service host started successfully.");
            }
            catch (TimeoutException timeoutException)
            {
                Trace.TraceError("The service operation timed out. {0}", timeoutException.Message);
            }
            catch (CommunicationException communicationException)
            {
                Trace.TraceError("Could not start WCF service host. {0}", communicationException.Message);
            }
        }

        private static IPEndPoint GetInstanceEndpoint(string endpointName)
        {
            if (RoleEnvironment.IsAvailable)
            {
                return RoleEnvironment.CurrentRoleInstance.InstanceEndpoints[endpointName].IPEndpoint;
            }
            return new IPEndPoint(IPAddress.Loopback, int.Parse(System.Configuration.ConfigurationManager.AppSettings[endpointName]));
        }
    }
}
