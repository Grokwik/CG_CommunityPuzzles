/*
Le programme :
Vous devez détecter les véhicules en excès de vitesse en calculant leurs vitesses moyennes entre deux ou plus de deux instantanées photos prises sur une route.
Vous devez afficher la plaque d'immatriculation et la position de l'appareil photo ayant pris la photo de l'excès de vitesse.

Les données d'entrée contiennent tous les enregistrements horodatés pour chaque plaque d'immatriculation détectée. Tous les enregistrements sont groupés par plaques d'immatriculation et les distances des appareils photo sont triées par ordre croissant à l'intérieur de ce groupe.
Si aucun excès de vitesse n'est détecté, votre programme doit afficher OK.

ENTRÉE :
Ligne 1: Un entier L correspondant à la vitesse limite autorisé pour la route (en kilomètres par heure).
Ligne 2: Un entier N correspondant au nombre d'enregistrements photographiques prit par les appareils.
N Lignes suivantes: 3 valeurs séparées par des espaces qui sont : la plaque d'immatriculation L, la distance de l'appareil photo (en kilomètres par rapport au début de la route) C et le Timestamp du moment de la photo prise par l'appareil (nombre de secondes depuis le 01/01/1970) T.

SORTIE :
Pour chaque véhicule pris en excès de vitesse : Afficher la plaque d'immatriculation L ainsi que la distance de l'appareil C ayant détecté l'infraction, séparés par des espaces, dans le même ordre que les valeurs d'entrées.
Quand aucun véhicule n'est en excès de vitesse : afficher OK

CONTRAINTES :
10 ≤ L ≤ 100
0 ≤ N ≤ 100
0 ≤ C ≤ 1000

EXEMPLE :
Entrée
50
3
RSLJ97 134 1447409503
RSLJ97 185 1447413099
RSLJ97 201 1447420298

Sortie
RSLJ97 185
*/

using System;
using System.Collections;

class Flash
{
    int Dist;
    int Timestamp;
    
    public Flash(int dist, int stamp)
    {
        Dist = dist;
        Timestamp = stamp;
    }

    public double GetSpeed(int dist2, int stamp2)
    {
        var deltaDist = dist2 - Dist;
        var chrono = (double)(stamp2 - Timestamp)/3600;
        return (deltaDist/chrono);
    }
}

class Solution
{
    static int MaxSpeed;
    static int FlashCount;
    
    static void Main(string[] args)
    {
        MaxSpeed = int.Parse(Console.ReadLine());
        FlashCount = int.Parse(Console.ReadLine());
        var flashes = new Hashtable();
        var ok = true;
        for (int i=0 ; i<FlashCount ; i++)
        {
            //  Getting the infos of this new flash
            var flashInfos = Console.ReadLine().Split(' ');
            var fdist = int.Parse(flashInfos[1]);
            var fstamp = int.Parse(flashInfos[2]);

            //  Computing the speed if it's not the first one for this car
            if (flashes.ContainsKey(flashInfos[0]))
            {
                var prev = ((Flash)flashes[flashInfos[0]]).GetSpeed(fdist, fstamp);
                if (prev > MaxSpeed)
                {
                    Console.WriteLine("{0} {1}", flashInfos[0], fdist);
                    ok = false;
                }
                flashes.Remove(flashInfos[0]);
            }

            //  Storing the infos for future computation (if applies)
            flashes.Add(flashInfos[0], new Flash(fdist, fstamp));
        }
        if (ok)
            Console.WriteLine("OK");
    }
}
