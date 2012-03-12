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

namespace SubscriberWebService.Services
{
    /// <summary>
    /// This class is an example for demonstration purposes only, of a developer can define their own traffic information type.
    /// </summary>
    public class TrafficData
    {
        private String guid;
        private DateTime dbDateTime;
        private DateTime midasDateTime;
        private string equipment;
        private int laneNumber;
        private int flowCat1;        
        private int flowCat2;
        private int flowCat3;
        private int flowCat4;
        private int avgSpeedKmh;
        private int avgOccupancy;        
        private int avgHeadway;

        public String Guid
        {
            get { return guid; }
            set { guid = value; }
        }

        public DateTime DbDateTime
        {
            get { return dbDateTime; }
            set { dbDateTime = value; }
        }

        public DateTime MidasDateTime
        {
            get { return midasDateTime; }
            set { midasDateTime = value; }
        }

        public string Equipment
        {
            get { return equipment; }
            set { equipment = value; }
        }

        public int LaneNumber
        {
            get { return laneNumber; }
            set { laneNumber = value; }
        }

        public int FlowCat1
        {
            get { return flowCat1; }
            set { flowCat1 = value; }
        }

        public int FlowCat2
        {
            get { return flowCat2; }
            set { flowCat2 = value; }
        }

        public int FlowCat3
        {
            get { return flowCat3; }
            set { flowCat3 = value; }
        }

        public int FlowCat4
        {
            get { return flowCat4; }
            set { flowCat4 = value; }
        }

        public int AvgSpeedKmh
        {
            get { return avgSpeedKmh; }
            set { avgSpeedKmh = value; }
        }

        public int AvgOccupancy
        {
            get { return avgOccupancy; }
            set { avgOccupancy = value; }
        }

        public int AvgHeadway
        {
            get { return avgHeadway; }
            set { avgHeadway = value; }
        }


    }
}
