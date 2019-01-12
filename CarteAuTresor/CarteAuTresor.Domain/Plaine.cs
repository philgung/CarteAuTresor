using System;

namespace CarteAuTresor.Domain
{
    public class Plaine : Case
    {
        

        public Plaine(Position position): base(position)
        {
        }

        public override string ToString()
        {
            return Aventurier != null ? Aventurier.ToString() : ".";
        }

        
    }
}