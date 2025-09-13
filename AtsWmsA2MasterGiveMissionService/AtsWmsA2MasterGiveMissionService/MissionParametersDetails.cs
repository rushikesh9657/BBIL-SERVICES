using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtsWmsA2MasterGiveMissionService
{
    class MissionParametersDetails
    {
        public string Sender { get; set; }              // 4 chars
        public string Receiver { get; set; }           // 4 chars
        public string Handshake { get; set; }          // 2 chars
        public string Teletype { get; set; }           // 4 chars
        public string startLine { get; set; }          // 2 chars
        public string startFloor { get; set; }         // 2 chars
        public string startDepthOfLine { get; set; }   // 2 chars
        public string startColumn { get; set; }        // 4 chars
        public string targetLine { get; set; }         // 2 chars
        public string targetFloor { get; set; }        // 2 chars
        public string targetDepthOfLine { get; set; }  // 2 chars
        public string targetColumn { get; set; }       // 4 chars
        public string taskType { get; set; }           // 2 chars
        public string missionId { get; set; }          // 14 chars
        public string Error { get; set; }              // 6 chars
    }
}
