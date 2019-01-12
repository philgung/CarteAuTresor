using System;

namespace CarteAuTresor.Domain
{
    public abstract class Case
    {
        public Aventurier Aventurier { get; private set; }
        public Case(Position position)
        {
            Position = position;
        }

        public Position Position { get; set; }

        public void Accueille(Aventurier aventurier)
        {
            if (Aventurier != null && !Aventurier.Equals(aventurier))
                throw new CarteAuTresorDomainException($"Une case ne peut accueillir plus d'un aventurier {Position.ToString()}.");

            Aventurier = aventurier;
        }

        public void Quitte()
        {
            Aventurier = null;
        }
    }
}