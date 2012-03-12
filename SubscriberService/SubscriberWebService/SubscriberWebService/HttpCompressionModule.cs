// Copyright (C) 2011 Thales Transportation Systems UK 
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy,modify, merge, publish, distribute, sublicense, and/or sell 
// copies of the Software, and to permit persons to whom the Software is 
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software. 
//    
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO.Compression;

namespace SubscriberWebService
{
    public class HttpCompressionModule : IHttpModule
    {
        #region IHttpModule Members

        public void Dispose()
        {            
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(ContextBeginRequest);
        }

        void ContextBeginRequest(object sender, EventArgs args)
        {
            HttpApplication app = (HttpApplication)sender;
            string compression = app.Request.Headers.Get("Content-Encoding");

            if (compression == null)
            {
                return;
            }

            compression = compression.ToLower();

            // Check if incoming request has gzip compression
            if (compression.Contains("gzip"))
            {
                app.Request.Filter = new GZipStream(app.Request.Filter, CompressionMode.Decompress);

            }

            string encodings = app.Request.Headers.Get("Accept-Encoding");
            
            // Check if response is to have gzip compression
            if (encodings != null && encodings.Contains("gzip"))
            {
                app.Response.Filter = new GZipStream(app.Response.Filter, CompressionMode.Compress);
                app.Response.AppendHeader("Content-Encoding", "gzip");
                app.Context.Trace.Warn("GZIP Compression on");
            }
            
        }

        #endregion
    }
}
