using System;
using System.Collections.Generic;

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
        }

        public void LAventurierAvance(Aventurier aventurier)
        {
            var prochainePosition = aventurier.ProchainePosition();

            if (Carte.DeplacementAutorise(aventurier, prochainePosition))
            {
                var initialPosition = aventurier.Position;

                aventurier.Position = prochainePosition;

                // Récupérer le trésor si présent
                Carte.Cases.Case(initialPosition).Quitte();
                Carte.Cases.Case(prochainePosition).Accueille(aventurier);
                // -> Trésor pris
            }
        }
    }
}