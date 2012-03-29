using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.Web;

namespace TestClient
{
    public class HttpCompressionModule : IHttpModule
    {

        public void Dispose()
        {
        }

        public void Init(HttpApplication application)
        {
            application.BeginRequest +=
                (new EventHandler(this.Application_BeginRequest));

        }

        private void Application_BeginRequest(Object source, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            context.Request.Filter = new GZipStream(context.Request.Filter, CompressionMode.Compress);
            HttpContext.Current.Response.AppendHeader("Content-encoding", "gzip");
            HttpContext.Current.Response.Cache.VaryByHeaders["Accept-encoding"] = true;
        }

    }
}
