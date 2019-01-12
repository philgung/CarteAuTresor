using System;

namespace CarteAuTresor.Domain
{
    public class Tresor : Case
    {
        private readonly int nombreTresor;

        public Tresor(Position position, int nombreTresor) : base(position)
        {
            this.nombreTresor = nombreTresor;
        }

        public int NombreDeTresors()
        {
            return nombreTresor;
        }

        public override string ToString()
        {
            return Aventurier != null ? Aventurier.ToString() : $"T({nombreTresor})";
        }
    }
}