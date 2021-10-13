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

            ConsoleSettings(); 
            WelcomeLoop(); 

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
                    bool Bank = Inlogg(userArray, ref targetIndex, ref loggingin);
                    while (Bank)
                    {
                        switchChoice = Menu();

                        switch (switchChoice)
                        {

                            case "1":
                                DisplayMoneyMenu(userArray, targetIndex);
                                break;
                            case "2":
                                TransferMoneyMeny(userArray, targetIndex);
                                break;
                            case "3":
                                WithdralMoneyMeny(userArray, targetIndex);
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
                    Ogiltligtval(userArray,targetIndex);
                    goto start;
                }
                break;
            }

        }
        static void WelcomeLoop() // Välkomstmeddelande
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

        static void ConsoleSettings() // Inställningar på hur konsolfönstret ska se ut
        {
            Console.WindowHeight = 25;
            Console.WindowWidth = 70;
        }

        public static bool Inlogg(account[]Users, ref int x, ref bool loggingin)
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

        static string Menu()
        {
            Console.WriteLine("1. → Se dina konton och saldo");
            Console.WriteLine("2. → Överföring mellan konton");
            Console.WriteLine("3. → Ta ut pengar");
            Console.WriteLine("4. → Logga ut");
            Console.WriteLine();
            return Console.ReadLine();
        }

        static void DisplayMoneyMenu(account[] Users, int tempIndex)
        {
            Console.Clear();
            Console.WriteLine(String.Format("{0," + (Console.WindowWidth - 24) + "}", "Se dina konton och saldo"));
            Console.WriteLine();

            Console.WriteLine("Lönekonto: " + Users[tempIndex].amount1 + " kr");
            if (Users[tempIndex].amount2 != 0)
            {
                Console.WriteLine("Sparkonto: " + Users[tempIndex].amount2 + " kr");
            }
            if (Users[tempIndex].amount3 != 0)
            {
                Console.WriteLine("Räkningskonto: " + Users[tempIndex].amount3 + " kr");
            }
            Console.WriteLine();
            Console.WriteLine("Klicka enter för att komma till huvudmenyn");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(String.Format("{0," + (Console.WindowWidth - 23) + "}", "Inloggad som anävndare: " + Users[tempIndex].username));
            Console.WriteLine();
        } // Menyval som visar konton och saldon

        static void TransferMoneyMeny(account[] Users, int tempIndex) 
        {
           
            Console.Clear();
            Console.WriteLine(String.Format("{0," + (Console.WindowWidth - 25) + "}", "Överföring mellan konton"));
            Console.WriteLine();
            Console.WriteLine("1. → Lönekonto: " + Users[tempIndex].amount1 + " kr");
            if (Users[tempIndex].amount2 != 0)
            {
                Console.WriteLine("2. → Sparkonto: " + Users[tempIndex].amount2 + " kr");
            }
            if (Users[tempIndex].amount3 != 0)
            {
                Console.WriteLine("3. → Räknekonto: " + Users[tempIndex].amount3 + " kr");
            }
            Console.WriteLine();

            Console.Write("Välj vilket konto du vill flytta pengar ifrån: ");
            string moveFromAccount = Console.ReadLine();

            Console.WriteLine("Hur mycket vill du flytta?");

            double moveAmount = Int32.Parse(Console.ReadLine());

            if (moveFromAccount == "1")
            {

                Users[tempIndex].amount1 = Users[tempIndex].amount1 - moveAmount;

            }
            else if (moveFromAccount == "2")
            {
                Users[tempIndex].amount2 = Users[tempIndex].amount2 - moveAmount;
            }
            else if (moveFromAccount == "3")
            {
                Users[tempIndex].amount3 = Users[tempIndex].amount3 - moveAmount;
            }
            else
            {
               
            }


            Console.WriteLine("Välj vilket konto du vill flytta pengar till");
            string moveToAccount = Console.ReadLine();
            if (moveToAccount == "1")
            {
                Users[tempIndex].amount1 = Users[tempIndex].amount1 + moveAmount;
                Console.WriteLine("Överföringen lyckades!");

            }
            else if (moveToAccount == "2")
            {
                Users[tempIndex].amount2 = Users[tempIndex].amount2 + moveAmount;
                Console.WriteLine("Överföringen lyckades!");
            }
            else if (moveToAccount == "3")
            {
                Users[tempIndex].amount3 = Users[tempIndex].amount3 + moveAmount;
                Console.WriteLine("Överföringen lyckades!");
            }


            Console.WriteLine("Klicka enter för att komma till huvudmenyn");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(String.Format("{0," + (Console.WindowWidth - 23) + "}", "Inloggad som anävndare: " + Users[tempIndex].username));
            Console.WriteLine();
        } // Menyval där man kan föra över pengar mellan sina konton

        static void WithdralMoneyMeny(account[] Users, int tempIndex)
        {
            Console.Clear();
            Console.WriteLine(String.Format("{0," + (Console.WindowWidth - 30) + "}", "Ta ut pengar"));
            Console.WriteLine();
            Console.WriteLine("1. → Lönekonto: " + Users[tempIndex].amount1 + " kr");
            if (Users[tempIndex].amount2 != 0)
            {
                Console.WriteLine("2. → Sparkonto: " + Users[tempIndex].amount2 + " kr");
            }
            if (Users[tempIndex].amount3 != 0)
            {
                Console.WriteLine("3. → Räknekonto: " + Users[tempIndex].amount3 + " kr");
            }
            Console.WriteLine();
            Console.WriteLine("Från vilket konto vill du ta ut pengar ifrån?");
            string withdralFromAccount = Console.ReadLine();
            Console.WriteLine("Hur mycket pengar vill du ta ut?");
            double withdralAmount = Int16.Parse(Console.ReadLine());

            Console.Write("Lösenord: ");
            string withdrawalPassword = Console.ReadLine();

            if (withdrawalPassword == Users[tempIndex].password)
            {

                if (withdralFromAccount == "1")
                {

                    Users[tempIndex].amount1 = Users[tempIndex].amount1 - withdralAmount;
                    Console.WriteLine("Uttaget lyckades!");

                }
                else if (withdralFromAccount == "2")
                {
                    Users[tempIndex].amount2 = Users[tempIndex].amount2 - withdralAmount;
                    Console.WriteLine("Uttaget lyckades!");
                }
                else if (withdralFromAccount == "3")
                {
                    Users[tempIndex].amount3 = Users[tempIndex].amount3 - withdralAmount;
                    Console.WriteLine("Uttaget lyckades!");
                }

            }

            Console.WriteLine("Klicka enter för att komma till huvudmenyn");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(String.Format("{0," + (Console.WindowWidth - 23) + "}", "Inloggad som anävndare: " + Users[tempIndex].username));
            Console.WriteLine();
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
