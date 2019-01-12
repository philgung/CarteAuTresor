using CarteAuTresor.Domain;
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
            // TODO : Parser fichier

            var fichierDEntree = new FichierDEntree
            {
                NbCasesEnLargeurDeLaCarte = 3,
                NbCasesEnHauteurDeLaCarte = 4
            };
            fichierDEntree.AjouterMontagne(new Montagne(new Position(1, 0)));
            fichierDEntree.AjouterMontagne(new Montagne(new Position(2, 1)));
            fichierDEntree.AjouterTresor(new Tresor(new Position(0, 3), 2));
            fichierDEntree.AjouterTresor(new Tresor(new Position(1, 3), 3));
            var carte = new Carte(fichierDEntree);

            var quete = new QueteAuTresor(carte);
            var aventurier = new Aventurier("Lara", new Position(1, 1), Orientation.Sud, "AADADAGGA");
            quete.SInscrit(aventurier);
            System.Console.WriteLine("Carte Initiale : ");
            System.Console.WriteLine(carte.ToString());
            System.Console.ReadLine();

            System.Console.WriteLine("Carte à la fin de la quête :");
            quete.Debute();
            System.Console.WriteLine(quete.Carte.ToString());
            System.Console.WriteLine($"{aventurier.Nom} a collecté : {aventurier.TresorCollecte} trésor(s).");
            System.Console.WriteLine("Ecriture du résultat final de la simulation dans resultat_final.txt ...");
            File.WriteAllText("resultat_final.txt", quete.Carte.AfficherSortie());
            System.Console.ReadLine();
        }
    }
}
