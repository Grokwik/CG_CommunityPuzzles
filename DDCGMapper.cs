/*
*** Objectif
Votre programme doit automatiser la création de cartes servant au nouveau jeu "Dance Dance CodinGame". Dans ce jeu, le joueur doit appuyer sur 4 touches en rythme.
Une carte est découpée en lignes de 4 caractères : un zéro (0) indique que la touche associée doit être relâchée, une croix (X) indique que la touche associée doit être appuyée.
Vous trouverez en entrée des motifs de lignes Pattern et leurs fréquences d'apparitions Tempo. Vous devez reproduire un motif toutes les Tempo lignes.
Si une ligne n'a pas de motifs, elle sera composée de 4 zéros : 0000.
Si une ligne contient plusieurs motifs, il faut cumuler les croix, par exemple XX00 et X0X0 devient XXX0.

Attention : une carte se lit de bas en haut !

Entrée
Ligne 1 : La longueur L de la carte.
Ligne 2 : Le nombre N de couples Pattern Tempo.
N lignes suivantes : Une chaîne de caractères Pattern et un nombre Tempo.

Sortie
L lignes représentant la carte.

Contraintes
0 < L < 100
0 < N < 10
0 < Tempo < 100

*** Exemple

Entrée
7
2
X000 2
00XX 3

Sortie
0000
X0XX
0000
X000
00XX
X000
0000
*/

using System;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        var L = int.Parse(Console.ReadLine());
        var N = int.Parse(Console.ReadLine());
        var Cards = new string[L];
        for (var i=0 ; i<L ; i++)
        {
            Cards[i] = "0000";
        }
        for (var i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            var pattern = inputs[0];
            var tempo = int.Parse(inputs[1]);
            for (var j=L-1 ; j>=0 ; j--)
            {
                if ((L-j)%tempo == 0)
                {
                    var tmp = "";
                    for(var c=0 ; c<4 ; c++)
                        tmp +=  (Cards[j][c] == 'X' || pattern[c] == 'X') ? "X" : "0";
                    Cards[j] = tmp;
                }
            }
        }
        for (var i=0 ; i<L ; i++)
        {
            Console.WriteLine("{0}", Cards[i]);
        }
    }
}
