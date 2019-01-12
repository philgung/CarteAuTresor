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
            var aventurier = new Aventurier("Lara", position, Orientation.Nord);
            // Assert
            aventurier.Position.Abscisse.Should().Be(0);
            aventurier.Position.Ordonnee.Should().Be(1);
            aventurier.Orientation.Should().Be(Orientation.Nord);
        }

        [Fact]
        public void IlPeutChangerDOrientationEnPivotantA90VersLaDroiteOuVersLaGauche()
        {
            // Arrange
            var position = new Position(0, 1);
            var aventurier = new Aventurier("Lara", position, Orientation.Nord);

            // Act

            // Assert
            aventurier.TourneAGauche();
            aventurier.Orientation.Should().Be(Orientation.Ouest);

            aventurier.TourneAGauche();
            aventurier.Orientation.Should().Be(Orientation.Sud);

            aventurier.TourneAGauche();
            aventurier.Orientation.Should().Be(Orientation.Est);

            aventurier.TourneAGauche();
            aventurier.Orientation.Should().Be(Orientation.Nord);

            aventurier.TourneADroite();
            aventurier.Orientation.Should().Be(Orientation.Est);

            aventurier.TourneADroite();
            aventurier.Orientation.Should().Be(Orientation.Sud);

            aventurier.TourneADroite();
            aventurier.Orientation.Should().Be(Orientation.Ouest);

            aventurier.TourneADroite();
            aventurier.Orientation.Should().Be(Orientation.Nord);

        }

        [Fact]
        public void UnAventurierAUnNom()
        {
            // Arrange

            // Act
            var aventurier = new Aventurier("Lara", new Position(0, 1), Orientation.Est);
            // Assert
            aventurier.Nom.Should().NotBeNull();
        }

        // Parcours
        // Position sur la carte
        // Traverser !
        // Séquence de mouvement
    }
}
