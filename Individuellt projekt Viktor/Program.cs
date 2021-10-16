using System;
using System.Threading;

namespace Individuellt_projekt_Viktor //   SUT21 | Viktor Gunnarsson | Individuellt projekt 
{
    public class Account // En klass med användare och konton
    {
        public string username;
        public string password;
        public double amount1;
        public double amount2;
        public double amount3;

        public Account(string username, string password, double amount1, double amount2 = 0, double amount3 = 0)
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
            var userArray = new Account[] // En array som innehåller användarnamn, lösenord och deras kontosaldon.  
            {
                    new Account("admin","admin",1000,1000,1000),
                    new Account("viktor","viktor123",940),
                    new Account("erik","erik123",1000,550.50, 220.50),
                    new Account("anas","anas123",1000,1000.50),
                    new Account("tobias","tobias123",1000,1000.40,10000),
                    new Account("lucas","lucas123",1000.00, 1000.50)
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
                    Console.WriteLine("Hur mycket pengar vill du sätta in på lönekontot? Skriv i kr/öre");
                    double putInMoney;
                    while (!double.TryParse(Console.ReadLine(), out putInMoney))
                    {
                        Console.Clear();
                        Console.WriteLine("Ogiltigt val, ange med siffror tack!");
                        Thread.Sleep(2000);
                        Console.WriteLine();
                        Console.WriteLine("Hur mycket pengar vill du sätta in på lönekontot? Skriv i kr/öre");
                    }
                    Console.Clear();
                    Console.WriteLine("Användare " + username + " är nu registrerad. Med " + putInMoney + "kr på lönekontot!");
                    Thread.Sleep(3000);
                    Console.Clear();
                    Console.WriteLine(String.Format("{0," + (Console.WindowWidth - 22) + "}", "Välkommen till bank Gunnarsson"));
                    Array.Resize(ref userArray, userArray.Length + 1);
                    userArray[userArray.Length - 1] = new Account(username, password, putInMoney, 0);
                    goto start;
                }

