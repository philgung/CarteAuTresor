using System;

namespace CarteAuTresor.Domain
{
    public class CarteAuTresorDomainException : Exception
    {
        public CarteAuTresorDomainException(string message) : base(message)
        {
        }
    }
}