using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06Aufholkurs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetCursorPosition(6, 2);
            Console.Write("12345678");              //8x8 feld
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    Console.SetCursorPosition(x + 5, 0 + 3);
                    Console.Write("¯");
                    Console.SetCursorPosition(x + 5, 8 + 4);
                    Console.Write("¯");

                    Console.SetCursorPosition(0 + 5, y + 3);
                    Console.Write("|");
                    Console.SetCursorPosition(8 + 6, y + 3);
                    Console.Write("|");

                    setzn1(x, y);
                    setzn2(x, y);
                }
                Console.WriteLine();
            }
            spieler = 0;
            for (int i = 0; i < 100; i++)
            {
                Console.SetCursorPosition(1, 16);
                Console.WriteLine("Welchen Stein möchten Sie auswählen?");
                eingabep = Convert.ToInt32(Console.ReadLine());
                eingabep2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Geben Sie die neue Position ein");
                eingabepn = Convert.ToInt32(Console.ReadLine());
                eingabepn2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if(feld[eingabepn,eingabepn2] == 0)                         //int array bei deklaration leere felder auf 0
                {
                    if(eingabep == eingabepn)
                    {
                        kontrolle(eingabepn, eingabepn2);
                        kontrolle2(eingabep, eingabep2);
                        feld[eingabep, eingabep2] = 1;
                        Console.SetCursorPosition(1, 1);
                        Console.WriteLine("      ");
                    }
                    else if((eingabep + 2 == eingabepn && eingabep2 + 2 == eingabepn2||eingabep + 2 == eingabepn && eingabep2 - 2 == eingabepn2||eingabep - 2 == eingabepn && eingabep2 + 2 == eingabepn2||eingabep - 2 == eingabepn && eingabep2 - 2 == eingabepn2) && (feld[eingabep + 1, eingabep2 + 1] != 0 || feld[eingabep + 1, eingabep2 - 1] != 0 ||feld[eingabep - 1, eingabep2 + 1] != 0 ||feld[eingabep - 1, eingabep2 - 1] != 0 ))
                    {                                                                                                                                                                                                                                                    //im int array alles auf 0 so kann man mit 0 nicht abfragen!                                                           
                        kontrolle(eingabepn, eingabepn2);
                        kontrolle2(eingabep, eingabep2);
                        Console.SetCursorPosition(1, 1);
                        Console.WriteLine("      ");
                        fressen(eingabep, eingabep2);
                        //kontrolle3(eingabep, eingabep2);
                    }
                    else
                    {
                        Console.SetCursorPosition(1, 1);
                        Console.WriteLine("Fehler");
                    }
                }
                else
                {
                    Console.SetCursorPosition(1,1);
                    Console.WriteLine("Fehler");
                }
                feld[eingabep, eingabep2] = 0;
                spieler++;
            }
            Console.ReadKey();
        }
        public static int[,] feld = new int[9, 9];
        public static int eingabep, eingabep2, eingabepn, eingabepn2, spieler;
        static void setzn1(int x, int y)
        {
            string spieler_1 = "X";
            Console.SetCursorPosition(5 + 1, 3 + 6);
            feld[1, 3] = 1;
            Console.Write(spieler_1);
            Console.SetCursorPosition(5 + 3, 3 + 6);
            feld[3, 6] = 1;
            Console.Write(spieler_1);
            Console.SetCursorPosition(5 + 5, 3 + 6);
            feld[5, 6] = 1;
            Console.Write(spieler_1);
            Console.SetCursorPosition(5 + 7, 3 + 6);
            feld[7, 6] = 1;
            Console.Write(spieler_1);
            Console.SetCursorPosition(5 + 1, 3 + 6);
            feld[1, 6] = 1;
            Console.Write(spieler_1);
            Console.SetCursorPosition(5 + 2, 3 + 7);
            feld[2, 7] = 1;
            Console.Write(spieler_1);
            Console.SetCursorPosition(5 + 4, 3 + 7);
            feld[4, 7] = 1;
            Console.Write(spieler_1);
            Console.SetCursorPosition(5 + 6, 3 + 7);
            feld[6, 7] = 1;
            Console.Write(spieler_1);
            Console.SetCursorPosition(5 + 8, 3 + 7);
            feld[8, 7] = 1;
            Console.Write(spieler_1);
            Console.SetCursorPosition(5 + 1, 3 + 8);
            feld[1, 8] = 1;
            Console.Write(spieler_1);
            Console.SetCursorPosition(5 + 3, 3 + 8);
            feld[3, 8] = 1;
            Console.Write(spieler_1);
            Console.SetCursorPosition(5 + 5, 3 + 8);
            feld[5, 8] = 1;
            Console.Write(spieler_1);
            Console.SetCursorPosition(5 + 7, 3 + 8);
            feld[7, 8] = 1;
            Console.Write(spieler_1);
        }
        static void setzn2(int x, int y)
        {
            string spieler_2 = "O";
            Console.SetCursorPosition(5 + 2, 3 + 1);
            feld[2, 1] = 1;
            Console.Write(spieler_2);
            Console.SetCursorPosition(5 + 4, 3 + 1);
            feld[4, 1] = 1;
            Console.Write(spieler_2);
            Console.SetCursorPosition(5 + 6, 3 + 1);
            feld[6, 1] = 1;
            Console.Write(spieler_2);
            Console.SetCursorPosition(5 + 8, 3 + 1);
            feld[8, 1] = 1;
            Console.Write(spieler_2);
            Console.SetCursorPosition(5 + 1, 3 + 2);
            feld[1, 2] = 1;
            Console.Write(spieler_2);
            Console.SetCursorPosition(5 + 3, 3 + 2);
            feld[3, 2] = 1;
            Console.Write(spieler_2);
            Console.SetCursorPosition(5 + 5, 3 + 2);
            feld[5, 2] = 1;
            Console.Write(spieler_2);
            Console.SetCursorPosition(5 + 7, 3 + 2);
            feld[7, 2] = 1;
            Console.Write(spieler_2);
            Console.SetCursorPosition(5 + 2, 3 + 3);
            feld[2, 3] = 1;
            Console.Write(spieler_2);
            Console.SetCursorPosition(5 + 4, 3 + 3);
            feld[4, 3] = 1;
            Console.Write(spieler_2);
            Console.SetCursorPosition(5 + 6, 3 + 3);
            feld[6, 3] = 1;
            Console.Write(spieler_2);
            Console.SetCursorPosition(5 + 8, 3 + 3);
            feld[8, 3] = 1;
            Console.Write(spieler_2);
        }
        static void kontrolle(int x, int y)
        {
            
                if (spieler % 2 == 0)
                {
                    string spieler_2 = "O";
                    Console.SetCursorPosition(eingabepn + 5, eingabepn2 + 3);
                    feld[eingabepn, eingabepn2] = 1;
                    Console.Write(spieler_2);
                }
                else
                {
                    string spieler_1 = "X";
                    Console.SetCursorPosition(eingabepn + 5, eingabepn2 + 3);
                    feld[eingabepn, eingabepn2] = 1;
                    Console.Write(spieler_1);
                }
            
        }
        static void kontrolle2(int x, int y)
        {
                string spieler3 = " ";
                Console.SetCursorPosition(eingabep + 5, eingabep2 + 3);
                feld[eingabepn, eingabepn2] = 0;
                Console.Write(spieler3);
        }
        static void fressen(int x, int y)//Beim fressen wird das z.B feld[2,6] auf 0 gesetzt jedoch bleibt das X  dort stehen...jedoch wenn man von diesem punkt aus den stein X verschieben möchte bleibt der stein erhalten und es wird nur ein nuer stein erzeugt! 
        {
            //if(feld[eingabep, eingabep2] == 1 && feld[eingabep + 1, eingabep2 + 1] == 1)

            if (feld[eingabep, eingabep2] == 1)
                feld[eingabepn, eingabepn2] = 2;

            feld[eingabep + 1, eingabep2 + 1] = 0;
            string spieler3 = " ";
            Console.SetCursorPosition(eingabep + 1, eingabep2 + 1);
            Console.Write(spieler3);
        }

    }
}

