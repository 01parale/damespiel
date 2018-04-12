using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06Aufholkurs
{
    class Program
    {
        public static int[,] feld = new int[9, 9];
        public static string EingabeX, EingabeXnew;
        public static int eingabeX, eingabeXnew;
        public static int eingabeY, eingabeYnew;
        public static bool spieler1_ist_dran = true;
        public static string symbol2 = "O";
        public static string symbol1 = "X";

        static void Main(string[] args)
        {
            //Prepare game
            //erstellen der Beschriftung
            Console.SetCursorPosition(2, 2);
            Console.Write("X   abcdefgh");              //8x8 feld
            Console.SetCursorPosition(0, 3);
            int a = 0;
            Console.WriteLine("Y");
            for (int i = 0; i < 8; i++)
            {
                a++;
                Console.WriteLine(a);
            }
            //Infobox
            Console.SetCursorPosition(40, 4);
            Console.Write("Zu erst wird immer der X Koordinate eingegeben dann...Enter");
            Console.SetCursorPosition(40, 5);
            Console.Write("Y Koordinate eingeben...Enter");
            Console.SetCursorPosition(40, 6);
            Console.Write("Jetzt das gleiche nochmal mit dem neuen Punkt...");
            Console.SetCursorPosition(40, 7);
            Console.Write("Es wird immer X&Y verschoben...");
            Console.SetCursorPosition(40, 8);
            Console.Write("Auch dabei immer nur einen Schritt...außer");
            Console.SetCursorPosition(40, 9);
            Console.Write("Beim Fressen darf weiter gesprungen werdn und auch in alle Richtungen...");
            Console.SetCursorPosition(40, 10);
            Console.Write("Bei einem Fehler ist dennoch der selbe Spieler dran...");
            Console.SetCursorPosition(40, 11);
            Console.Write("Auf den Fehler wird hingewiesen...oberhalb des Spielfeldes...");

            //Create Spielfeld
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
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
            //Create Spieler
            createSpieler1();
            createSpieler2();

            //Game is ready
            Console.SetCursorPosition(1, 1);
            Console.Write("Spieler_X beginnt!");
            while (true)
            {
                //Spielstein auswahl & Verschiebungspunkt
                Console.SetCursorPosition(1, 16);
                //Console.WriteLine("Welchen Stein möchten Sie auswählen?");
                Console.Write("Welchen Stein möchten sie auswählen?\n");
                EingabeX = Console.ReadLine();
                eingabeY = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Geben Sie die neue Position ein");
                EingabeXnew = Console.ReadLine();
                eingabeYnew = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                convertzuzahlen();

                //Abfrage bewewegung in leeres Feld und ob angegebener Punkt sich im Spielfeld befindet
                if (eingabeX > 0 && eingabeXnew > 0 && eingabeX < 9 && eingabeXnew < 9 && eingabeY > 0 && eingabeYnew > 0 && eingabeY < 9 && eingabeYnew < 9 && feld[eingabeXnew, eingabeYnew] == 0 && feld[eingabeX, eingabeY] == (spieler1_ist_dran ? 1 : 2))                         //int array bei deklaration leere felder auf 0
                {
                    //Abfrage ob X-Achsenwert gleichgebliben ist und ob Y-Achsenwert sich nur um 1 verschoben hat 
                    if ((eingabeX + 1 == eingabeXnew || eingabeX - 1 == eingabeXnew) && (eingabeY + 1 == eingabeYnew || eingabeY - 1 == eingabeYnew))
                    {
                        print(eingabeXnew, eingabeYnew, (spieler1_ist_dran ? symbol1 : symbol2));
                        clear(eingabeX, eingabeY);
                        //Clear Fehler-Anzeige
                        Console.SetCursorPosition(1, 1);
                        Console.WriteLine("                                                                           ");

                    }
                    //Abfrage zum fressen...dh ob ein zu fresender Spielstein vorhanden ist und ob man den richtig schritt gemacht hat...
                    else if ((eingabeX + 2 == eingabeXnew && eingabeY + 2 == eingabeYnew || eingabeX + 2 == eingabeXnew && eingabeY - 2 == eingabeYnew || eingabeX - 2 == eingabeXnew && eingabeY + 2 == eingabeYnew || eingabeX - 2 == eingabeXnew && eingabeY - 2 == eingabeYnew) && (feld[eingabeX + 1, eingabeY + 1] != 0 || feld[eingabeX + 1, eingabeY - 1] != 0 || feld[eingabeX - 1, eingabeY + 1] != 0 || feld[eingabeX - 1, eingabeY - 1] != 0))
                    {                                                                                                                                                                                                                                                    //im int array alles auf 0 so kann man mit 0 nicht abfragen!                                                           
                        print(eingabeXnew, eingabeYnew, (spieler1_ist_dran ? symbol1 : symbol2));
                        clear(eingabeX, eingabeY);
                        fressen(eingabeX, eingabeY, eingabeXnew, eingabeYnew);
                        //Clear Fehler-Anzeige
                        Console.SetCursorPosition(1, 1);
                        Console.WriteLine("                                                                           ");
                    }
                    else
                    {
                        //Fehler-Anzeige
                        Console.WriteLine("                                                                           ");
                        Console.SetCursorPosition(1, 1);
                        Console.WriteLine("Fehler! Es kann nur schräg Gesprungen werden und immer nur ein feld weiter");
                        continue;
                    }
                }
                else
                {
                    //Fehler-Anzeige
                    Console.WriteLine("                                                                           ");
                    Console.SetCursorPosition(1, 1);
                    Console.WriteLine("Fehler! Ausßerhalb des Spielfeldes bzw Stein im Weg                        ");
                    continue;
                }
                //invertiere spieler der dran ist
                spieler1_ist_dran = !spieler1_ist_dran;
            }
        }

        static void createSpieler1()    //Spielsteine X werden eingefügt
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

        static void createSpieler2()    //Spielsteine O werden eingefügt
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

        static void print(int x, int y, string symbol)    //Ausgabe am neuen Punkt
        {
            Console.SetCursorPosition(x + 5, y + 3);
            Console.Write(symbol);
            feld[x, y] = (symbol == symbol1 ? 1 : 2);
        }

        static void clear(int x, int y)    //Löschen des alten Punktes
        {
            Console.SetCursorPosition(x + 5, y + 3);
            feld[x, y] = 0;
            Console.Write(" ");
        }

        static void fressen(int x, int y, int xnew, int ynew)   //Möglichkeiten Aubfragen...dann gefressen Spielstein löschen
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

        static void convertzuzahlen()
        {
            //EingabeX(string) to eingabeX(int) Converten
            if (EingabeX == "a")
                eingabeX = 1;

            if (EingabeX == "b")
                eingabeX = 2;

            if (EingabeX == "c")
                eingabeX = 3;

            if (EingabeX == "d")
                eingabeX = 4;

            if (EingabeX == "e")
                eingabeX = 5;

            if (EingabeX == "f")
                eingabeX = 6;

            if (EingabeX == "g")
                eingabeX = 7;

            if (EingabeX == "h")
                eingabeX = 8;

            //EingabeXnew(string) to eingabeXnew(int) Converten
            if (EingabeXnew == "a")
                eingabeXnew = 1;

            if (EingabeXnew == "b")
                eingabeXnew = 2;

            if (EingabeXnew == "c")
                eingabeXnew = 3;

            if (EingabeXnew == "d")
                eingabeXnew = 4;

            if (EingabeXnew == "e")
                eingabeXnew = 5;

            if (EingabeXnew == "f")
                eingabeXnew = 6;

            if (EingabeXnew == "g")
                eingabeXnew = 7;

            if (EingabeXnew == "h")
                eingabeXnew = 8;

        }

    }
}


