using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarteAuTresor.Domain.Tests
{
    public class CaseTests
    {
        [Fact]
        public void SurUneCaseOnPeutYTrouverDesPlainesDesMontagnesEtDesTresors()
        {
            // Arrange

            // Act

            // Assert
            typeof(Tresor).Should().BeDerivedFrom<Case>();
            typeof(Montagne).Should().BeDerivedFrom<Case>();
            typeof(Plaine).Should().BeDerivedFrom<Case>();
        }

        [Fact]
        public void UneCasePeutContenirPlusieursTresors()
        {
            // Arrange

            // Act
            var tresors = new Tresor(new Position(0, 1), 3);
            // Assert
            tresors.NombreDeTresors().Should().Be(3);
        }

        [Fact] 
        public void UneCaseNePeutAccueillirQuUnAventurier()
        {
            // Arrange
            var plaine = new Plaine(new Position(0, 0));
            var aventurier1 = new Aventurier("Lara", new Position(0, 0), Orientation.Nord);
            var aventurier2 = new Aventurier("John", new Position(0, 0), Orientation.Sud);
            // Act
            // Assert
            plaine.Accueille(aventurier1);
            plaine.ToString().Should().Be("A(Lara)");

            plaine.Invoking(x => x.Accueille(aventurier2)).Should().Throw<CarteAuTresorDomainException>().WithMessage("Une case ne peut accueillir plus d'un aventurier (0, 0).");
        }
    }
}
