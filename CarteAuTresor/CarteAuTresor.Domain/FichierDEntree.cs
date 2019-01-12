using System;
using System.Collections.Generic;

namespace CarteAuTresor.Domain
{
    public class FichierDEntree
    {
        public IList<Montagne> Montagnes { get; set; } = new List<Montagne>();
        public IList<Tresor> Tresors { get; set; } = new List<Tresor>();

        public FichierDEntree()
        {
        }

        public int NbCasesEnLargeurDeLaCarte { get; set; }
        public int NbCasesEnHauteurDeLaCarte { get; set; }

        public void AjouterMontagne(Montagne montagne)
        {
            Montagnes.Add(montagne);
        }

        public void AjouterTresor(Tresor tresor)
        {
            Tresors.Add(tresor);
        }
    }
}