using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace DatabaseDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private Guid _id = Guid.NewGuid();
        private int _counter = 0;
        private Stopwatch _watcher = new Stopwatch();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        public override void Init()
        {
            base.Init();
            this.LogRequest += OnLogRequest;
            this.PostReleaseRequestState += OnPostReleaseRequestState;
        }

        void OnPostReleaseRequestState(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Headers["__ThreadID"] = _id.ToString();
            HttpContext.Current.Response.Headers["__RequestNum"] = _counter.ToString();
        }

        private void OnLogRequest(object sender, EventArgs eventArgs)
        {
            
        }

        protected void Application_BeginRequest()
        {
            _counter++;
            _watcher.Reset();
            _watcher.Start();
        }
        
        protected void Application_EndRequest()
        {
            _watcher.Stop();
            HttpContext.Current.Response.Headers["__Duration"] = _watcher.Elapsed.ToString();

        }        

    }
}