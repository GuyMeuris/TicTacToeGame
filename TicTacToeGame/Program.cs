using System;

namespace TicTacToeGame
{
    class Program
    {
        static int speler = 2; // speler 1 begint
        static int beurten = 0;

        // Het speelveld 'oxo' in een 2D array
        static char[,] oxo =
        {
            {'1', '2', '3'}, // rij 0
            {'4', '5', '6'}, // rij 1
            {'7', '8', '9'}  // rij 2
        };

        static void Main(string[] args)
        {

            int ingave = 0;
            bool correcteIngave;

            do    // zolang het spel duurt 
            {

                // Van beurt wisselen met behulp van zelfgemaakte methode
                if (speler == 2)
                {
                    speler = 1;
                    SpelerXofO(speler, ingave);
                }
                else if (speler == 1)
                {
                    speler = 2;
                    SpelerXofO(speler, ingave);
                }

                // speelveld zichtbaar maken met zelfgemaakte methode
                MaakVeld();

                // testen of er een winnaar is met zelfgemaakte methode
                CheckWinnaar();

                // testen of het veld vrij is
                do
                {
                    if (speler == 1)
                        Console.Write("\nSpeler {0}: Kies 1 van de cijfers om een O te plaatsen --> ", speler);
                    else
                        Console.Write("\nSpeler {0}: Kies 1 van de cijfers om een X te plaatsen --> ", speler);
                    if (!int.TryParse(Console.ReadLine(), out ingave))
                    {
                        Console.WriteLine("Verkeerde ingave! Enkel een getal van 1 tot 9 is toegelaten.");
                        correcteIngave = false;
                    }
                    else if (ingave < 1 || ingave > 9)
                    {
                        Console.WriteLine("Verkeerde ingave! Enkel een getal van 1 tot 9 is toegelaten.");
                        correcteIngave = false;
                    }
                    else
                    if ((ingave == 1) && (oxo[0, 0] == '1')) correcteIngave = true;
                    else if ((ingave == 2) && (oxo[0, 1] == '2')) correcteIngave = true;
                    else if ((ingave == 3) && (oxo[0, 2] == '3')) correcteIngave = true;
                    else if ((ingave == 4) && (oxo[1, 0] == '4')) correcteIngave = true;
                    else if ((ingave == 5) && (oxo[1, 1] == '5')) correcteIngave = true;
                    else if ((ingave == 6) && (oxo[1, 2] == '6')) correcteIngave = true;
                    else if ((ingave == 7) && (oxo[2, 0] == '7')) correcteIngave = true;
                    else if ((ingave == 8) && (oxo[2, 1] == '8')) correcteIngave = true;
                    else if ((ingave == 9) && (oxo[2, 2] == '9')) correcteIngave = true;
                    else
                    {
                        Console.WriteLine("Dit veld is reeds ingenomen. Probeer opnieuw.");
                        correcteIngave = false;
                    }
                }
                while (!correcteIngave);

            } while (true);
        }

        public static void MaakVeld() // methode om het speelveld te maken
        {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", oxo[0, 0], oxo[0, 1], oxo[0, 2]); // zie 'char array'-variabele bovenaan
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", oxo[1, 0], oxo[1, 1], oxo[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", oxo[2, 0], oxo[2, 1], oxo[2, 2]);
            Console.WriteLine("     |     |     ");
            beurten++;
        }

        public static void SpelerXofO(int speler, int input)  // methode voor welke speler wat ingeeft
        {
            char XOfO = ' ';  // lokale variabele voor 'X' of 'O' in te geven

            if (speler == 1)
                XOfO = 'X';
            else if (speler == 2)
                XOfO = 'O';

            switch (input)   // switch-methode vervangt if-statements, geen default nodig
            {
                case 1: oxo[0, 0] = XOfO; break;
                case 2: oxo[0, 1] = XOfO; break;
                case 3: oxo[0, 2] = XOfO; break;
                case 4: oxo[1, 0] = XOfO; break;
                case 5: oxo[1, 1] = XOfO; break;
                case 6: oxo[1, 2] = XOfO; break;
                case 7: oxo[2, 0] = XOfO; break;
                case 8: oxo[2, 1] = XOfO; break;
                case 9: oxo[2, 2] = XOfO; break;
            }
        }

        public static void CheckWinnaar() // methode om de winnaar te bepalen door '3-op-een-rij' te zoeken
        {
            char[] spelerXofO = { 'X', 'O' };

            foreach (char XofO in spelerXofO)
            {
                if (((oxo[0, 0] == XofO) && (oxo[0, 1] == XofO) && (oxo[0, 2] == XofO))
                    || ((oxo[1, 0] == XofO) && (oxo[1, 1] == XofO) && (oxo[1, 2] == XofO))
                    || ((oxo[2, 0] == XofO) && (oxo[2, 1] == XofO) && (oxo[2, 2] == XofO))
                    || ((oxo[0, 0] == XofO) && (oxo[1, 0] == XofO) && (oxo[2, 0] == XofO))
                    || ((oxo[1, 0] == XofO) && (oxo[1, 1] == XofO) && (oxo[1, 2] == XofO))
                    || ((oxo[2, 0] == XofO) && (oxo[2, 1] == XofO) && (oxo[2, 2] == XofO))
                    || ((oxo[0, 0] == XofO) && (oxo[1, 1] == XofO) && (oxo[2, 2] == XofO))
                    || ((oxo[2, 0] == XofO) && (oxo[1, 1] == XofO) && (oxo[0, 2] == XofO)))
                {
                    Console.Write("\nWe hebben een winnaar! ");
                    if (XofO == 'X')
                        Console.WriteLine("Proficiat speler 2, jij hebt gewonnen!");
                    else
                        Console.WriteLine("Proficiat speler 1, jij hebt gewonnen!");


                    Console.WriteLine("\nDruk op een toets om een nieuw spel te beginnen.");
                    Console.ReadKey();

                    Resetveld(); // Nieuw speelveld na elk gewonnen spel met zelfgemaakte methode
                    break;
                }
                else if (beurten == 10)
                {
                    Console.WriteLine("\nDit spel heeft geen winnaar! ");
                    Console.WriteLine("Druk op een toets om een nieuw spel te beginnen.");
                    Console.ReadKey();

                    Resetveld(); // Nieuw speelveld na elk gewonnen spel met zelfgemaakte methode
                    break;
                }
            }
        }

        public static void Resetveld()  // methode om het speelveld te 'resetten' na een gewonnen spel
        {
            char[,] oxoReset =  // lokale var 'startarray' om het spel te 'resetten' 
            {
            {'1', '2', '3'},
            {'4', '5', '6'},
            {'7', '8', '9'}
            };

            oxo = oxoReset;
            MaakVeld();   // zelfgemaakte methode om speelveld te maken
            beurten = 0;
        }

    }
}
