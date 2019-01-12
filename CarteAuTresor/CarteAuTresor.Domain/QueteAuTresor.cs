using System;
using System.Collections.Generic;
using System.Linq;

namespace CarteAuTresor.Domain
{
    public class QueteAuTresor
    {
        public Carte Carte { get; private set; }
        private int _ordreDePassageCourant = 1;

        public QueteAuTresor(Carte carte)
        {
            this.Carte = carte;
        }

        public IDictionary<int, Aventurier> OrdreDePassage { get; private set; } = new SortedList<int, Aventurier>();

        public void SInscrit(Aventurier aventurier)
        {
            if (Carte.Cases.EstUneMontagne(aventurier.Position))
            {
                throw new CarteAuTresorDomainException($"Un aventurier ne peut se positionner sur une montagne {aventurier.Position.ToString()}.");
            }

            OrdreDePassage.Add(new KeyValuePair<int, Aventurier>(_ordreDePassageCourant++, aventurier));
            Carte.Cases.Case(aventurier.Position).Accueille(aventurier);
        }

        public void LAventurierAvance(Aventurier aventurier)
        {
            var prochainePosition = aventurier.ProchainePosition();

            if (Carte.DeplacementAutorise(aventurier, prochainePosition))
            {
                var initialPosition = aventurier.Position;

                aventurier.Position = prochainePosition;

                Carte.Cases.Case(initialPosition).Quitte();
                var prochaineCase = Carte.Cases.Case(prochainePosition);
                prochaineCase.Accueille(aventurier);
                if (prochaineCase is Tresor)
                {
                    aventurier.CollecteTresor();
                    (prochaineCase as Tresor).NombreDeTresors--;
                }
            }
        }

        public void Debute()
        {
            var tailleParcoursMax = OrdreDePassage.Max(x => x.Value.Parcours.Length);
            for (int indexParcours = 0; indexParcours < tailleParcoursMax; indexParcours++)
            {
                foreach (var item in OrdreDePassage)
                {
                    var aventurier = item.Value;
                    if (aventurier.Parcours.Length <= indexParcours)
                        continue;
                    switch (aventurier.Parcours[indexParcours])
                    {
                        case 'A':
                            LAventurierAvance(aventurier);
                            break;
                        case 'D':
                            aventurier.TourneADroite();
                            break;
                        default:
                        case 'G':
                            aventurier.TourneAGauche();
                            break;                        
                    }
                }
            }
        }
    }
}