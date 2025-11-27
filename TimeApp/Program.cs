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

                // Inicio: 27/11/2025 a las 13:06
                var startTime = new DateTime(2025, 11, 27, 13, 06, 00);

                // Fin: 27/11/2025 a las 15:15
                var endTime = new DateTime(2025, 11, 27, 15, 15, 00);
                var usageInstagram= new UsageSession(instagramApp.Id,startTime,endTime);

                
                Console.WriteLine($"Duración de la sesión: {usageInstagram.GetDurationMinutes()} minutos");

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