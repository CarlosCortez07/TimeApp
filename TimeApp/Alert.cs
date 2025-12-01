using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeApp
{
    public class Alert
    {
        public required string AppName { get; set; }
        public DateTime Day { get; set; }
        public int UsedMinutes { get; set; }
        public int LimitMinutes { get; set; }
        public required string Message { get; set; }

        public static Alert? GetDailyAlert(TrackedApp app, DateTime day, List<UsageSession>sessions)
        {
            int totalMinutes = GetAppMinutes(app, day, sessions);

         
                    if (totalMinutes > app.DailyLimitMinutes)
                    {
                        return new Alert
                        {
                            AppName = app.Name,
                            Day = day.Date,
                            UsedMinutes = totalMinutes,
                            LimitMinutes = app.DailyLimitMinutes,
                            Message = $"Has usado {totalMinutes} minutos (límite {app.DailyLimitMinutes})."
                        };
                    }
               
            
      

            // No hay alerta
            return null;

        }

        private static int GetAppMinutes(TrackedApp app, DateTime day, List<UsageSession> sessions)
        {
            int totalMinutes = 0;
            foreach(var session in sessions)
            {
                if(session.AppId == app.Id &&  session.StartTime.Date==day.Date)
                {
                  totalMinutes += session.GetDurationMinutes();
                }
             
            }
            return totalMinutes;
        }

    }
}
