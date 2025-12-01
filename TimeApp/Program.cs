using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeApp
{
    class Program
    {
        public static void Main(string[] args)
        {

            try
            {
                var instagramApp = new TrackedApp("instagram", "Instagram", 1);

                Console.WriteLine($"Identificador: {instagramApp.Id}, Nombre: {instagramApp.Name}," +
              $" Límite de tiempo: {instagramApp.DailyLimitMinutes}");

                var youtubeApp = new TrackedApp("youtube", "Youtube", 0);

                Console.WriteLine($"Identificador: {youtubeApp.Id}, Nombre: {youtubeApp.Name}," +
              $" Límite de tiempo: {youtubeApp.DailyLimitMinutes}");



                var sessions = new List<UsageSession>();
                var day = new DateTime(2025, 11, 27);

                var start1 = new DateTime(2025,11,27,9,00,00);
                var end1 = new DateTime(2025, 11, 27, 9, 03, 00);

                var sessionInsta1 = new UsageSession(instagramApp.Id,start1,end1);
                sessions.Add(sessionInsta1);
             

                var start2 = new DateTime(2025, 11, 27, 13, 06, 00);
                var end2 = new DateTime(2025, 11, 27, 13, 07, 00);

                var sessionInsta2 = new UsageSession(instagramApp.Id, start2, end2);
                sessions.Add(sessionInsta2);
          

                var startYoutube = new DateTime(2025, 11, 27, 9, 00, 00);
                var endYoutube = new DateTime(2025, 11, 27, 9, 30, 00);
                var sessionYoutube1= new UsageSession(youtubeApp.Id, startYoutube, endYoutube);
                sessions.Add(sessionYoutube1);

                var startYoutube2 = new DateTime(2025, 11, 27, 9, 00, 00);
                var endYoutube2 = new DateTime(2025, 11, 27, 10, 00, 00);
                var sessionYoutube2 = new UsageSession(youtubeApp.Id, startYoutube2, endYoutube2);
                sessions.Add(sessionYoutube2);


                var apps = new List<TrackedApp> {instagramApp,youtubeApp};
         

                foreach (var app in apps) {

                    var Alertas = Alert.GetDailyAlert(app, day, sessions);

                    if (Alertas != null)
                {
                       
                        Console.WriteLine($"Alertas para {Alertas.AppName} el {Alertas.Day:dd/MM/yyyy}");
                    Console.WriteLine(Alertas.Message);
                    Console.WriteLine($"Usado: {Alertas.UsedMinutes} minutos (límite: {Alertas.LimitMinutes})");
                }
                else
                {
                    Console.WriteLine($"{app.Name} : No hay alerta, estás dentro del límite diario.");
                }

                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadKey();
            }
         


        }





    }
  

}