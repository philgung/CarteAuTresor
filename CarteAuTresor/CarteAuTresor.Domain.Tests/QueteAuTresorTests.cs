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
    public class QueteAuTresorTests
    {
        [Fact]
        public void LorsqueDesAventuriersSInscriveAUneQueteEstDefiniUnOrdreDePassage()
        {
            // Arrange
            var quete = TestsHelpers.InitQuete();
            var lara = TestsHelpers.CreateLara(new Position(1, 0));
            var aventurier2 = new Aventurier("John", new Position(2, 3), Orientation.Est, "");
            var aventurier3 = new Aventurier("Paul", new Position(0, 0), Orientation.Sud, "");
            // Act
            quete.SInscrit(lara);
            quete.SInscrit(aventurier2);
            quete.SInscrit(aventurier3);
            // Assert
            quete.OrdreDePassage.First().Value.Should().Be(lara);
            quete.OrdreDePassage.Last().Value.Should().Be(aventurier3);
        }

        [Fact]
        public void UnAventurierNePeutEtrePositionnerSurUneMontagne()
        {
            // Arrange
            var quete = TestsHelpers.InitQuete();
            var lara = TestsHelpers.CreateLara(new Position(1, 1));
            // Act

            // Assert
            quete.Invoking(x => x.SInscrit(lara)).Should().Throw<CarteAuTresorDomainException>().WithMessage("Un aventurier ne peut se positionner sur une montagne (1, 1).");
        }

        [Fact]
        public void UnAventurierNePeutSeDeplacerQueDUneCaseALaFoisDansLaDirectionDefinieParSonOrientation()
        {
            // Arrange
            var quete = TestsHelpers.InitQuete();
            var initialPosition = new Position(0, 1);
            var lara = TestsHelpers.CreateLara(initialPosition);
            quete.SInscrit(lara);
            // Act

            quete.LAventurierAvance(lara);

            // Assert
            lara.Position.Abscisse.Should().Be(0);
            lara.Position.Ordonnee.Should().Be(0);
            quete.Carte.Cases.Case(initialPosition).Aventurier.Should().BeNull();
            quete.Carte.Cases.Case(lara.Position).Aventurier.Should().NotBeNull();
            quete.Carte.Cases.Case(lara.Position).Aventurier.Should().Be(lara);

        }

        [Fact]
        public void UnAventurierNePeutPasTraverserUneMontagne()
        {
            // Arrange
            var quete = TestsHelpers.InitQuete();
            var initialPosition = new Position(0, 1);
            var lara = TestsHelpers.CreateLara(initialPosition);
            quete.SInscrit(lara);
            lara.TourneADroite();
            // Act
            quete.LAventurierAvance(lara);

            // Assert
            lara.Position.Should().Be(initialPosition);
            lara.Orientation.Should().Be(Orientation.Est);
        }

        [Fact]
        public void UnAventurierDebuteSonParcoursAvecUneOrientationEtUneSequenceDeMouvement()
        {
            // Arrange
            var quete = TestsHelpers.InitDeuxiemeQuete();
            var initialPosition = new Position(1, 1);
            var lili = new Aventurier("Lili", initialPosition, Orientation.Sud, "AADADAGGA");

            quete.SInscrit(lili);

            // Act 
            quete.Debute();
            // Assert
            quete.Carte.ToString().Should().Be(
                ".\tM\t.\n" +
                ".\t.\tM\n" +
                ".\t.\t.\n" +
                "A(Lili)\tT(2)\t.\n");
            lili.TresorCollecte.Should().Be(3);
        }

        [Fact]
        public void DeuxAventuriersDebuteLeurParcoursAvecConflit()
        {
            // Arrange
            var quete = TestsHelpers.InitDeuxiemeQuete();

            var initialPosition = new Position(1, 1);
            var lili = new Aventurier("Lili", initialPosition, Orientation.Sud, "AADADAGGA");
            var lala = new Aventurier("lala", new Position(2, 2), Orientation.Ouest, "AAADAA");
            quete.SInscrit(lili);
            quete.SInscrit(lala);

            // Act 
            quete.Debute();
            // Assert
            quete.Carte.ToString().Should().Be(
                "A(lala)\tM\t.\n" +
                ".\t.\tM\n" +
                ".\t.\t.\n" +
                "A(Lili)\tT(2)\t.\n");
            lili.TresorCollecte.Should().Be(3);
            lala.TresorCollecte.Should().Be(0);
        }

        [Fact]
        public void UnAventurierNePeutAllerAuDelaDeLaCarte()
        {
            // Arrange
            var quete = TestsHelpers.InitDeuxiemeQuete();

            var initialPosition = new Position(2, 2);
            var lili = new Aventurier("Lili", initialPosition, Orientation.Est, "ADAADAAADAAAA");
            quete.SInscrit(lili);

            // Act 
            quete.Debute();
            // Assert
            quete.Carte.ToString().Should().Be(
                "A(Lili)\tM\t.\n" +
                ".\t.\tM\n" +
                ".\t.\t.\n" +
                "T(1)\tT(2)\t.\n");

        }
    }
}
