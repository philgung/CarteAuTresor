using System;

namespace CarteAuTresor.Domain
{
    public class Tresor : Case
    {
        public int NombreDeTresors { get; set; }

        public Tresor(Position position, int nombreTresor) : base(position)
        {
            this.NombreDeTresors = nombreTresor;
        }


        public override string ToString()
        {
            return Aventurier != null ? Aventurier.ToString() : $"T({NombreDeTresors})";
        }
    }
}