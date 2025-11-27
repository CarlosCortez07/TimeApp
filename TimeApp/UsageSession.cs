using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TimeApp
{
    public class UsageSession
    {
        public string AppId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public UsageSession(string appId, DateTime startTime, DateTime endTime)
        {
            this.AppId = appId;
            this.StartTime = startTime;
            if(endTime < startTime)
            {
                throw new ArgumentOutOfRangeException(nameof(endTime),
                    "La hora de fin no puede ser anterior a la hora de inicio.");
            }
            this.EndTime = endTime;
        }

        public int GetDurationMinutes()
        {
            
          TimeSpan interval=EndTime-StartTime;
            return (int)interval.TotalMinutes;
        }
    }
}
