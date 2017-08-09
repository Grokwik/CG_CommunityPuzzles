/*
Le programme :
Affichez sous la forme d'un graphique en ASCII une liste de points donnés dans un repère orthonormé.

L'axe des abscisses est représenté par des tirets -.
L'axe des ordonnées est représenté par des barres verticales (pipe) |.
L'origine du repère est représenté par le caractère plus +.
Chaque point de la liste donnée est représenté par une étoile *.
Chaque zone vide du graphique est représenté par un point ..

Si un point se trouve sur un axe, on affichera le symbole du point * et non le symbole correspondant à l'axe.

La taille du repère à afficher est défini de la manière suivante :
L'abscisse minimale est : (Abscisse minimale des points et/ou de l'origine) - 1
L'abscisse maximale est : (Abscisse minimale des points et/ou de l'origine) + 1
L'ordonnée minimale est : (Ordonnée minimale des points et/ou de l'origine) - 1
L'ordonnée maximale est : (Ordonnée minimale des points et/ou de l'origine) + 1

ENTRÉE :
Ligne 1 : Le nombre N de points à afficher
N prochaines lignes : Deux entiers x et y séparés par un espace pour les coordonnées de chaque point.

SORTIE :
Des chaînes de caractères, chacune représentant une ligne du graphique en ASCII.

CONTRAINTES :
0 ≤ N ≤ 20
-20 ≤ x ≤ 20
-20 ≤ y ≤ 20

EXEMPLE :
Entrée
1
1 1
Sortie
.|..
.|*.
-+--
.|..
*/
using System;
using System.Collections.Generic;

class Pos
{
    public int X;
    public int Y;
    
    public Pos(int x, int y)
    {
        X = x; Y = y;
    }
}

class Solution
{
    static List<Pos> Points;
    static Pos       Min;
    static Pos       Max;

    static void Main(string[] args)
    {
        #region Init
        Min = new Pos(0, 0);
        Max = new Pos(0, 0);
        Points = new List<Pos>();
        var N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            var inputs = Console.ReadLine().Split(' ');
            var x = int.Parse(inputs[0]);
            var y = int.Parse(inputs[1]);
            Min.X = Math.Min(Min.X, x);
            Max.X = Math.Max(Max.X, x);
            Min.Y = Math.Min(Min.Y, y);
            Max.Y = Math.Max(Max.Y, y);
            Points.Add(new Pos(x, y));
        }
        var Grid = new bool[Max.X-Min.X+3, Max.Y-Min.Y+3];
        #endregion

        foreach (var p in Points)
        {
            Grid[p.X-Min.X+1, p.Y-Min.Y+1] = true;
        }

        for (var j=Max.Y+1 ; j>=Min.Y-1 ; j--)
        {
            var cLine = "";
            for (var i=Min.X-1 ; i<=Max.X+1 ; i++)
            {
                if (Grid[i-Min.X+1, j-Min.Y+1] == true)
                {
                    cLine += "*";
                    continue;
                }
                if (j==0)
                {
                    if (i==0)
                        cLine += "+";
                    else
                        cLine += "-";
                    continue;
                }
                if (i==0)
                {
                    cLine += "|";
                    continue;
                }
                cLine += ".";
            }
            Console.WriteLine("{0}", cLine);
        }
    }
}
