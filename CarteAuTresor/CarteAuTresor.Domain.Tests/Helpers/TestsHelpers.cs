using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAuTresor.Domain.Tests.Helpers
{
    public static class TestsHelpers
    {

        public static FichierDEntree InitFichierDEntree(int nbCasesEnLargeurAttendus, int nbCasesEnHauteurAttendus)
        {
            return new FichierDEntree
            {
                NbCasesEnLargeurDeLaCarte = nbCasesEnLargeurAttendus,
                NbCasesEnHauteurDeLaCarte = nbCasesEnHauteurAttendus
            };
        }
        public static QueteAuTresor InitQuete()
        {
            var carte = InitCarte();
            var quete = new QueteAuTresor(carte);
            return quete;
        }

        public static Carte InitCarte()
        {
            var fichierDEntree = InitFichierDEntree(3, 4);
            fichierDEntree.AjouterMontagne(new Montagne(new Position(1, 1)));
            fichierDEntree.AjouterMontagne(new Montagne(new Position(2, 2)));
            fichierDEntree.AjouterTresor(new Tresor(new Position(0, 3), 2));
            fichierDEntree.AjouterTresor(new Tresor(new Position(1, 3), 1));
            var carte = new Carte(fichierDEntree);
            return carte;
        }

        public static Carte InitDeuxiemeCarte()
        {
            var fichierDEntree = InitFichierDEntree(3, 4);
            fichierDEntree.AjouterMontagne(new Montagne(new Position(1, 0)));
            fichierDEntree.AjouterMontagne(new Montagne(new Position(2, 1)));
            fichierDEntree.AjouterTresor(new Tresor(new Position(0, 3), 2));
            fichierDEntree.AjouterTresor(new Tresor(new Position(1, 3), 3));
            var carte = new Carte(fichierDEntree);
            return carte;
        }

        public static QueteAuTresor InitDeuxiemeQuete()
        {
            var carte = InitDeuxiemeCarte();
            var quete = new QueteAuTresor(carte);
            return quete;
        }

        

        public static Aventurier CreateLara(Position position)
        {
            return new Aventurier("Lara", position, Orientation.Nord, "GGAAGAGAAGAA");
        }

        public static Aventurier CreateLili(Position position)
        {
            return new Aventurier("Lili", position, Orientation.Sud, "AADADAGGA");
        }
    }
}
