using System;
using System.Threading;

namespace Individuellt_projekt_Viktor
{
    public class account
    {
        public string username;
        public string password;
        public double amount1;
        public double amount2;
        public double amount3;

        public account(string username, string password, double amount1, double amount2 = 0, double amount3 = 0)
        {
            this.username = username;
            this.password = password;
            this.amount1 = amount1;
            this.amount2 = amount2;
            this.amount3 = amount3;


        }


    }
    class Program
    {

        static void Main(string[] args)
        {
            var userArray = new account[] // En array som innehåller användarnamn, lösenord och deras kontosaldon.
            {
                    new account("admin","admin",1000,1000,1000),
                    new account("viktor","viktor123",940),
                    new account("erik","erik123",1000,550.50, 220.50),
                    new account("anas","anas123",1000,1000.50),
                    new account("tobias","tobias123",1000,1000.40,10000),
                    new account("lucas","lucas123",1000.00, 1000.50)
            };

            ConsoleSettings(); // Inställningar på hur konsolfönstret ska se ut
            WelcomeLoop(); // Välkomstmeddelande













        }
        static void WelcomeLoop()
        {



            string welcometext = "Välkommen till bank Gunnarsson!";

            Console.Write(String.Format("{0," + (Console.WindowWidth - 52) + "}", ""));
            for (int i = 0; i < welcometext.Length; i++)
            {
                Thread.Sleep(100);
                Console.Write(welcometext[i]);

            }
            Console.WriteLine();
            Console.WriteLine();



        }

        static void ConsoleSettings()
        {
            Console.WindowHeight = 25;
            Console.WindowWidth = 70;
        }


    }

}
