using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeApp
{
    public class TrackedApp
    {
        public string Id{get; set;}
        public string Name { get; set;}
        public int DailyLimitMinutes {  get; set;}

        public TrackedApp(string id, string name, int dailyLimitMinutes)
        {
            Id = id;
            Name = name;

            if (dailyLimitMinutes <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(dailyLimitMinutes),
                    "El límite diario debe ser mayor que cero");
            }
            
            DailyLimitMinutes=dailyLimitMinutes;
            


        }
    }
}
