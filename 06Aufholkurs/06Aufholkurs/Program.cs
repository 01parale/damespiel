using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06Aufholkurs
{
    class Program
    {
        public static int[,] feld = new int[9, 9];
        public static int eingabeX, eingabeY, eingabeXnew, eingabeYnew;
        public static bool spieler1_ist_dran = true;
        public static string symbol2 = "O";
        public static string symbol1 = "X";

        static void Main(string[] args)
        {
            //Prepare game
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
                }
                Console.WriteLine();
            }
            createSpieler1();
            createSpieler2();

            //Game is ready
            Console.SetCursorPosition(1, 1);
            Console.Write("Spieler_X beginnt!");
            while (true)
            {
                Console.SetCursorPosition(1, 16);
                Console.WriteLine("Welchen Stein möchten Sie auswählen?");
                eingabeX = Convert.ToInt32(Console.ReadLine());
                eingabeY = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Geben Sie die neue Position ein");
                eingabeXnew = Convert.ToInt32(Console.ReadLine());
                eingabeYnew = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (eingabeX > 0 && eingabeXnew > 0 && eingabeX < 9 && eingabeXnew < 9 && eingabeY > 0 && eingabeYnew > 0 && eingabeY < 9 && eingabeYnew < 9 && feld[eingabeXnew, eingabeYnew] == 0 && feld[eingabeX, eingabeY] == (spieler1_ist_dran ? 1 : 2))                         //int array bei deklaration leere felder auf 0
                {
                    if (eingabeX == eingabeXnew && (eingabeY + 1 == eingabeYnew || eingabeY - 1 == eingabeYnew))
                    {
                        print(eingabeXnew, eingabeYnew, (spieler1_ist_dran ? symbol1 : symbol2));
                        clear(eingabeX, eingabeY);
                        //Clear Fehler-Anzeige
                        Console.SetCursorPosition(1, 1);
                        Console.WriteLine("                 ");
                    }
                    else if ((eingabeX + 2 == eingabeXnew && eingabeY + 2 == eingabeYnew || eingabeX + 2 == eingabeXnew && eingabeY - 2 == eingabeYnew || eingabeX - 2 == eingabeXnew && eingabeY + 2 == eingabeYnew || eingabeX - 2 == eingabeXnew && eingabeY - 2 == eingabeYnew) && (feld[eingabeX + 1, eingabeY + 1] != 0 || feld[eingabeX + 1, eingabeY - 1] != 0 || feld[eingabeX - 1, eingabeY + 1] != 0 || feld[eingabeX - 1, eingabeY - 1] != 0))
                    {                                                                                                                                                                                                                                                    //im int array alles auf 0 so kann man mit 0 nicht abfragen!                                                           
                        print(eingabeXnew, eingabeYnew, (spieler1_ist_dran ? symbol1 : symbol2));
                        clear(eingabeX, eingabeY);
                        fressen(eingabeX, eingabeY, eingabeXnew, eingabeYnew);
                        //Clear Fehler-Anzeige
                        Console.SetCursorPosition(1, 1);
                        Console.WriteLine("       ");
                    }                      
                    else
                    {
                        //Fehler-Anzeige
                        Console.SetCursorPosition(1, 1);
                        Console.WriteLine("Fehler!           ");
                        continue;
                    }
                }
                else
                {
                    //Fehler-Anzeige
                    Console.SetCursorPosition(1, 1);
                    Console.WriteLine("Fehler!           ");
                    continue;
                }
                //invertiere spieler der dran ist
                spieler1_ist_dran = !spieler1_ist_dran;
            }
        }

        static void createSpieler1()
        {
            Console.SetCursorPosition(5 + 1, 3 + 6);
            feld[1, 3] = 1;
            Console.Write(symbol1);
            Console.SetCursorPosition(5 + 3, 3 + 6);
            feld[3, 6] = 1;
            Console.Write(symbol1);
            Console.SetCursorPosition(5 + 5, 3 + 6);
            feld[5, 6] = 1;
            Console.Write(symbol1);
            Console.SetCursorPosition(5 + 7, 3 + 6);
            feld[7, 6] = 1;
            Console.Write(symbol1);
            Console.SetCursorPosition(5 + 1, 3 + 6);
            feld[1, 6] = 1;
            Console.Write(symbol1);
            Console.SetCursorPosition(5 + 2, 3 + 7);
            feld[2, 7] = 1;
            Console.Write(symbol1);
            Console.SetCursorPosition(5 + 4, 3 + 7);
            feld[4, 7] = 1;
            Console.Write(symbol1);
            Console.SetCursorPosition(5 + 6, 3 + 7);
            feld[6, 7] = 1;
            Console.Write(symbol1);
            Console.SetCursorPosition(5 + 8, 3 + 7);
            feld[8, 7] = 1;
            Console.Write(symbol1);
            Console.SetCursorPosition(5 + 1, 3 + 8);
            feld[1, 8] = 1;
            Console.Write(symbol1);
            Console.SetCursorPosition(5 + 3, 3 + 8);
            feld[3, 8] = 1;
            Console.Write(symbol1);
            Console.SetCursorPosition(5 + 5, 3 + 8);
            feld[5, 8] = 1;
            Console.Write(symbol1);
            Console.SetCursorPosition(5 + 7, 3 + 8);
            feld[7, 8] = 1;
            Console.Write(symbol1);
        }

        static void createSpieler2()
        {
            Console.SetCursorPosition(5 + 2, 3 + 1);
            feld[2, 1] = 2;
            Console.Write(symbol2);
            Console.SetCursorPosition(5 + 4, 3 + 1);
            feld[4, 1] = 2;
            Console.Write(symbol2);
            Console.SetCursorPosition(5 + 6, 3 + 1);
            feld[6, 1] = 2;
            Console.Write(symbol2);
            Console.SetCursorPosition(5 + 8, 3 + 1);
            feld[8, 1] = 2;
            Console.Write(symbol2);
            Console.SetCursorPosition(5 + 1, 3 + 2);
            feld[1, 2] = 2;
            Console.Write(symbol2);
            Console.SetCursorPosition(5 + 3, 3 + 2);
            feld[3, 2] = 2;
            Console.Write(symbol2);
            Console.SetCursorPosition(5 + 5, 3 + 2);
            feld[5, 2] = 2;
            Console.Write(symbol2);
            Console.SetCursorPosition(5 + 7, 3 + 2);
            feld[7, 2] = 2;
            Console.Write(symbol2);
            Console.SetCursorPosition(5 + 2, 3 + 3);
            feld[2, 3] = 2;
            Console.Write(symbol2);
            Console.SetCursorPosition(5 + 4, 3 + 3);
            feld[4, 3] = 2;
            Console.Write(symbol2);
            Console.SetCursorPosition(5 + 6, 3 + 3);
            feld[6, 3] = 2;
            Console.Write(symbol2);
            Console.SetCursorPosition(5 + 8, 3 + 3);
            feld[8, 3] = 2;
            Console.Write(symbol2);
        }

        static void print(int x, int y, string symbol)
        {
            Console.SetCursorPosition(x + 5, y + 3);
            Console.Write(symbol);
            feld[x, y] = (symbol == symbol1 ? 1 : 2);
        }

        static void clear(int x, int y)
        {
            Console.SetCursorPosition(x + 5, y + 3);
            feld[x, y] = 0;
            Console.Write(" ");
        }

        static void fressen(int x, int y, int xnew, int ynew) //nach fressen muss noch verändert werden! dh so das dann nicht gleich gefressen werden kann...
        {
            if (x > xnew && y > ynew)
                clear(x - 1, y - 1);
            else if (x > xnew && y < ynew)
                clear(x - 1, y + 1);
            else if (x < xnew && y > ynew)
                clear(x + 1, y - 1);
            else if (x < xnew && y < ynew)
                clear(x + 1, y + 1);  
        }
    }
}

