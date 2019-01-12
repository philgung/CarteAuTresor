using CarteAuTresor.Domain.Tests.Helpers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarteAuTresor.Domain.Tests
{
    public class AventurierTests
    {
        [Fact]
        public void UnAventurierEstCarateriseParSaPositionSurLaCarteEtSonOrientation()
        {
            // Arrange
            var position = new Position(0, 1);
            // Act
            var lara = TestsHelpers.CreateLara(position);
            // Assert
            lara.Position.Abscisse.Should().Be(0);
            lara.Position.Ordonnee.Should().Be(1);
            lara.Orientation.Should().Be(Orientation.Nord);
        }

        [Fact]
        public void IlPeutChangerDOrientationEnPivotantA90VersLaDroiteOuVersLaGauche()
        {
            // Arrange
            var position = new Position(0, 1);
            var lara = TestsHelpers.CreateLara(position);

            // Act

            // Assert
            lara.TourneAGauche();
            lara.Orientation.Should().Be(Orientation.Ouest);

            lara.TourneAGauche();
            lara.Orientation.Should().Be(Orientation.Sud);

            lara.TourneAGauche();
            lara.Orientation.Should().Be(Orientation.Est);

            lara.TourneAGauche();
            lara.Orientation.Should().Be(Orientation.Nord);

            lara.TourneADroite();
            lara.Orientation.Should().Be(Orientation.Est);

            lara.TourneADroite();
            lara.Orientation.Should().Be(Orientation.Sud);

            lara.TourneADroite();
            lara.Orientation.Should().Be(Orientation.Ouest);

            lara.TourneADroite();
            lara.Orientation.Should().Be(Orientation.Nord);

        }

        [Fact]
        public void UnAventurierAUnNom()
        {
            // Arrange

            // Act
            var aventurier = new Aventurier("Lara", new Position(0, 1), Orientation.Est,"");
            // Assert
            aventurier.Nom.Should().NotBeNull();
        }
    }
}
