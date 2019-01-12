using CarteAuTresor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAuTresor.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var fichierDEntree = new FichierDEntree
            {
                NbCasesEnLargeurDeLaCarte = 3,
                NbCasesEnHauteurDeLaCarte = 4
            };
            fichierDEntree.AjouterMontagne(new Montagne(new Position(1, 1)));
            fichierDEntree.AjouterMontagne(new Montagne(new Position(2, 2)));
            fichierDEntree.AjouterTresor(new Tresor(new Position(0, 3), 2));
            fichierDEntree.AjouterTresor(new Tresor(new Position(1, 3), 1));
            var carte = new Carte(fichierDEntree);

            var position = new Position(0, 1);
            var aventurier = new Aventurier("Lara", position, Orientation.Nord);
            carte.Cases.Case(position).Accueille(aventurier);
            var quete = new QueteAuTresor(carte);
            quete.SInscrit(aventurier);
            System.Console.WriteLine(carte.ToString());
            System.Console.ReadLine();

            quete.LAventurierAvance(aventurier);
            System.Console.WriteLine(carte.ToString());
            System.Console.ReadLine();
        }
    }
}
