using System;

namespace CarteAuTresor.Domain
{
    public class Aventurier
    {
        public Aventurier(string nom, Position position, Orientation nord)
        {
            Nom = nom;
            Position = position;
            Orientation = nord;
        }

        public Position Position { get; set; }

        public Orientation Orientation { get; private set; }
        public string Nom { get; }

        public void TourneAGauche()
        {
            switch (Orientation)
            {
                case Orientation.Nord:
                    Orientation = Orientation.Ouest;
                    break;
                case Orientation.Sud:
                    Orientation = Orientation.Est;
                    break;
                case Orientation.Est:
                    Orientation = Orientation.Nord;
                    break;
                default:
                case Orientation.Ouest:
                    Orientation = Orientation.Sud;
                    break;
            }
        }

        public Position ProchainePosition()
        {
            switch (Orientation)
            {
                case Orientation.Nord:
                    return new Position(Position.Abscisse, Position.Ordonnee - 1);
                case Orientation.Sud:
                    return new Position(Position.Abscisse, Position.Ordonnee + 1);
                case Orientation.Est:
                    return new Position(Position.Abscisse - 1, Position.Ordonnee);
                default:
                case Orientation.Ouest:
                    return new Position(Position.Abscisse + 1, Position.Ordonnee);
            }
        }

        public void TourneADroite()
        {
            switch (Orientation)
            {
                case Orientation.Nord:
                    Orientation = Orientation.Est;
                    break;
                case Orientation.Sud:
                    Orientation = Orientation.Ouest;
                    break;
                case Orientation.Est:
                    Orientation = Orientation.Sud;
                    break;
                default:
                case Orientation.Ouest:
                    Orientation = Orientation.Nord;
                    break;
            }
        }

        public override string ToString()
        {
            return $"A({Nom})";
        }
    }
}