using CarteAuTresor.Domain;
using CarteAuTresor.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAuTresor.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            var lignesFichiersEntree = File.ReadAllLines(@"..\..\FichierDEntree.txt");
            var parser = new Parser();

            var fichierDEntree = parser.Parse(lignesFichiersEntree);
            var carte = new Carte(fichierDEntree);

            var quete = new QueteAuTresor(carte);
            foreach (var aventurier in fichierDEntree.Aventuriers)
            {
                quete.SInscrit(aventurier);
            }
            System.Console.WriteLine("Carte Initiale : ");
            System.Console.WriteLine(carte.ToString());
            System.Console.ReadLine();

            System.Console.WriteLine("Carte à la fin de la quête :");
            quete.Debute();
            System.Console.WriteLine(quete.Carte.ToString());
            foreach (var aventurier in fichierDEntree.Aventuriers)
            {
                System.Console.WriteLine($"{aventurier.Nom} a collecté : {aventurier.TresorCollecte} trésor(s).");
            }
                System.Console.WriteLine("Ecriture du résultat final de la simulation dans resultat_final.txt ...");
            File.WriteAllText("resultat_final.txt", quete.Carte.AfficherSortie());
            System.Console.ReadLine();
        }
    }
}
