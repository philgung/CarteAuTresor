namespace CarteAuTresor.Domain
{
    public struct Position
    {
        public Position(int abscisse, int ordonnee)
        {
            Abscisse = abscisse;
            Ordonnee = ordonnee;
        }

        public int Abscisse { get;}
        public int Ordonnee { get;}

        public override string ToString()
        {
            return $"({Abscisse}, {Ordonnee})";
        }
    }
}