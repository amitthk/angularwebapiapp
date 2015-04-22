using System;
using Microsoft.Owin.Hosting;

namespace AngularWebApiApp
{
    class Program
    {

        static void Main(string[] args)
        {

            // Specify the URI to use for the local host:

            string baseUri = "http://localhost:61528";



            Console.WriteLine("Starting web Server...");

            using (WebApp.Start<Startup>(baseUri))
            {

                Console.WriteLine("Server running at {0} - press Enter to quit. ", baseUri);

                Console.ReadLine();
            }

        }

    }

}