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
using log4net;
using Subscriber;

namespace SubscriberWebService.Services
{
    /// <summary>
    /// Class to check that a request contains a valid D2LogicalModel object,
    /// and demonstrates how to extract data from it.
    /// </summary>
    public abstract class AbstractDatexService
    {
        protected static readonly ILog log = log4net.LogManager.GetLogger(typeof(AbstractDatexService));

        /// <summary>
        /// Check that the D2LogicalModel is not null, and contains an Exchange object.
        /// </summary>
        /// <param name="d2LogicalModel"></param>
        /// <returns>true if valid, false otherwise</returns>
        public bool ExampleDataCheckOk(D2LogicalModel d2LogicalModel)
        {
            if (d2LogicalModel == null)
            {
                log.Error("D2LogicalModel is null! Incoming request does not appear to be valid.");
                return false;
            }

            // Exchange must not be null.
            if (d2LogicalModel.exchange == null)
            {
                log.Error("Exchange is null! Incoming request does not appear to be valid.");
                return false;
            }
            log.Debug("Data checked");
            return true;
        }


    }
}
