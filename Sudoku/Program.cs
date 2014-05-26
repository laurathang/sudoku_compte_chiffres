using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sudoku
{
    class Program
    {
        public static void afficherSudoku(int[,] sudoku)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(sudoku[i, j]);

                }

                Console.Write("\n");
                if (i == 2 || i == 5)
                    Console.WriteLine("\n");
            }
        }

        public static bool absentSurLaLigne(int[,] sudoku, int x, int y)
        {
            int valeur = sudoku[x, y];
            bool estPresent = true;

            for (int i = 0; i < 9; i++)
            {
                if (i != y)
                {
                    if (sudoku[x, i] == valeur && sudoku[x,i] != 0)
                    {
                        estPresent = false;
                    }
                }
            }
            return estPresent;
        }

        public static int compterChiffresLigne(int[,] sudoku)
        {
            int cptmax = 0;
            int cpt = 0;
            int i, j;
            int numligne = 0;

            for (i = 0; i < 9; i++)
            {

                for (j = 0; j < 9; j++)
                {
                    //comptage des chiffres != 0
                    if (sudoku[i, j] != 0)
                        cpt++;
                }

                Console.WriteLine("cpt=" + cpt);

                if (cpt > cptmax)
                {
                    //sauvegarde  de la + grande qté de chiffres
                    cptmax = cpt;
                    //sauvegarde du numéro de ligne qui a le + de chiffres
                    numligne=i;
                }

                cpt = 0;
            }

            //retour numéro de ligne qui a le plus de chiffres
            return numligne;

        }

        public static int compterChiffresColonne(int[,] sudoku)
        {
            int cptmax = 0;
            int cpt = 0;
            int i, j;
            int numcol = 0;

            for (i = 0; i < 9; i++)
            {

                for (j = 0; j < 9; j++)
                {
                    //comptage des chiffres != 0
                    if (sudoku[j, i] != 0)
                        cpt++;
                }

                Console.WriteLine("cpt=" + cpt);

                if (cpt > cptmax)
                {
                    cptmax = cpt;
                    //sauvegarde du numéro de colonne qui a le + de chiffres
                    numcol = i;
                }

                cpt = 0;
            }

            //retour numéro de ligne qui a le plus de chiffres
            return numcol;

        }

        public static bool absentSurLaColonne(int[,] sudoku, int x, int y)
        {
            int valeur = sudoku[x, y];
            bool estPresent = true;

            for (int i = 0; i < 9; i++)
            {
                if (i != x)
                {
                    if (sudoku[i, y] == valeur && sudoku[i, y] != 0)
                    {
                        estPresent = false;
                    }
                }
            }
            return estPresent;
        }

        public static int compterChiffresRegion (int[,] sudoku, double max, int x, int y)
        {
            int _x = quelMin(max, x);
            Console.WriteLine("min X :" + _x);

            int _y = quelMin(max, y);
            Console.WriteLine("min Y :" + _y);

            int cpt = 0, cptmax = 0;

            for (int i = _x; i < _x + 3; i++)
            {
                for (int j = _y; j < _y + 3; j++)
                {
                    if (i != x && j != y)
                    {
                        if (sudoku[i, j] != 0)
                        {
                            cpt++;
                        }
                    }
                }

                if (cpt > cptmax)
                    cptmax = cpt;

                cpt = 0;
            }
            return cptmax;
        }

        public static bool absentSurLaRegion(int[,] sudoku, int x, int y, double max)
        {
            int valeur = sudoku[x, y];
            bool estPresent = true;

            Console.WriteLine("X : " + x + " Y : " + y);

            int _x = quelMin(max, x);
            Console.WriteLine("min X :" + _x);

            int _y = quelMin(max, y);
            Console.WriteLine("min Y :" + _y);

            for (int i = _x; i < _x + 3; i++)
            {
                for (int j = _y; j < _y + 3; j++)
                {
                    if (i != x && j != y)
                    {
                        if (sudoku[i, j] == valeur)
                        {
                            estPresent = false;
                        }
                    }
                }
            }
            return estPresent;
        }

        public static int quelMin(double max, int valeur)
        {
            int min = 0;

            Console.WriteLine("Valeur : " + valeur);

            if (valeur < max && valeur >= 6)
            {
                min = 6;
            }
            if (valeur < 6 && valeur >= 3)
            {
                min = 3;
            }
            if (valeur < 3 && valeur >= 0)
            {
                min = 0;
            }

            return min;
        }

        public static void lireFichier()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\WriteText.txt");
            char[] tableau = new char[30];
            System.Console.WriteLine("Contents of WriteText.txt = ");
            for (int i = 0; i < lines.Length; i++)
            {
                using (StringReader sr = new StringReader(lines[i]))
                {
                    sr.Read(tableau, 0, lines[i].Length - 1);
                    Console.WriteLine(tableau);
                }
            }

        }

        static void Main(string[] args)
        {
            int[,] sudoku =
                      {
                       {0,0,0, 3,0,0, 0,5,0},
                       {0,0,5, 4,0,6, 0,0,2},
                       {2,7,0, 0,1,0, 3,6,0},

                       {7,0,4, 2,3,0, 0,0,0},
                       {5,1,0, 0,0,0, 0,3,7},
                       {0,0,0, 0,4,7, 9,0,1},

                       {0,4,6, 0,9,0, 0,1,5},
                       {1,0,0, 6,0,8, 7,0,0},
                       {0,5,0, 0,0,4, 0,0,0}
                      };

            double maxXouY = Math.Sqrt(sudoku.Length);

            afficherSudoku(sudoku);

            //lireFichier();

           // int cptligne = compterChiffresColonne(sudoku);

            int cptligne = compterChiffresRegion(sudoku, maxXouY, 0, 0);

            Console.WriteLine("cptligne ="+cptligne+"\n");

            Console.ReadLine();
        }
    }
}
