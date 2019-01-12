namespace CarteAuTresor.Domain
{
    public class Montagne : Case
    {
        public Montagne(Position position) : base(position)
        {
        }

        public override string ToString()
        {
            return "M";
        }
    }
}