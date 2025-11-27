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
                var instagramApp = new TrackedApp("instagram", "Instagram", 12);

                Console.WriteLine($"Identificador: {instagramApp.Id}, Nombre: {instagramApp.Name}," +
              $" Límite de tiempo: {instagramApp.DailyLimitMinutes}");


                var sessions = new List<UsageSession>();
                var day = new DateTime(2025, 11, 27);

                var start1 = new DateTime(2025,11,27,9,00,00);
                var end1 = new DateTime(2025, 11, 27, 9, 03, 00);

                var session1 = new UsageSession(instagramApp.Id,start1,end1);
                sessions.Add(session1);
                Console.WriteLine($"Duración de la sesión: {session1.GetDurationMinutes()} minutos");

                var start2 = new DateTime(2025, 11, 27, 13, 06, 00);
                var end2 = new DateTime(2025, 11, 27, 13, 07, 00);

                var session2 = new UsageSession(instagramApp.Id, start2, end2);
                sessions.Add(session2);
                Console.WriteLine($"Duración de la sesión: {session2.GetDurationMinutes()} minutos");


                var alert = Alert.GetDailyAlert(instagramApp, day, sessions);

                if (alert != null)
                {
                    Console.WriteLine($"ALERTA para {alert.AppName} el {alert.Day:dd/MM/yyyy}");
                    Console.WriteLine(alert.Message);
                    Console.WriteLine($"Usado: {alert.UsedMinutes} minutos (límite: {alert.LimitMinutes})");
                }
                else
                {
                    Console.WriteLine("No hay alerta, estás dentro del límite diario.");
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