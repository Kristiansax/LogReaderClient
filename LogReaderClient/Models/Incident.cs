using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogReaderClient.Models
{
    public class Incident
    {
        public string time { get; set; }
        public string ID { get; set; }
        public string alarm { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public string residence { get; set; }
        public string location { get; set; }
        public string resetTime { get; set; }
        public string personnel { get; set; }
        public string callTo { get; set; }
        public string groupCall { get; set; }

        public Incident(string time, string ID, string alarm, string name, string department, string residence, string location, string resetTime, string personnel, string callTo, string groupCall)
        {
            this.time = time;
            this.ID = ID;
            this.alarm = alarm;
            this.name = name;
            this.department = department;
            this.residence = residence;
            this.location = location;
            this.resetTime = resetTime;
            this.personnel = personnel;
            this.callTo = callTo;
            this.groupCall = groupCall;
        }
        public Incident()
        {

        }
    }
}
