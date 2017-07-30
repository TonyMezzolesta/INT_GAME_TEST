using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;


namespace NancyAPI
{
    public partial class Service1 : ServiceBase
    {
        public Nancy.Hosting.Self.NancyHost nancyHost = new Nancy.Hosting.Self.NancyHost(new Uri("http://localhost:8675"));

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                nancyHost.Start();
                LogWriter.LogWrite("Web server running...");
            }
            catch(Exception ex)
            {
                LogWriter.LogWrite("Failed to start server");
            }

        }

        protected override void OnStop()
        {
            try
            {
                nancyHost.Stop();
                LogWriter.LogWrite("Web server stopped...");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite("Failed to stop server");
            }
        }
    }
}