                else
                {
                    Ogiltligtval(userArray, targetIndex);
                    goto start;
                }
                break;
            }// Huvudloopen som håller igång programmet

        }
        static void WelcomeLoop() // Välkomstmeddelande
        {
            string welcometext = "Välkommen till bank Gunnarsson!";

            Console.Write(String.Format("{0," + (Console.WindowWidth - 52) + "}", "")); // Centrerar texten
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WindowHeight = 25;
            Console.WindowWidth = 70;
        }
        public static bool Inlogg(Account[] Users, ref int x, ref bool loggingin) /* En bool som blir true eller false beroende på om man angivit rätt användare och 
                                                                                    lösenord som finns med i arrayen med kontouppgifterna */
        {
            for (int i = 0; i < 3; i++) // En loop som ger användaren 3 försök att skriva in rätt användarnamn och lösen.
            {
                Console.Clear();
                Console.WriteLine(String.Format("{0," + (Console.WindowWidth - 22) + "}", "Välkommen till bank Gunnarsson"));

                Console.WriteLine();
                Console.Write("Användarnamn: ");
                var username = Console.ReadLine();
                Console.Write("Lösenord: ");
                var password = Console.ReadLine();
                Console.Clear();

                for (int j = 0; j < Users.Length; j++) /* En loop som loopar igenom UserArray för att matcha användarnamn och lösenord 
                                                          och lägger detta indexet i j som jag stoppar in i x */
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
            Console.WriteLine("För många försök, Konto spärrat");

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
            LoggingInSound();
            Console.Clear();

        } // Text som visas när man loggas in

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
            LoggingOutSound();
            Console.Clear();
        } // Text som visas när man loggas ut

        static string Menu()
        {
            Console.WriteLine("1. → Se dina konton och saldo");
            Console.WriteLine("2. → Överföring mellan konton");
            Console.WriteLine("3. → Ta ut pengar");
            Console.WriteLine("4. → Logga ut");
            Console.WriteLine();
            return Console.ReadLine();
        } // Menyn som visas när en användare loggats in och som returnerar användarens val till vilket switch man vill in i.

        static void DisplayMoneyMenu(Account[] Users, int tempIndex)
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

        static void TransferMoneyMeny(Account[] Users, int tempIndex)
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

        start1:
            Console.WriteLine("Välj vilket konto du vill flytta pengar ifrån:");

            string moveFromAccount = Console.ReadLine();

            if ((moveFromAccount == "1" && Users[tempIndex].amount1 == 0) ||
                (moveFromAccount == "2" && Users[tempIndex].amount2 == 0) ||
                (moveFromAccount == "3" && Users[tempIndex].amount3 == 0))
            {
                Console.WriteLine("Det finns inga pengar på detta konton");

                goto start1;
            }
            if ((moveFromAccount != "1") &&
                (moveFromAccount != "2") &&
                (moveFromAccount != "3"))
            {
                Console.WriteLine("Ogiltligt val!");
                goto start1;
            }
            bool moveAmountBool = true;

        start2:
            Console.WriteLine("Hur mycket vill du flytta?");
            double moveAmount;

            while (!double.TryParse(Console.ReadLine(), out moveAmount))
            {
                Console.WriteLine("Ogiltigt val!");
            }
            while (moveAmountBool)
            {
                switch (moveFromAccount)
                {
                    case "1":
                        if (Users[tempIndex].amount1 >= moveAmount)
                        {
                            Users[tempIndex].amount1 = Users[tempIndex].amount1 - moveAmount;
                            moveAmountBool = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Du har för lite pengar på det kontot, ange en mindre summa:");
                            goto start2;
                        }
                    case "2":

                        if (Users[tempIndex].amount2 >= moveAmount)
                        {
                            Users[tempIndex].amount2 = Users[tempIndex].amount2 - moveAmount;
                            moveAmountBool = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Du har för lite pengar på det kontot, ange en mindre summa:");
                            goto start2;
                        }

                    case "3":
                        if (Users[tempIndex].amount3 >= moveAmount)
                        {
                            Users[tempIndex].amount3 = Users[tempIndex].amount3 - moveAmount;
                            moveAmountBool = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Du har för lite pengar på det kontot, ange en mindre summa:");
                            goto start2;
                        }
                    default:
                        Console.WriteLine("Det finns inget konto som heter " + moveFromAccount + ". Testa igen");
                        Thread.Sleep(1000);
                        goto start1;
                }
            }
        start3:
            Console.WriteLine("Välj vilket konto du vill flytta pengar till");
            string moveToAccount = Console.ReadLine();
            if ((moveToAccount != "1") &&
                (moveToAccount != "2") &&
                (moveToAccount != "3"))
            {
                Console.WriteLine("Ogiltligt val!");
                goto start3;
            }
            if (moveToAccount == moveFromAccount)
            {

                Console.WriteLine("Du kan inte välja att skicka pengar till samma konto.");
                goto start3;
            }
            else if (moveToAccount == "1")
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


        static void WithdralMoneyMeny(Account[] Users, int tempIndex)
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
        start4:
            Console.WriteLine("Från vilket konto vill du ta ut pengar ifrån?");
            string withdralFromAccount = Console.ReadLine();

            if ((withdralFromAccount == "1" && Users[tempIndex].amount1 == 0) ||
                (withdralFromAccount == "2" && Users[tempIndex].amount2 == 0) ||
                (withdralFromAccount == "3" && Users[tempIndex].amount3 == 0))
            {
                Console.WriteLine("Det finns inga pengar på detta konton");

                goto start4;
            }
            if ((withdralFromAccount != "1") &&
                (withdralFromAccount != "2") &&
                (withdralFromAccount != "3"))
            {
                Console.WriteLine("Ogiltligt val!");
                goto start4;
            }
        start5:
            Console.WriteLine("Hur mycket pengar vill du ta ut?");

            double withdralAmount;

            while (!double.TryParse(Console.ReadLine(), out withdralAmount))
            {
                Console.WriteLine("Ogiltigt val!");
            }
            if ((withdralFromAccount == "1" && Users[tempIndex].amount1 < withdralAmount) ||
                (withdralFromAccount == "2" && Users[tempIndex].amount2 < withdralAmount) ||
                (withdralFromAccount == "3" && Users[tempIndex].amount3 < withdralAmount))
            {
                Console.WriteLine("Du kan inte ta ut mer pengar än vad som finns på kontot.");
                goto start5;
            }
            if (withdralFromAccount == "1" && Users[tempIndex].amount1 >= withdralAmount)
            {
                for (int i = 0; i < 3; i++)
                {

                    Console.Write("Lösenord: ");
                    string withdrawalPassword = Console.ReadLine();
                    if (withdrawalPassword == Users[tempIndex].password)
                    {
                        Users[tempIndex].amount1 = Users[tempIndex].amount1 - withdralAmount;
                        i = 3;
                        Console.WriteLine("Uttaget lyckades! Du har nu " + Users[tempIndex].amount1 + " kr kvar på Lönekontot.");
                        goto start6;
                    }
                    Console.WriteLine("Fel lösenord!");
                }
                Console.WriteLine("Du skrev in fel lösenord för många gånger...");
            }
            if (withdralFromAccount == "2" && Users[tempIndex].amount2 >= withdralAmount)
            {
                for (int i = 0; i < 3; i++)
                {

                    Console.Write("Lösenord: ");
                    string withdrawalPassword = Console.ReadLine();
                    if (withdrawalPassword == Users[tempIndex].password)
                    {
                        Users[tempIndex].amount2 = Users[tempIndex].amount2 - withdralAmount;
                        i = 3;
                        Console.WriteLine("Uttaget lyckades! Du har nu " + Users[tempIndex].amount2 + " kr kvar på Sparkontot.");
                        goto start6;
                    }
                    Console.WriteLine("Fel lösenord!");
                }
                Console.WriteLine("Du skrev in fel lösenord för många gånger...");

            }
            if (withdralFromAccount == "3" && Users[tempIndex].amount3 >= withdralAmount)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("Lösenord: ");
                    string withdrawalPassword = Console.ReadLine();
                    if (withdrawalPassword == Users[tempIndex].password)
                    {
                        Users[tempIndex].amount3 = Users[tempIndex].amount3 - withdralAmount;
                        i = 3;
                        Console.WriteLine("Uttaget lyckades! Du har nu " + Users[tempIndex].amount3 + " kr kvar på Räknekontot.");
                        goto start6;
                    }
                    Console.WriteLine("Fel lösenord!");
                }
                Console.WriteLine("Du skrev in fel lösenord för många gånger...");
            }
        start6:

            Console.WriteLine("Klicka enter för att komma till huvudmenyn");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(String.Format("{0," + (Console.WindowWidth - 23) + "}", "Inloggad som anävndare: " + Users[tempIndex].username));
            Console.WriteLine();
        } // Menyval där man kan ta ut pengar från konton

        static void Ogiltligtval(Account[] Users, int tempIndex)
        {
            Console.Clear();
            Console.WriteLine("Ogiltigt val!");

            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine(String.Format("{0," + (Console.WindowWidth - 23) + "}", "Inloggad som anävndare: " + Users[tempIndex].username));
            Console.WriteLine();
        } // Text som kommer upp när användaren agivit fel input
        static void LoggingInSound()
        {
            int C = 264;
            int D = 297;
            int E = 330;
            int F = 352;
            int G = 396;
            int A = 440;
            int B = 495;
            int C2 = 528;


            int half = 1000 / 2;
            int quarter = 1000 / 4;


            Console.Beep(C, quarter);
            Console.Beep(D, quarter);
            Console.Beep(E, quarter);
            Console.Beep(F, quarter);
            Console.Beep(G, quarter);
            Console.Beep(A, quarter);
            Console.Beep(B, quarter);
            Console.Beep(C2, half);
            Thread.Sleep(quarter);

        }

        static void LoggingOutSound()
        {
            int C = 264;
            int D = 297;
            int E = 330;
            int F = 352;
            int G = 396;
            int A = 440;
            int B = 495;
            int C2 = 528;


            int half = 1000 / 2;
            int quarter = 1000 / 4;


            Console.Beep(C2, quarter);
            Console.Beep(B, quarter);
            Console.Beep(A, quarter);
            Console.Beep(G, quarter);
            Console.Beep(F, quarter);
            Console.Beep(E, quarter);
            Console.Beep(D, quarter);
            Console.Beep(C, half);
        }

    }

}
