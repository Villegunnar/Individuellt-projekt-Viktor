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

        start:

            bool successfull = false;
            bool loggingin = true;
            string switchChoice;
            int targetIndex = 0;

            Console.WriteLine("1. → Logga in ");
            Console.WriteLine("2. → Registrera ");
            Console.WriteLine();
            Console.Write("Menyval: ");
            string input = Console.ReadLine();

            while (!successfull)
            {
                if (input == "1")
                {
                    bool Bank = inLogg(userArray, ref targetIndex, ref loggingin);
                    while (Bank)
                    {
                        switchChoice = menu();

                        switch (switchChoice)
                        {

                            case "1":

                                break;
                            case "2":

                                break;
                            case "3":

                                break;
                            case "4":
                                LoggingOut();
                                Console.WriteLine(String.Format("{0," + (Console.WindowWidth - 22) + "}", "Välkommen till bank Gunnarsson"));


                                goto start;

                            default:
                                Ogiltligtval(userArray, targetIndex);
                                break;

                        }

                    }

                }
                else if (input == "2")
                {
                    Console.Clear();
                    Console.WriteLine(String.Format("{0," + (Console.WindowWidth - 25) + "}", "Registrera ny användare"));

                    Console.WriteLine();
                    Console.Write("Användarnamn: ");
                    string username = Console.ReadLine();
                    Console.Write("Pinkod: ");
                    string password = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Användare " + username + " är nu registrerad.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine(String.Format("{0," + (Console.WindowWidth - 22) + "}", "Välkommen till bank Gunnarsson"));
                    Array.Resize(ref userArray, userArray.Length + 1);
                    userArray[userArray.Length - 1] = new account(username, password, 0, 0);
                    goto start;
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Ogiltigt val!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine(String.Format("{0," + (Console.WindowWidth - 22) + "}", "Välkommen till bank Gunnarsson"));
                    Console.WriteLine();
                    goto start;
                }
                break;
            }












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

        public static bool inLogg(account[]Users, ref int x, ref bool loggingin)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                Console.WriteLine(String.Format("{0," + (Console.WindowWidth - 22) + "}", "Välkommen till bank Gunnarsson"));

                Console.WriteLine();
                Console.Write("Användarnamn: ");
                var username = Console.ReadLine();
                Console.Write("Lösenord: ");
                var password = Console.ReadLine();
                Console.Clear();

                for (int j = 0; j < Users.Length; j++)
                {
                    if (username == Users[j].username && password == Users[j].password)
                    {
                        LoggingIn();

                        Console.Clear();
                        Console.WriteLine(String.Format("{0," + (Console.WindowWidth - 23) + "}", "Inloggad som användare: " + username));
                        Console.WriteLine();


                        x = j;
                        return true;

                    }

                }
                Console.WriteLine("Användarnamnet eller lösernordet var fel!");

                Thread.Sleep(1000);
                Console.Clear();

            }
            Console.WriteLine("För många försök, Konto spärrat", Console.ForegroundColor);

            loggingin = false;
            return false;
        }

        static void LoggingIn()
        {
            Console.Clear();
            string bufferDots = "...";
            Console.Write(String.Format("{0," + (Console.WindowWidth - 30) + "}", "Du loggas in"));
            // Console.Write("Du loggas in");
            for (int i = 0; i < bufferDots.Length; i++)
            {
                Thread.Sleep(400);
                Console.Write(bufferDots[i]);

            }
            Console.Clear();
            Console.Write(String.Format("{0," + (Console.WindowWidth - 30) + "}", "Du loggas in"));
            for (int i = 0; i < bufferDots.Length; i++)
            {
                Thread.Sleep(400);
                Console.Write(bufferDots[i]);

            }
            Console.Clear();



        }

        static void LoggingOut()
        {

            Console.Clear();
            string bufferDots = "...";
            Console.Write(String.Format("{0," + (Console.WindowWidth - 30) + "}", "Du loggas ut"));
            // Console.Write("Du loggas in");
            for (int i = 0; i < bufferDots.Length; i++)
            {
                Thread.Sleep(400);
                Console.Write(bufferDots[i]);

            }
            Console.Clear();
            Console.Write(String.Format("{0," + (Console.WindowWidth - 30) + "}", "Du loggas ut"));
            for (int i = 0; i < bufferDots.Length; i++)
            {
                Thread.Sleep(400);
                Console.Write(bufferDots[i]);

            }
            Console.Clear();



        }

        static string menu()
        {
            Console.WriteLine("1. → Se dina konton och saldo");
            Console.WriteLine("2. → Överföring mellan konton");
            Console.WriteLine("3. → Ta ut pengar");
            Console.WriteLine("4. → Logga ut");
            Console.WriteLine();
            return Console.ReadLine();
        }

        static void Ogiltligtval(account[] Users, int tempIndex)
        {
            Console.Clear();
            Console.WriteLine("Ogiltigt val!");

            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine(String.Format("{0," + (Console.WindowWidth - 23) + "}", "Inloggad som anävndare: " + Users[tempIndex].username));
            Console.WriteLine();
        }
    }

}
