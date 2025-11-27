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
                var instagramApp = new TrackedApp("instagram", "Instagram", 0);

                Console.WriteLine($"Identificador: {instagramApp.Id}, Nombre: {instagramApp.Name}," +
                    $" Límite de tiempo: {instagramApp.DailyLimitMinutes}");
               
            }
            catch(ArgumentOutOfRangeException e)
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